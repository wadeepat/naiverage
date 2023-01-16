using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static readonly Dictionary<string, string> COLORS = new Dictionary<string, string>(){
        {"button","#900C3F"},
        {"char","#FEF4E8"},
        {"item","#09bc8a"},
        {"menu","#363062"},
        {"monster","#FFBD39"},
        {"town","#FF7272"},
    };

    public static Pearl magicPearl = new Pearl();

    public static List<Item> itemList = new List<Item>();
    public static List<Item> itemQuestList = new List<Item>();
    public static List<Monster> monsterList = new List<Monster>();
    public static List<Potion> potionList = new List<Potion>();
    public static List<Quest> questList = new List<Quest>();
    public static List<SkillBook> skillBookList = new List<SkillBook>();
    public static List<Skill> skillList = new List<Skill>();

    private GameObject CanvasObject;
    private GameObject TutorialCardObject;
    private GameObject PotionPanel;
    private ChapterCard chapterCardScript;
    void Awake()
    {
        CanvasObject = GameObject.Find("Canvas");
        chapterCardScript = CanvasObject.transform.Find("ChapterCard").GetComponent<ChapterCard>();
        TutorialCardObject = CanvasObject.transform.Find("TutorialGuiding").gameObject;
        PotionPanel = CanvasObject.transform.Find("Panel").Find("Character panel").Find("All funtion").Find("Potion").gameObject;
        // (id,name,description)
        itemList.Add(new Item(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        itemList.Add(new Item(1, "Mushroom", "Item", Resources.Load<Sprite>("1"), 0));
        itemList.Add(new Item(2, "Flower2", "Item", Resources.Load<Sprite>("2"), 0));

        potionList.Add(new Potion(0, "None", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0, 0, 0));
        potionList.Add(new Potion(1, "HP", "Potion", Resources.Load<Sprite>("p1"), 0, true, 1, 2, 0, 2, 3, 0));
        potionList.Add(new Potion(2, "Stamina", "Potion", Resources.Load<Sprite>("p2"), 0, true, 1, 0, 0, 5, 0, 0));
        potionList.Add(new Potion(3, "t1", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0, 0, 0));
        potionList.Add(new Potion(4, "t2", "Potion", Resources.Load<Sprite>("p1"), 0, true, 1, 2, 0, 2, 3, 0));
        potionList.Add(new Potion(5, "t3", "Potion", Resources.Load<Sprite>("p2"), 0, true, 1, 0, 0, 5, 0, 0));
        potionList.Add(new Potion(6, "t4", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0, 0, 0));
        potionList.Add(new Potion(7, "t5", "Potion", Resources.Load<Sprite>("p1"), 0, true, 1, 2, 0, 2, 3, 0));
        potionList.Add(new Potion(8, "t6", "Potion", Resources.Load<Sprite>("p2"), 0, true, 1, 0, 0, 5, 0, 0));

        itemQuestList.Add(new Item(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        itemQuestList.Add(new Item(1, "Quest1", "Quest", Resources.Load<Sprite>("q1"), 0));
        itemQuestList.Add(new Item(2, "Quest2", "Quest", Resources.Load<Sprite>("q2"), 0));

        skillBookList.Add(new SkillBook(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        skillBookList.Add(new SkillBook(1, "SKB1", "None", Resources.Load<Sprite>("skb1"), 0));
        skillBookList.Add(new SkillBook(2, "SKB2", "None", Resources.Load<Sprite>("skb2"), 0));
        skillBookList.Add(new SkillBook(3, "SKB3", "None", Resources.Load<Sprite>("skb3"), 0));
        skillBookList.Add(new SkillBook(4, "SKB4", "None", Resources.Load<Sprite>("skb4"), 0));
        skillBookList.Add(new SkillBook(5, "SKB5", "None", Resources.Load<Sprite>("skb5"), 0));
        skillBookList.Add(new SkillBook(6, "SKB6", "None", Resources.Load<Sprite>("skb6"), 0));
        skillBookList.Add(new SkillBook(7, "SKB7", "None", Resources.Load<Sprite>("skb7"), 0));
        skillBookList.Add(new SkillBook(8, "SKB8", "None", Resources.Load<Sprite>("skb8"), 0));
        skillBookList.Add(new SkillBook(9, "SKB9", "None", Resources.Load<Sprite>("skb9"), 0));

        magicPearl = new Pearl(0, "Magic Pearl", "None", Resources.Load<Sprite>("Pearl"), 0);

        skillList.Add(new Skill(0, "None", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0));
        skillList.Add(new Skill(1, "SK1", "None", Resources.Load<Sprite>("sk1"), 0, false, 1, 0, 1, 500));
        skillList.Add(new Skill(2, "SK2", "None", Resources.Load<Sprite>("sk2"), 0, false, 2, 0, 1, 1000));
        skillList.Add(new Skill(3, "SK3", "None", Resources.Load<Sprite>("sk3"), 0, false, 3, 0, 1, 1500));
        skillList.Add(new Skill(4, "SK4", "None", Resources.Load<Sprite>("sk4"), 0, false, 4, 0, 1, 2000));
        skillList.Add(new Skill(5, "SK5", "None", Resources.Load<Sprite>("sk5"), 0, false, 1, 0, 1, 500));
        skillList.Add(new Skill(6, "SK6", "None", Resources.Load<Sprite>("sk6"), 0, false, 2, 0, 1, 1000));
        skillList.Add(new Skill(7, "SK7", "None", Resources.Load<Sprite>("sk7"), 0, false, 3, 0, 1, 1500));
        skillList.Add(new Skill(8, "SK8", "None", Resources.Load<Sprite>("sk8"), 0, false, 4, 0, 1, 2000));
        skillList.Add(new Skill(9, "SK9", "None", Resources.Load<Sprite>("sk9"), 0, false, 4, 0, 1, 2000));

        //* Monster section id, hp, atk, def, res, reHp
        //MonsterId.Webster
        monsterList.Add(new Monster(0, 100, 20, 10, 0, 1));
        // MonsterId.Venom
        monsterList.Add(new Monster(1, 100, 20, 10, 0, 1));
        // MonsterId.Rachne
        monsterList.Add(new Monster(2, 100, 20, 10, 0, 1));
        // MonsterId.Bandit
        monsterList.Add(new Monster(3, 100, 20, 10, 0, 1));
        // MonsterId.Goblin
        monsterList.Add(new Monster(4, 100, 20, 10, 0, 1));
        // MonsterId.Skeleton
        monsterList.Add(new Monster(5, 100, 20, 10, 0, 1));
        // MonsterId.Troll
        monsterList.Add(new Monster(6, 500, 20, 10, 0, 1));
        // MonsterId.Cain
        monsterList.Add(new Monster(7, 100, 20, 10, 0, 1));
        // MonsterId.Abel
        monsterList.Add(new Monster(8, 100, 20, 10, 0, 1));

        //* Quest section
        //* chapter 0
        questList.Add(
            new Quest()
            {
                questId = 0,
                questName = "เรียนรู้การเคลื่อนที่",
                questDescription = "ควบคุมตัวละครไปยังพื้นที่ที่ส่องแสง",
                location = SceneIndex.Rachne,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = 1,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    chapterCardScript.ActivateMenu(0);
                    ActivateTutorialCard("Walking", true);
                },
                compleltedAction = () =>
                {
                    ActivateTutorialCard("Walking", false);
                    QuestLog.AddQuest(Database.questList[1]);
                },
            });
        questList.Add(
        new Quest()
        {
            questId = 1,
            questName = "เรียนรู้การเก็บของ",
            questDescription = "ลองเก็บ MUSHROOM ตรงใต้ต้นไม้นั่นสิ",
            location = SceneIndex.Rachne,
            MPReward = 0,
            SBReward = "",
            questCategory = 0,
            objective = new Quest.Objective()
            {
                objectiveId = 1,
                type = Quest.Objective.Type.collect,
                amount = 1,
            },
            addAction = () =>
            {
                ActivateTutorialCard("PickupItems", true);
            },
            compleltedAction = () =>
            {
                ActivateTutorialCard("PickupItems", false);
                QuestLog.AddQuest(Database.questList[2]);
            }
        }
        );
        questList.Add(
            new Quest()
            {
                questId = 2,
                questName = "เรียนรู้การปรุงยา",
                questDescription = $"ยาเป็นไอเทมที่ดีที่การช่วยในการต่อสู้เลยนะ\n ลองเปิดที่ <color={COLORS["menu"]}>Potion</color> ดูสิ",
                location = SceneIndex.Rachne,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = 1,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActivateTutorialCard("CraftPotion", true);
                },
                updateAction = () =>
                {
                    if (PotionPanel.activeSelf)
                    {
                        QuestLog.CompleteQuest(QuestLog.GetQuestById(2));
                    }
                },
                compleltedAction = () =>
                {
                    ActivateTutorialCard("CraftPotion", false);
                    QuestLog.AddQuest(Database.questList[3]);
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 3,
                questName = "เรียนรู้การใช้ยา",
                questDescription = "เจ้ามียาเพิ่มเลือด และยาเพิ่มมานาอยู่ลองใช้สักขวดสิ",
                location = SceneIndex.Rachne,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = 1,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActivateTutorialCard("UsePotion", true);
                },
                compleltedAction = () =>
                {
                    ActionHandler.instance.ActivateTutorialCard("UsePotion", false);
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("CompletedUsePotion"));
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 4,
                questName = "ต่อสู้เพื่อเอาชีวิตรอด",
                questDescription = $"อยู่ ๆ ก็มี <color={COLORS["monster"]}>webster</color> โผล่มา จงกำจัดมันเพื่อเอาตัวรอดซะ",
                location = SceneIndex.Rachne,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Webster,
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActivateTutorialCard("NormalAttack", true);
                    StageHandler.instance.EventTrigger("Spawn1Webster");
                },
                compleltedAction = () =>
                {
                    ActivateTutorialCard("NormalAttack", false);
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("CompletedUsePotion"));
                    StageHandler.instance.EventTrigger("SataAppear");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 5,
                questName = $"ช่วยเหลือ <color={COLORS["char"]}>Sata</color> (1/2)",
                questDescription = $"<color={COLORS["char"]}>Sata</color> ช่างน่าสงสารเสียจริง ไปเก็บขาเแมงมุมเพื่อช่วย <color={COLORS["char"]}>Sata</color> กันเถอะ",
                location = SceneIndex.Rachne,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Webster,
                    type = Quest.Objective.Type.kill,
                    amount = 5,
                },
                addAction = () =>
                {
                    ActivateTutorialCard("Skill", true);
                    StageHandler.instance.EventTrigger("Spawn5Webster");
                },
                compleltedAction = () =>
                {
                    ActivateTutorialCard("Skill", false);
                    QuestLog.AddQuest(questList[6]);
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 6,
                questName = $"ช่วยเหลือ <color={COLORS["char"]}>Sata</color> (2/2)",
                questDescription = $"ไปคุยกับ <color={COLORS["char"]}>Sata</color> เพื่อรับรางวัล",
                location = SceneIndex.Rachne,
                MPReward = 1000,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Sata,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetTutorialFiles("FinishedWebsterQ"),
                    amount = 1,
                },
                addAction = () =>
                {
                    ActivateTutorialCard("TalkToNPC", true);
                },
                compleltedAction = () =>
                {
                    ActivateTutorialCard("TalkToNPC", false);
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 7,
                questName = $"เดินทางไปยังเมือง <color={COLORS["town"]}>Naver</color>",
                questDescription = $"มีเรื่องราวลึกลับ และน่าสนใจรอเจ้าอยู่ ออกเดินทางไปยังเมือง <color={COLORS["town"]}>Naver</color> ตาม <color={COLORS["char"]}>Sata</color> ไปกันเถอะ",
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = 1,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActivateTutorialCard("WarpAndMap", true);
                    StageHandler.instance.EventTrigger("CompletedTutorial");
                    StageHandler.instance.EventTrigger("SataLeadToTown");
                },
                prepareAction = () =>
                {
                    if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown) QuestLog.CompleteQuest(QuestLog.GetQuestById(7));
                },
                // updateAction = () =>
                // {
                //     // Debug.Log("Check quest 6 : " + StageHandler.instance.activeSceneIndex);
                //     if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown) QuestLog.CompleteQuest(QuestLog.GetQuestById(7));
                // },
                compleltedAction = () =>
                {
                    ActivateTutorialCard("WarpAndMap", false);
                    chapterCardScript.ActivateMenu(1);
                    // StageHandler.instance.EventTrigger("IntroduceAaron");
                },
            }
        );
        //* chapter 1
        questList.Add(
            new Quest()
            {
                questId = 8,
                questName = $"ภารกิจจากแม่ทัพ (1/2)",
                questDescription = $"กำจัด <color={COLORS["monster"]}>Webster</color> ในป่า <color={COLORS["town"]}>Rachne</color>",
                location = SceneIndex.Rachne,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Webster,
                    type = Quest.Objective.Type.kill,
                    amount = 10,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("AaronMoveToMainDoor");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("Spawn10Webster");
                },
                compleltedAction = () =>
                {
                    QuestLog.AddQuest(questList[9]);
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 9,
                questName = $"ภารกิจจากแม่ทัพ (2/2)",
                questDescription = $"ไปคุยกับ <color={COLORS["char"]}>Aaron</color> ในเมือง <color={COLORS["char"]}>Naver</color> เพื่อรับรางวัล",
                location = SceneIndex.NaverTown,
                MPReward = 1000,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Aaron,
                    npc = NPCIndex.Aaron,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetChapter1Files("AaronQuest"),
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("AaronQuest");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 10,
                questName = $"รับงานจาก {ColorText("char", "Sata")}",
                questDescription = $"ไปคุยกับ {ColorText("char", "Sata")} บริเวณหน้าปราสาทในเมือง {ColorText("town", "Naver")}",
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Sata,
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("ReceiveTheBook");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 11,
                questName = $"เจรจากับ {ColorText("char", "พ่อค้ายา")}",
                questDescription = $"ไปคุยกับ {ColorText("char", "พ่อค้ายา")} ที่ร้านยาตรงทางเข้าเมือง {ColorText("town", "Naver")} เพื่อรับยาตื่นจากฝัน",
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Villager,
                    type = Quest.Objective.Type.talk,
                    amount = 10,
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 12,
                questName = $"มอบยาให้กับ {ColorText("char", "Sata")}",
                questDescription = $"ไปคุยกับ {ColorText("char", "Sata")} ที่บ้านของ {ColorText("char", "ตา/ยาย")} บริเวณนอกปราสาท",
                MPReward = 500,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Sata,
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 13,
                questName = $"ช่วยเหลือเด็กน้อย",
                questDescription = $"กำจัด {ColorText("monster", "Rachne")} ที่ป่า {ColorText("town", "Rachne")} ซะ",
                MPReward = 1000,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Rachne,
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 14,
                questName = $"พาเด็กกลับเมือง",
                questDescription = $"พาเด็กสู่อ้อมโกดที่อบอุ่นของ ตา/ยาย อีกครั้ง ไปคุยกับ {ColorText("char", "Sata")} เพื่อส่งภารกิจ",
                MPReward = 500,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Sata,
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                compleltedAction = () =>
                {
                    chapterCardScript.ActivateMenu(2);
                },
            }
        );
        //* chapter 2
        questList.Add(
            new Quest()
            {
                questId = 15,
                questName = $"พบแม่ทัพ",
                questDescription = $"ไปพบ {ColorText("char", "Aaron")} กับพวกทหารที่หน้าเมือง {ColorText("town", "Naver")}",
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Aaron,
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
            }
        );
        // questList.Add(
        //     new Quest()
        //     {

        //     }
        // );
        // Debug.LogWarning($"questSize = {questList.Count}");
    }
    private string ColorText(string type, string text)
    {
        return $"<color={COLORS[type]}>{text}</color>";
    }
    private void ActivateTutorialCard(string cardName, bool active)
    {
        TutorialCardObject.transform.Find(cardName).gameObject.SetActive(active);
    }
}
