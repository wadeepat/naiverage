using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static readonly Dictionary<string, string> COLORS = new Dictionary<string, string>(){
        {"button","#900C3F"},
        {"char","#FFD495"},
        {"item","#40FF6F"},
        {"menu","#8EA7E9"},
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

    void Awake()
    {
        AddItemList();
        AddPotionList();
        AddItemQuestList();
        AddSkillbookList();

        magicPearl = new Pearl(0, "Magic Pearl", "None", Resources.Load<Sprite>("Pearl"), 0);
        AddSkillList();
        AddMonsterList();

        //* Quest section
        //* chapter 0
        AddQuestChapter0();
        //* chapter 1
        AddQuestChapter1();
        //* chapter 2
        AddQuestChapter2();
        //* chapter 3
        AddQuestChapter3();
        //* chapter 4
        AddQuestChapter4();
        //* turn back time
        AddQuestTurnBack();
        //* side quest
        AddSidequest();
    }
    private void AddMonsterList()
    {
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
    }
    private void AddSkillList()
    {
        skillList.Add(new Skill(0, " ", " ", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0));
        skillList.Add(new Skill(1, "SK1", "None", Resources.Load<Sprite>("sk1"), 0, false, 1, 0, 1, 500));
        skillList.Add(new Skill(2, "SK2", "None", Resources.Load<Sprite>("sk2"), 0, false, 2, 0, 1, 1000));
        skillList.Add(new Skill(3, "SK3", "None", Resources.Load<Sprite>("sk3"), 0, false, 3, 0, 1, 1500));
        skillList.Add(new Skill(4, "SK4", "None", Resources.Load<Sprite>("sk4"), 0, false, 4, 0, 1, 2000));
        skillList.Add(new Skill(5, "SK5", "None", Resources.Load<Sprite>("sk5"), 0, false, 1, 0, 1, 2500));
        skillList.Add(new Skill(6, "SK6", "None", Resources.Load<Sprite>("sk6"), 0, false, 2, 0, 1, 3000));
        skillList.Add(new Skill(7, "Chicken Wings", "None", Resources.Load<Sprite>("sk7"), 0, false, 3, 0, 1, 3500));
        skillList.Add(new Skill(8, "SK8", "None", Resources.Load<Sprite>("sk8"), 0, false, 4, 0, 1, 4000));
        skillList.Add(new Skill(9, "SK9", "None", Resources.Load<Sprite>("sk9"), 0, false, 4, 0, 1, 4500));
    }
    private void AddSkillbookList()
    {
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
    }
    private void AddItemQuestList()
    {
        itemQuestList.Add(new Item(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        itemQuestList.Add(new Item(1, "Soul", "Quest", Resources.Load<Sprite>("q1"), 0));
        itemQuestList.Add(new Item(2, "Chicken", "Quest", Resources.Load<Sprite>("chick"), 0));
        itemQuestList.Add(new Item(3, "Picture", "Quest", Resources.Load<Sprite>("q3"), 0));
    }
    private void AddPotionList()
    {
        potionList.Add(new Potion(0, "None", "None", Resources.Load<Sprite>("0"), 0, true, 0, 0, 0, 0, 0, 0));
        potionList.Add(new Potion(1, "HP(S)", "Potion", Resources.Load<Sprite>("Potions/p1"), 0, true, 1, 2, 0, 2, 2, 0));
        potionList.Add(new Potion(2, "MP(S)", "Potion", Resources.Load<Sprite>("Potions/p2"), 0, true, 1, 2, 3, 3, 2, 2));
        potionList.Add(new Potion(3, "Flask of Poison", "Potion", Resources.Load<Sprite>("Potions/p3"), 0, true, 1, 4, 0, 4, 3, 0));
        potionList.Add(new Potion(4, "Flask of Illusion", "Potion", Resources.Load<Sprite>("Potions/p4"), 0, true, 1, 2, 5, 4, 3, 2));
        potionList.Add(new Potion(5, "HP(M)", "Potion", Resources.Load<Sprite>("Potions/p5"), 0, true, 2, 6, 0, 6, 3, 0));
        potionList.Add(new Potion(6, "MP(M)", "Potion", Resources.Load<Sprite>("Potions/p6"), 0, true, 2, 7, 0, 6, 3, 0));
        potionList.Add(new Potion(7, "Phial of Freedom", "Potion", Resources.Load<Sprite>("Potions/p7"), 0, true, 3, 8, 0, 5, 2, 0));
        potionList.Add(new Potion(8, "Flask of Agony", "Potion", Resources.Load<Sprite>("Potions/p8"), 0, true, 4, 5, 6, 3, 3, 4));
        potionList.Add(new Potion(9, "Elixir of Rage", "Potion", Resources.Load<Sprite>("Potions/p9"), 0, true, 9, 10, 0, 3, 2, 0));
        potionList.Add(new Potion(10, "HP(L)", "Potion", Resources.Load<Sprite>("Potions/p10"), 0, true, 1, 6, 11, 8, 1, 2));
        potionList.Add(new Potion(11, "MP(L)", "Potion", Resources.Load<Sprite>("Potions/p11"), 0, true, 3, 7, 10, 5, 3, 2));
        potionList.Add(new Potion(12, "Holy water", "Potion", Resources.Load<Sprite>("Potions/p12"), 0, true, 1, 2, 12, 10, 10, 2));
    }
    private void AddItemList()
    {
        itemList.Add(new Item(0, "None", "None", Resources.Load<Sprite>("0"), 0));
        itemList.Add(new Item(1, "Spindlewit", "Item", Resources.Load<Sprite>("1"), 0));
        itemList.Add(new Item(2, "Spin Reef", "Item", Resources.Load<Sprite>("2"), 0));
        itemList.Add(new Item(3, "Glower Hop", "Item", Resources.Load<Sprite>("3"), 0));
        itemList.Add(new Item(4, "Mushroom", "Item", Resources.Load<Sprite>("4"), 0));
        itemList.Add(new Item(5, "Purple Fringeless", "Item", Resources.Load<Sprite>("5"), 0));
        itemList.Add(new Item(6, "Thorn Leaf", "Item", Resources.Load<Sprite>("6"), 0));
        itemList.Add(new Item(7, "Orchid Special", "Item", Resources.Load<Sprite>("7"), 0));
        itemList.Add(new Item(8, "Hosta", "Item", Resources.Load<Sprite>("8"), 0));
        itemList.Add(new Item(9, "Snake Eye", "Item", Resources.Load<Sprite>("9"), 0));
        itemList.Add(new Item(10, "Coleus", "Item", Resources.Load<Sprite>("10"), 0));
        itemList.Add(new Item(11, "Arrowhead Chute", "Item", Resources.Load<Sprite>("11"), 0));
        itemList.Add(new Item(12, "FlyingTree", "Item", Resources.Load<Sprite>("12"), 0));
    }
    private void AddQuestChapter0()
    {
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
                    ActionHandler.instance.chapterCardScript.ActivateMenu(0);
                    ActionHandler.instance.ActivateTutorialCard("Walking", true);
                },
                compleltedAction = () =>
                {
                    ActionHandler.instance.ActivateTutorialCard("Walking", false);
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
                amount = 3,
            },
            addAction = () =>
            {
                ActionHandler.instance.ActivateTutorialCard("PickupItems", true);
            },
            compleltedAction = () =>
            {
                ActionHandler.instance.ActivateTutorialCard("PickupItems", false);
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
                    ActionHandler.instance.ActivateTutorialCard("CraftPotion", true);
                },
                updateAction = () =>
                {
                    if (ActionHandler.PotionPanel.activeSelf)
                    {
                        QuestLog.CompleteQuest(QuestLog.GetActiveQuestById(2));
                    }
                },
                compleltedAction = () =>
                {
                    ActionHandler.instance.ActivateTutorialCard("CraftPotion", false);
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
                    ActionHandler.instance.ActivateTutorialCard("UsePotion", true);
                },
                compleltedAction = () =>
                {
                    InvenSkillBook add = GameObject.Find("Canvas/Panel").transform.Find("Character panel").Find("All funtion").Find("Skill").GetComponent<InvenSkillBook>();
                    add.AddSkillBook(1);
                    add.AddSkillBook(2);
                    add.AddSkillBook(3);
                    ActionHandler.instance.ActivateTutorialCard("UsePotion", false);
                    // DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("CompletedUsePotion"));
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(0, "CompletedUsePotion"));
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
                    ActionHandler.instance.ActivateTutorialCard("NormalAttack", true);
                    StageHandler.instance.EventTrigger("Spawn1Webster");
                },
                compleltedAction = () =>
                {
                    ActionHandler.instance.ActivateTutorialCard("NormalAttack", false);
                    // DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetTutorialFiles("CompletedUsePotion"));
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
                    ActionHandler.instance.ActivateTutorialCard("Skill", true);
                    StageHandler.instance.EventTrigger("Spawn5Webster");
                },
                compleltedAction = () =>
                {
                    ActionHandler.instance.ActivateTutorialCard("Skill", false);
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
                    npc = NPCIndex.Sata,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetDialogueFile(0, "FinishedWebsterQ"),
                    amount = 1,
                },
                addAction = () =>
                {
                    ActionHandler.instance.ActivateTutorialCard("TalkToNPC", true);
                },
                compleltedAction = () =>
                {
                    ActionHandler.instance.ActivateTutorialCard("TalkToNPC", false);
                    StageHandler.instance.EventTrigger("GoToNaver");
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
                    ActionHandler.instance.ActivateTutorialCard("WarpAndMap", true);
                    StageHandler.instance.EventTrigger("CompletedTutorial");
                    StageHandler.instance.EventTrigger("SataLeadToTown");
                },
                prepareAction = () =>
                {
                    QuestLog.CompleteQuest(Database.questList[7]);
                },
                compleltedAction = () =>
                {
                    ActionHandler.instance.ActivateTutorialCard("WarpAndMap", false);
                    ActionHandler.instance.chapterCardScript.ActivateMenu(1);
                },
            }
        );
    }
    private void AddQuestChapter1()
    {
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
                    // if (!ActionHandler.instance.IsQuestIdxInSave(8))
                    StageHandler.instance.EventTrigger("AaronMoveToMainDoor");
                    // if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.Rachne)
                    //     StageHandler.instance.EventTrigger("Spawn10Webster");
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
                    dialogue = DialogueManager.instance.GetDialogueFile(1, "AaronQuest"),
                    amount = 1,
                },
                addAction = () =>
                {
                    if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown)
                        StageHandler.instance.EventTrigger("AaronAtMainDoor");
                },
                prepareAction = () =>
                {
                    // if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown)
                    StageHandler.instance.EventTrigger("AaronAtMainDoor");
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
                addAction = () =>
                {
                    if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown)
                        StageHandler.instance.EventTrigger("ReceiveTheBook");
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
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Villager,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown)
                        StageHandler.instance.EventTrigger("TalkWithMerchant");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("TalkWithMerchant");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 12,
                questName = $"มอบยาให้กับ {ColorText("char", "Sata")}",
                questDescription = $"ไปคุยกับ {ColorText("char", "Sata")} ที่บ้านของ {ColorText("char", "คุณตา")} บริเวณนอกปราสาท",
                location = SceneIndex.NaverTown,
                MPReward = 500,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Sata,
                    dialogue = DialogueManager.instance.GetDialogueFile(1, "WakeUpTheWoman"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("SataAtOldmanHouse");
                    StageHandler.instance.EventTrigger("AbelGoToHouse");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("SataAtOldmanHouse");
                    StageHandler.instance.EventTrigger("AbelAtOldmanHouse");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 13,
                questName = $"ช่วยเหลือเด็กน้อย",
                questDescription = $"กำจัด {ColorText("monster", "Rachne")} ที่ป่า {ColorText("town", "Rachne")} ซะ",
                location = SceneIndex.Rachne,
                MPReward = 1000,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Rachne,
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
                prepareAction = () =>
                {
                    // if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.Rachne)
                    StageHandler.instance.EventTrigger("RachneEntrance");
                },
                compleltedAction = () =>
                {
                    StageHandler.instance.EventTrigger("ExitGate");
                    QuestLog.AddQuest(Database.questList[14]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 14,
                questName = $"พาเด็กกลับเมือง",
                questDescription = $"พาเด็กสู่อ้อมโกดที่อบอุ่นของ {ColorText("char", "ตา")} อีกครั้ง ไปคุยกับ {ColorText("char", "Sata")} เพื่อส่งภารกิจ",
                location = SceneIndex.NaverTown,
                MPReward = 500,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Sata,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetDialogueFile(1, "TakeToHome"),
                    amount = 1,
                },
                // addAction = () =>
                // {
                //     if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown)
                //         StageHandler.instance.EventTrigger("HappyFamily");
                // },
                prepareAction = () =>
                {
                    // if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown)
                    StageHandler.instance.EventTrigger("HappyFamily");
                },
            }
        );
    }
    private void AddQuestChapter2()
    {
        questList.Add(
            new Quest()
            {
                questId = 15,
                questName = $"พบแม่ทัพ",
                questDescription = $"ไปพบ {ColorText("char", "Aaron")} กับพวกทหารที่หน้าเมือง {ColorText("town", "Naver")}",
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Aaron,
                    npc = NPCIndex.Aaron,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "AssembleArmy"),
                    amount = 1,
                },
                addAction = () =>
                {
                    // if (!ActionHandler.instance.IsQuestIdxInSave(15))
                    ActionHandler.instance.chapterCardScript.ActivateMenu(2);
                    if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown)
                    {
                        StageHandler.instance.EventTrigger("AaronAtMainDoor");
                        StageHandler.instance.EventTrigger("Army");
                    }
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("AaronAtMainDoor");
                    StageHandler.instance.EventTrigger("Army");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 16,
                questName = $"เดินทางไปป่า {ColorText("town", "Braewood")}",
                questDescription = $"ตอนนี้ได้เบาะแสของเจ้าชาย {ColorText("char", "Cain")} แล้วเดินทางไปยังป่า {ColorText("town", "Braewood")} กัน",
                location = SceneIndex.BraewoodForest,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)SceneIndex.BraewoodForest,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("UnlockBraewood");
                },
                prepareAction = () =>
                {
                    QuestLog.CompleteQuest(QuestLog.GetActiveQuestById(16));
                },
                compleltedAction = () =>
                {
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(2, "TalkWithGuard"));
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 17,
                questName = $"หาเบาะแสจาก {ColorText("char", "ชาวบ้าน")}",
                questDescription = $"ต้องทำตัวให้กลมกลืน และสืบหาเบาะแสเกี่ยวกับเจ้าชาย {ColorText("char", "Cain")} ลองถาม {ColorText("char", "ชาวบ้าน")} ดู",
                location = SceneIndex.BraewoodForest,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Villager,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.BraewoodForest)
                        StageHandler.instance.EventTrigger("VillagersHint");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("VillagersHint");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 18,
                questName = $"คุยกับ {ColorText("char", "ยาม")}",
                questDescription = $"{ColorText("char", "ชาวบ้าน")} บอกว่ายามน่าจะรู้อะไรบางอย่าง  ลองถาม {ColorText("char", "ยาม")} ตรงทางเข้าป่าดู",
                location = SceneIndex.BraewoodForest,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Villager,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.BraewoodForest)
                        StageHandler.instance.EventTrigger("GuardHint");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("GuardHint");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 19,
                questName = $"ตามหาเจ้าชาย {ColorText("char", "Cain")}",
                questDescription = $"เจ้าชาย {ColorText("char", "Cain")} อยู่ในถ้ำอย่างนั้นเหรอ ลองไปสำรวจดูละกัน",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)SceneIndex.Cave,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("UnlockCave");
                },
                prepareAction = () =>
                {
                    QuestLog.CompleteQuest(Database.questList[19]);
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 20,
                questName = $"กำจัดผู้รุกราน(1/2)",
                questDescription = $"ในถ้ำมีมอนสเตอร์ประหลาดอยู่กำจัดให้หมด แล้วไปหาเจ้าชาย {ColorText("char", "Cain")}",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Skeleton,
                    type = Quest.Objective.Type.kill,
                    amount = 5,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("AggressiveMon");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("AggressiveMon");
                },
                compleltedAction = () =>
                {
                    QuestLog.AddQuest(questList[21]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 21,
                questName = $"กำจัดผู้รุกราน(2/2)",
                questDescription = $"หมู่บ้านคงจะปลอดภัยแล้ว ไปหาเจ้าชาย {ColorText("char", "Cain")}",
                location = SceneIndex.Cave,
                MPReward = 500,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "HelpCainComplete"),
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("CainAtFront");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("CainAtFront");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 22,
                questName = $"กลับไปยังหมู่บ้าน",
                questDescription = $"เจ้าชาย {ColorText("char", "Cain")} ดูเหนื่อย ๆ นะกลับไปพักกันก่อนดีกว่า ไปหา {ColorText("char", "Cain")} ที่ป่า {ColorText("town", "Braewood")}",
                location = SceneIndex.BraewoodForest,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "PrinceAndVillagers"),
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("HelpHisFriend");
                    // QuestLog.CompleteQuest(questList[22]);
                },
                // compleltedAction = () =>
                // {
                //     StageHandler.instance.EventTrigger("HelpHisFriend");
                // },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 23,
                questName = $"ชายหนุ่มที่หายไป",
                questDescription = $"เข้าไปสำรวจในถ้ำแล้วหาตัว {ColorText("char", "ชายหนุ่ม")} ที่หายไป",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)SceneIndex.Cave,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("LostMan");
                },
                // compleltedAction = () =>
                // {
                //     StageHandler.instance.EventTrigger("LostMan");
                // },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 24,
                questName = $"กำจัด Troll",
                questDescription = $"สถานการณ์ไม่ดีนัก ต้องไปจัดการ {ColorText("monster", "Troll")} เพื่อช่วยเหลือ {ColorText("char", "ชายหนุ่ม")} ข้างในนั้นมีประตูลับซ่อนอยู่",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Troll,
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("TrollEntrance");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("TrollEntrance");
                },
                compleltedAction = () =>
                {

                    StageHandler.instance.EventTrigger("ExitGate");
                    QuestLog.AddQuest(questList[25]);
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 25,
                questName = $"กลับไปดู {ColorText("char", "ชายหนุ่ม")}",
                questDescription = $"{ColorText("monster", "Troll")} ถูกจัดการเรียบร้อยแล้ว กลับไปหา{ColorText("char", "ชายหนุ่ม")} ใน {ColorText("town", "Cave")} กันเถอะ",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "SaveTheManLife"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    //! remove when implement troll field
                    StageHandler.instance.EventTrigger("CainAndHurt");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("CainAndHurt");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 26,
                questName = $"กลับไปหา {ColorText("char", "Cain")}",
                questDescription = $"ดูเหมือนเจ้าชาย {ColorText("char", "Cain")} จะช่วยชายหนุ่มออกไปแล้ว กลับไปที่ป่า {ColorText("town", "Braewood")} แล้วคุยกับเจ้าชาย {ColorText("char", "Cain")} เพื่อรับรางวัลกันเถอะ",
                location = SceneIndex.BraewoodForest,
                MPReward = 1000,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "BackToFriend"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("TheManIsSaved");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 27,
                questName = $"พา {ColorText("char", "Cain")} กลับเมือง",
                questDescription = $"เดินทางกลับเมือง {ColorText("town", "Naver")} ไปกับเจ้าชาย {ColorText("char", "Cain")}",
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    dialogue = DialogueManager.instance.GetDialogueFile(3, "WelcomeCain"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("CainGoToNaver");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("WelcomeCain");
                    // QuestLog.CompleteQuest(questList[27]);
                },
            }
        );
    }
    private void AddQuestChapter3()
    {
        questList.Add(
            new Quest()
            {
                questId = 28,
                questName = $"ไปยังปราสาท",
                questDescription = $"ตามเจ้าชาย {ColorText("char", "Cain")} ไปยังปราสาท {ColorText("town", "Calford")}",
                // location = SceneIndex.CalfordCastle,
                location = SceneIndex.CalfordCastle,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    //! fix this when implemented castle
                    // objectiveId = (int)SceneIndex.CalfordCastle,
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    dialogue = DialogueManager.instance.GetDialogueFile(3, "FamilyMeeting"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActionHandler.instance.chapterCardScript.ActivateMenu(3);
                    StageHandler.instance.EventTrigger("UnlockCalford");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("Family");
                },
            }
        );
    }
    private void AddQuestChapter4()
    {
        questList.Add(
            new Quest()
            {
                questId = 29,
                questName = $"บัญญัติที่ถูกเก็บซ่อน",
                questDescription = $"{ColorText("char", "Samuel")} ได้บอกว่าบัญญัติอยู่ในที่อยู่ของ {ColorText("monster", "Rachne")} ตามเขาไปพร้อมกับคนอื่น ๆ",
                location = SceneIndex.RachneField,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Samuel,
                    npc = NPCIndex.Samuel,
                    dialogue = DialogueManager.instance.GetDialogueFile(4, "TheCommandment"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActionHandler.instance.chapterCardScript.ActivateMenu(4);
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("Commanment");
                },
            }
        );
    }
    private void AddQuestTurnBack()
    {
        questList.Add(
            new Quest()
            {
                questId = 30,
                questName = $"ช่วยเหลือเด็กน้อยอีกครั้ง",
                questDescription = $"กำจัด {ColorText("monster", "Rachne")} ที่ป่า {ColorText("town", "Rachne")} ซะ",
                location = SceneIndex.Rachne,
                MPReward = 1000,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Rachne,
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActionHandler.instance.chapterCardScript.ActivateMenu(5);
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("RachneEntrance");
                },
                compleltedAction = () =>
                {
                    StageHandler.instance.EventTrigger("ExitGate");
                    QuestLog.AddQuest(Database.questList[31]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 31,
                questName = $"พาเด็กกลับเมืองอีกครั้ง",
                questDescription = $"พาเด็กสู่อ้อมโกดที่อบอุ่นของ {ColorText("char", "ตา")} อีกครั้ง ไปคุยกับ {ColorText("char", "Sata")} เพื่อส่งภารกิจ",
                location = SceneIndex.NaverTown,
                MPReward = 500,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Sata,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetDialogueFile(1, "TakeToHomeAgain"),
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("HappyFamily");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 32,
                questName = $"พบแม่ทัพอีกครั้ง",
                questDescription = $"ไปพบ {ColorText("char", "Aaron")} กับพวกทหารที่หน้าเมือง {ColorText("town", "Naver")}",
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Aaron,
                    npc = NPCIndex.Aaron,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "AssembleArmyAgain"),
                    amount = 1,
                },
                addAction = () =>
                {
                    ActionHandler.instance.chapterCardScript.ActivateMenu(6);
                    if (StageHandler.instance.activeSceneIndex == (int)SceneIndex.NaverTown)
                    {
                        StageHandler.instance.EventTrigger("AaronAtMainDoor");
                        StageHandler.instance.EventTrigger("Army");
                    }
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("AaronAtMainDoor");
                    StageHandler.instance.EventTrigger("Army");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 33,
                questName = $"ไปหาเจ้าชาย {ColorText("char", "Cain")}",
                questDescription = $"เจ้ารู้อยู่แล้วว่าเจ้าชาย {ColorText("char", "Cain")} อยู่ในถ้ำ ไปหาเขากันเลย",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)SceneIndex.Cave,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("UnlockBraewood");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("FirstMetCain");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 34,
                questName = $"กำจัดกลุ่มโจร(1/2)",
                questDescription = $"ในถ้ำมีโจรจะมารุกรานหมู่บ้านกำจัดให้หมด แล้วไปหาเจ้าชาย {ColorText("char", "Cain")}",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Bandit,
                    type = Quest.Objective.Type.kill,
                    amount = 5,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("AggressiveMon");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("AggressiveMon");
                },
                compleltedAction = () =>
                {
                    QuestLog.AddQuest(questList[35]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 35,
                questName = $"กำจัดกลุ่มโจร(2/2)",
                questDescription = $"หมู่บ้านคงจะปลอดภัยแล้ว ไปหาเจ้าชาย {ColorText("char", "Cain")}",
                location = SceneIndex.Cave,
                MPReward = 500,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    type = Quest.Objective.Type.talk,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "HelpCainCompleteAgain"),
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("CainAtFront");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("CainAtFront");
                },
            }
        );

        questList.Add(
            new Quest()
            {
                questId = 36,
                questName = $"ชายหนุ่มที่หายไปอีกครั้ง",
                questDescription = $"เข้าไปสำรวจในถ้ำแล้วหาตัว {ColorText("char", "ชายหนุ่ม")} ที่หายไป",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)SceneIndex.Cave,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("LostMan");

                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("LostMan");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 37,
                questName = $"กำจัด Troll",
                questDescription = $"สถานการณ์ไม่ดีนัก ต้องไปจัดการ {ColorText("monster", "Troll")} เพื่อช่วยเหลือ {ColorText("char", "ชายหนุ่ม")} ข้างในนั้นมีประตูลับซ่อนอยู่",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Troll,
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("TrollEntrance");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("TrollEntrance");
                },
                compleltedAction = () =>
                {
                    StageHandler.instance.EventTrigger("ExitGate");
                    QuestLog.AddQuest(questList[38]);
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 38,
                questName = $"กลับไปดู {ColorText("char", "ชายหนุ่ม")}",
                questDescription = $"{ColorText("monster", "Troll")} ถูกจัดการเรียบร้อยแล้ว กลับไปหา{ColorText("char", "ชายหนุ่ม")} ใน {ColorText("town", "Cave")} กันเถอะ",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "SaveTheManLifeAgain"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    //! remove when implement troll field
                    StageHandler.instance.EventTrigger("CainAndHurt");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("CainAndHurt");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 39,
                questName = $"กลับไปหา {ColorText("char", "Cain")}",
                questDescription = $"เจ้าชาย {ColorText("char", "Cain")} ได้ช่วยชายหนุ่มออกไปแล้ว กลับไปที่ป่า {ColorText("town", "Braewood")} แล้วคุยกับเจ้าชาย {ColorText("char", "Cain")} เพื่อรับรางวัลกันเถอะ",
                location = SceneIndex.BraewoodForest,
                MPReward = 1000,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    dialogue = DialogueManager.instance.GetDialogueFile(2, "BackToFriendAgain"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("TheManIsSaved");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 40,
                questName = $"พา {ColorText("char", "Cain")} กลับเมือง",
                questDescription = $"เดินทางกลับเมือง {ColorText("town", "Naver")} ไปกับเจ้าชาย {ColorText("char", "Cain")}",
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    dialogue = DialogueManager.instance.GetDialogueFile(3, "WelcomeCainAgain"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("CainGoToNaver");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("WelcomeCain");
                    // QuestLog.CompleteQuest(questList[27]);
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 41,
                questName = $"ไปยังปราสาท",
                questDescription = $"ตามเจ้าชาย {ColorText("char", "Cain")} ไปยังปราสาท {ColorText("town", "Calford")}",
                location = SceneIndex.CalfordCastle,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Cain,
                    npc = NPCIndex.Cain,
                    dialogue = DialogueManager.instance.GetDialogueFile(3, "FamilyMeetingAgain"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActionHandler.instance.chapterCardScript.ActivateMenu(7);
                    StageHandler.instance.EventTrigger("UnlockCalford");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("Family");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 42,
                questName = $"ค้นหาสิ่งที่ถูกซ่อนไว้",
                questDescription = $"{ColorText("char", "The Book")} ได้บอกว่ามีอะไรบางอย่างดูแถวนี้ ลองสำรวจปราสาท {ColorText("town", "Calford")} ดู",
                location = SceneIndex.CalfordCastle,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = 1,
                    isQuestItem = true,
                    // npc = NPCIndex.Samuel,
                    // dialogue = DialogueManager.instance.GetDialogueFile(4, "TheCommandment"),
                    type = Quest.Objective.Type.collect,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("TheSoul");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("TheSoul");
                },
                compleltedAction = () =>
                {
                    QuestLog.AddQuest(questList[43]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 43,
                questName = $"บัญญัติที่แท้จริง",
                questDescription = $"เจ้าได้ดวงจิตมาแล้วไปหา {ColorText("char", "Samuel")} กับคนอื่น ๆ ที่ที่อยู่ของ {ColorText("monster", "Rachne")} กัน",
                location = SceneIndex.RachneField,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Samuel,
                    npc = NPCIndex.Samuel,
                    dialogue = DialogueManager.instance.GetDialogueFile(4, "FoundTheSoul"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                addAction = () =>
                {
                    ActionHandler.instance.chapterCardScript.ActivateMenu(8);
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("Commanment");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 44,
                questName = $"ต่อสู้กับ {ColorText("char", "Abel")}",
                questDescription = $"เจ้าเลือกที่จะช่วยเหลือ {ColorText("char", "Cain")} ดังนั้นต่อสู่กับ {ColorText("char", "Abel")} เพื่อช่วยเหลือเขา",
                location = SceneIndex.TrollField,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Abel,
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("Abel");
                },
                compleltedAction = () =>
                {
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(4, "DefeatAbel"));
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 45,
                questName = $"ต่อสู้กับ {ColorText("char", "Cain")}",
                questDescription = $"เจ้าเลือกที่จะช่วยเหลือ {ColorText("char", "Abel")} ดังนั้นต่อสู่กับ {ColorText("char", "Cain")} เพื่อช่วยเหลือเขา",
                location = SceneIndex.TrollField,
                MPReward = 0,
                SBReward = "",
                questCategory = 0,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Cain,
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("Cain");
                },
                compleltedAction = () =>
                {
                    DialogueManager.instance.EnterDialogueMode(DialogueManager.instance.GetDialogueFile(4, "DefeatCain"));
                }
            }
        );
    }
    private void AddSidequest()
    {
        //sidequest idx start from 46
        questList.Add(
            new Quest()
            {
                questId = 46,
                questName = $"ชื่อเควส {ColorText("char", "")}",
                questDescription = $"คำอธิบาย {ColorText("char", "")}",
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Cain,
                    //สำหรับเควสให้คุย
                    //npc = NPCIndex.Sata,
                    // dialogue = DialogueManager.instance.GetDialogueFile(6,"ชื่อไฟล์ Dialogue"),
                    type = Quest.Objective.Type.kill,
                    amount = 1,
                },
                addAction = () =>
                {
                    //หลังจาก add quest จะทำ
                },
                prepareAction = () =>
                {
                    //เมื่อผู้เล่นอยู่ที่ location นั้นๆ จะทำ
                    // StageHandler.instance.EventTrigger(ชื่อเหนุ);
                },
                compleltedAction = () =>
                {
                    //ทำเมื่อเสร็จเควส
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 47,
                questName = $"ไก่เจ้าปัญหา (1/2)",
                questDescription = $"{ColorText("char", "ชาวบ้าน")} กำลังวุ่นวายกับการจับเจ้าไก่เจ้าปัญหาในป่า {ColorText("town", "Rachne")} ช่วยเขาจับไก่แล้วนำกลับมา",
                location = SceneIndex.Rachne,
                MPReward = 0,
                SBReward = "",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = 2,
                    isQuestItem = true,
                    type = Quest.Objective.Type.collect,
                    amount = 6,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("RunChickenRun");
                },
                compleltedAction = () =>
                {
                    QuestLog.AddQuest(questList[48]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 48,
                questName = $"ไก่เจ้าปัญหา (2/2)",
                questDescription = $"นำไก่เหล่านี้ไปให้ {ColorText("char", "ชาวนา")}",
                location = SceneIndex.NaverTown,
                MPReward = 0,
                SBReward = "",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Farmer,
                    npc = NPCIndex.Farmer,
                    dialogue = DialogueManager.instance.GetDialogueFile(5, "ThanksFromFarmer"),
                    type = Quest.Objective.Type.talk,
                    amount = 1,
                },
                compleltedAction = () =>
                {
                    InvenSkillBook add = GameObject.Find("Canvas/Panel").transform.Find("Character panel").Find("All funtion").Find("Skill").GetComponent<InvenSkillBook>();
                    add.AddSkillBook(7);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 49,
                questName = $"ช่วยเหลือ {ColorText("char", "ชาวบ้าน")} (1/2)",
                questDescription = $"{ColorText("char", "ชาวบ้าน")} คนหนึ่งกำลังโดนเหล่ามอนสเตอร์รุมทำร้ายที่ป่า {ColorText("town", "Rachne")} ปราบศัตรูให้หมด และให้ชาวบ้านมีชีวิตรอด",
                location = SceneIndex.Rachne,
                MPReward = 0,
                SBReward = "",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Villager,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("SaveNPC");
                },
                compleltedAction = () =>
                {
                    QuestLog.AddQuest(questList[50]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 50,
                questName = $"ช่วยเหลือ {ColorText("char", "ชาวบ้าน")} (2/2)",
                questDescription = $"{ColorText("char", "ชาวบ้าน")} ปลอดภัยแล้วไปคุยกับเขาที่ป่า {ColorText("town", "Rachne")}",
                location = SceneIndex.Rachne,
                MPReward = 1000,
                SBReward = "",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Villager,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("ThanksFromNPC");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("ThanksFromNPC");
                },
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 51,
                questName = $"รูปแห่งความทรงจำ (1/2)",
                questDescription = $"ตามหารูป และประกอบให้เสร็จสมบูรณ์ที่ป่า {ColorText("town", "Braewood")}",
                location = SceneIndex.BraewoodForest,
                MPReward = 0,
                SBReward = "",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = 3,
                    isQuestItem = true,
                    type = Quest.Objective.Type.collect,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("Flip");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("Flip");
                },
                compleltedAction = () =>
                {
                    QuestLog.AddQuest(questList[52]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 52,
                questName = $"รูปแห่งความทรงจำ (2/2)",
                questDescription = $"นำรูปไปมอบให้{ColorText("char", "ยาม")} ที่เหน็ดเหนื่อยจากการทำงาน ที่ป่า {ColorText("town", "Braewood")}",
                location = SceneIndex.BraewoodForest,
                MPReward = 1500,
                SBReward = "",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Villager,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("ThanksFromGuard");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("ThanksFromGuard");
                }
            }
            
        );
        questList.Add(
            new Quest()
            {
                questId = 53,
                questName = $"กำจัด {ColorText("monster", "Skeleton")} ให้ยามที่เหนื่อย (1/2)",
                questDescription = $"ยามที่เหน็ดเหนื่อยจากการทำงาน ได้มอบหมายงานให้กำจัด{ColorText("monster", "Skeleton")}",
                location = SceneIndex.Cave,
                MPReward = 0,
                SBReward = "",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)MonsterId.Skeleton,
                    type = Quest.Objective.Type.kill,
                    amount = 10,
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("FightForGuard");
                },
                compleltedAction = () =>
                {
                    QuestLog.AddQuest(questList[54]);
                }
            }
        );
        questList.Add(
            new Quest()
            {
                questId = 54,
                questName = $"กำจัด {ColorText("monster", "Skeleton")} ให้ยามที่เหนื่อย (2/2)",
                questDescription = $"ไปคุยกับ {ColorText("char", "ยาม")} ที่เหน็ดเหนื่อยจากการทำงาน ที่ป่า {ColorText("town", "Rachne")}",
                location = SceneIndex.BraewoodForest,
                MPReward = 500,
                SBReward = "สกิลสุดพิเศษ",
                questCategory = 1,
                objective = new Quest.Objective()
                {
                    objectiveId = (int)NPCIndex.Villager,
                    type = Quest.Objective.Type.interact,
                    amount = 1,
                },
                addAction = () =>
                {
                    StageHandler.instance.EventTrigger("ThanksFromGuard");
                },
                prepareAction = () =>
                {
                    StageHandler.instance.EventTrigger("ThanksFromGuard");
                },
                compleltedAction = () =>
                {
                    InvenSkillBook add = GameObject.Find("Canvas/Panel").transform.Find("Character panel").Find("All funtion").Find("Skill").GetComponent<InvenSkillBook>();
                    add.AddSkillBook(8);
                }
            }
            
        );
    }
    private string ColorText(string type, string text)
    {
        return $"<color={COLORS[type]}>{text}</color>";
    }
}
