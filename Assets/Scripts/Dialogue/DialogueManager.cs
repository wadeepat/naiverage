using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    private static DialogueManager instance;


    private void Awake()
    {
        Debug.Log("Awake");
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialog Manager in the scene.");
        }
        instance = this;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Start()
    {
        // dialogueIsPlaying = false;
        // dialoguePanel.SetActive(false);
        // choicesText = new TextMeshProUGUI[choices.Length];
        // int index = 0;
        // foreach (GameObject choice in choices)
        // {
        //     choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
        //     index++;
        // }
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }


    private void Update()
    {
        // Debug.Log("playing " + dialogueIsPlaying);
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Debug.Log("EnterDialogue");
        // Debug.Log(inkJSON.text);
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        // Debug.Log("active " + dialoguePanel.active);

        ContinueStory();
    }
    private void ExitDialogueMode()
    {
        // yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
            // StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    // public Text nameText;
    // public Text dialogueText;
    // private Queue<string> sentences;
    // void Start()
    // {
    //     sentences = new Queue<string>();
    // }

    // public void StartDialogue(Dialogue dialogue)
    // {
    //     nameText.text = dialogue.name;
    //     sentences.Clear();
    //     foreach (string sentence in dialogue.sentences)
    //     {
    //         sentences.Enqueue(sentence);
    //     }
    //     DisplayNextSentence();
    // }
    // private void DisplayNextSentence()
    // {
    //     if (sentences.Count == 0)
    //     {
    //         EndDialogue();
    //         return;
    //     }
    //     string sentence = sentences.Dequeue();
    //     dialogueText.text = sentence;
    // }

    // private void EndDialogue()
    // {
    //     Debug.Log("End");
    // }
}
