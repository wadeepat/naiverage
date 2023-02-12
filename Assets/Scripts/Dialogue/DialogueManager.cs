using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;
using StarterAssets;
using System;

[System.Serializable]
public class JSONfile
{
    public string name;
    public TextAsset json;
}
public class DialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.06f;
    [Header("Globals Ink File")]
    [SerializeField] private TextAsset loadGlobalsJSON;
    [Header("Ink Files")]
    [SerializeField] private JSONfile[] tutorialFiles;
    [SerializeField] private JSONfile[] chapter1Files;
    [SerializeField] private JSONfile[] chapter2Files;
    [SerializeField] private JSONfile[] chapter3Files;
    [SerializeField] private JSONfile[] chapter4Files;
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI continueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    public static bool dialogueIsPlaying;
    private TextMeshProUGUI[] choicesText;
    private Story currentStory;
    private bool canContinueToNextLine = false;
    private Coroutine displayLineCoroutine;
    public static DialogueManager instance { get; private set; }
    public DialogueVariables dialogueVariables { get; private set; }

    private const string ACTION_TAG = "action";
    private const string EVENT_TAG = "event";
    private const string QUEST_TAG = "quest";
    private const string QUEST_COMPLETED_TAG = "questComplete";
    private const string SOUND_TAG = "sound";
    private const string SPEAKER_TAG = "speaker";
    private GameObject _player;
    private string playerName;
    // public GameObject Player;
    // StarterAssetsInputs assetsInputs;
    ThirdPersonController _thirdPersonController;
    private void Awake()
    {
        if (instance != null)
        {
            // Debug.LogWarning("Found more than one Dialogue Manager in the scene.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += DestroySelf;
    }

    // called second
    void DestroySelf(Scene scene, LoadSceneMode mode)
    {
        int sceneIdx = SceneManager.GetActiveScene().buildIndex;
        if (sceneIdx == 0)
        {
            Destroy(this.gameObject);
            instance = null;
        }
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= DestroySelf;
    }
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _thirdPersonController = _player?.GetComponent<ThirdPersonController>();
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        // assetsInputs = Player?.GetComponent<StarterAssetsInputs>();
    }
    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine
        && currentStory.currentChoices.Count == 0
        && InputManager.instance.GetNextPressed()
        && !ActionHandler.instance.IsSomeWindowsActivated())
        {
            ContinueStory();
        }
    }
    public void LoadDialogue()
    {
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _thirdPersonController = _player?.GetComponent<ThirdPersonController>();

        _player?.GetComponent<Animator>().SetFloat("Speed", 0f);
        _player?.GetComponent<Animator>().SetTrigger("reset");
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        LockCamera();

        playerName = ActionHandler.instance.playerName;
        if (String.IsNullOrEmpty(playerName)) playerName = "Me";

        dialogueVariables.StartListenning(currentStory);

        //reset name, sound ...etc.
        displayNameText.text = "???";

        ContinueStory();
    }
    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        dialogueVariables.SaveVariables();

        UnlockCamera();
    }
    private void EndTheDialogue()
    {
        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        dialogueVariables.SaveVariables();

        UnlockCamera();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // dialogueText.text = currentStory.Continue();
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            //handle tags
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private IEnumerator DisplayLine(string line)
    {
        //set text to full line, but set the visible characters to 0 for hiding
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        //hide UI that don't want to show while typing
        continueText.gameObject.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;
        foreach (char letter in line.ToCharArray())
        {

            if (InputManager.instance.GetNextPressed())
            {
                dialogueText.maxVisibleCharacters = line.Length;
                break;
            }

            //check for rich text tag
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            //normal text
            else
            {
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        continueText.gameObject.SetActive(true);
        DisplayChoices();

        canContinueToNextLine = true;
    }
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    if (tagValue == "Me") displayNameText.text = playerName;
                    else displayNameText.text = tagValue;
                    break;
                case QUEST_TAG:
                    EndTheDialogue();
                    QuestLog.AddQuest(Database.questList[int.Parse(tagValue)]);
                    break;
                case QUEST_COMPLETED_TAG:
                    QuestLog.CompleteQuest(Database.questList[int.Parse(tagValue)]);
                    break;
                case EVENT_TAG:
                    StageHandler.instance.EventTrigger(tagValue);
                    break;
                case SOUND_TAG:
                    AudioManager.instance.Play(tagValue);
                    break;
                case ACTION_TAG:
                    EndTheDialogue();
                    ActionHandler.instance.ReceiveActionThenContinueStory(tagValue, ContinueStory);
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not being handled: " + tag);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {

        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }
        else if (currentChoices.Count > 0)
        {
            EnablePlayerControll();
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
        // Debug.Log(dialogueVariables == null ? "dialogue null" : "dialogue not null");
    }

    private void HideChoices()
    {
        DisablePlayerControll();
        foreach (GameObject choiceBtn in choices)
        {
            choiceBtn.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIdx)
    {
        AudioManager.instance.Play("makeChoice");
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIdx);
            ContinueStory();
        }
        // if (dialogueVariables == null) LoadDialogue();
        // Debug.Log(dialogueVariables == null ? "Make choice dialogue null" : "Make choice dialogue not null");
        dialogueVariables.SaveVariables();
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }
    public void EnablePlayerControll()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // assetsInputs.cursorInputForLook = true;
        // assetsInputs.cursorLocked = true;
    }
    public void DisablePlayerControll()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // assetsInputs.cursorInputForLook = false;
        // assetsInputs.cursorLocked = false;
        // assetsInputs.look = new Vector2(0, 0);
    }
    public void LockCamera()
    {
        _thirdPersonController?.SetLockCameraPosition(true);
    }
    public void UnlockCamera()
    {
        _thirdPersonController?.SetLockCameraPosition(false);
    }
    public TextAsset GetDialogueFile(int chapter, string name)
    {
        JSONfile[] files = { };
        switch (chapter)
        {
            case 0:
                files = tutorialFiles;
                break;
            case 1:
                files = chapter1Files;
                break;
            case 2:
                files = chapter2Files;
                break;
            case 3:
                files = chapter3Files;
                break;
            case 4:
                files = chapter4Files;
                break;
        }
        foreach (JSONfile file in files)
        {
            if (file.name == name) return file.json;
        }
        return null;
    }
}
