using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_QuestLog : MonoBehaviour
{
    public GameObject questInListPrefab;
    public RectTransform listTransform;

    public RectTransform questDescription;
    public TMP_Text questNameText;
    public TMP_Text questDescriptionText;
    public TMP_Text questMPRewardText;
    public TMP_Text questSBRewardText;
    public TMP_Text questObjectiveText;
    public RectTransform rewardsContent;

    private GameObject questLogObject;
    private Button[] questButtons;

    private Quest currentQuest;
    private int previousButtonIndex;

    private void Awake()
    {
        if (questLogObject == null)
        {
            Debug.LogWarning("questLogObject null");
            questLogObject = GameObject.Find("Canvas").transform.Find("Panel").Find("Character panel").Find("All funtion").Find("Quest").GetChild(0).gameObject;
            questButtons = new Button[0];
            previousButtonIndex = 0;
            QuestLog.Initialize();
            QuestLog.onQuestChange += UpdateQuests;
            // UpdateQuests(new List<Quest>(), new List<Quest>());

        }
        // if(q)

        // QuestLog.onQuestChange += UpdateQuests;
    }
    private void Update()
    {
        QuestLog.DoQuestProcess();
    }
    private void OnDestroy()
    {
        QuestLog.onQuestChange -= UpdateQuests;
    }


    public void UpdateQuests(List<Quest> active, List<Quest> completed)
    {
        HandleSizeChange(active.Count + completed.Count);
        UpdateQuestNames(active, completed);
        UpdateSelectedQuest();
        ShowQuestDetails(currentQuest);
    }

    private void HandleSizeChange(int newCount)
    {
        // if (listTransform.sizeDelta is null) Debug.Log("have sizeDelta");
        listTransform.sizeDelta = new Vector2(0, newCount * 80);
        int oldCount = questButtons.Length;
        System.Array.Resize(ref questButtons, newCount);
        for (int i = oldCount; i < questButtons.Length; i++)
        {
            questButtons[i] = InitializeButton(i);
        }
    }

    private void UpdateQuestNames(List<Quest> active, List<Quest> completed)
    {
        for (int i = 0; i < active.Count; i++)
        {
            UpdateQuestText(questButtons[i], active[i]);
        }
        for (int i = 0; i < completed.Count; i++)
        {
            UpdateQuestText(questButtons[i + active.Count], completed[i], true);
        }
    }

    private void UpdateSelectedQuest()
    {
        if (currentQuest == null)
            return;
        for (int i = 0; i < questButtons.Length; i++)
        {
            if (questButtons[i].GetComponentInChildren<TMP_Text>().text == currentQuest.questName)
            {
                HighlightQuestButton(questButtons[i], true);
                previousButtonIndex = i;
                // return;
            }
            else
            {
                HighlightQuestButton(questButtons[i], false);
            }
        }
    }

    private void ShowQuestDetails(Quest quest)
    {
        questDescription.gameObject.SetActive(quest != null);
        if (quest == null)
            return;
        questNameText.text = quest.questName;
        questDescriptionText.text = quest.questDescription;
        questMPRewardText.text = quest.MPReward + "MP";
        questSBRewardText.text = quest.SBReward;
        questObjectiveText.text = quest.objective.ToString();
    }

    private Button InitializeButton(int index)
    {
        Button button = Instantiate(questInListPrefab, listTransform).GetComponent<Button>();
        // button.image.rectTransform.sizeDelta = new Vector2(0, 80);
        button.image.rectTransform.anchoredPosition = new Vector2(0, 140 - (40 * index));
        button.onClick.AddListener(delegate { QuestPress(button); });
        return button;
    }

    private void UpdateQuestText(Button questButton, Quest quest, bool isCompleted = false)
    {
        TMP_Text text = questButton.GetComponentInChildren<TMP_Text>();
        text.text = quest.questName;
        // text.color = isCompleted ? new Color(201/255f, 165/255f, 157/255f, 1) : GetColorFromCategory(quest.questCategory);
        text.color = isCompleted ? Color.gray : GetColorFromCategory(quest.questCategory);
    }

    private Color GetColorFromCategory(short category)
    {
        return new Color(201 / 255f, 165 / 255f, 157 / 255f, 1);
    }

    private void HighlightQuestButton(Button questButton, bool active)
    {
        questButton.image.color = active ? Color.red : Color.white;
    }

    private void QuestPress(Button questButton)
    {
        HighlightQuestButton(questButtons[previousButtonIndex], false);
        HighlightQuestButton(questButton, true);
        previousButtonIndex = System.Array.IndexOf(questButtons, questButton);
        currentQuest = QuestLog.getQuestNo(previousButtonIndex);
        ShowQuestDetails(currentQuest);
    }

}
