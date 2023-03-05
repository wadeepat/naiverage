using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
using UnityEngine.InputSystem;
public class OpenUI : MonoBehaviour
{
    // Start is called before the first frame update
    // Inventory inventory;
    public GameObject Panel;
    public GameObject CharacterPanel;
    public GameObject Character;
    public GameObject Potion;
    public GameObject Skill;
    public GameObject Quest;
    [SerializeField] private GameObject Status;
    [SerializeField] private GameObject UpgradeStatus;


    private GameObject Player;

    public bool inven;

    PlayerAttackController attack;
    StarterAssetsInputs assetsInputs;
    PlayerInput playerInput;

    SwitchInventory switchInv;
    LearningSkills learnSkill;
    Crafting craftPotion;
    private void OnEnable()
    {
        Debug.Log("on enable");
        Panel = GameObject.Find("Canvas/Panel");
        CharacterPanel = Panel.transform.Find("Character panel").gameObject;
        Character = CharacterPanel.transform.Find("All funtion/Character").gameObject;
        Potion = CharacterPanel.transform.Find("All funtion/Potion").gameObject;
        Skill = CharacterPanel.transform.Find("All funtion/Skill").gameObject;
        Quest = CharacterPanel.transform.Find("All funtion/Quest").gameObject;
        Status = CharacterPanel.transform.Find("All funtion/Character/Left/Status/Status menu").gameObject;
        UpgradeStatus = CharacterPanel.transform.Find("All funtion/Character/Left/Status/Upgrade status").gameObject;
        learnSkill = Skill.GetComponent<LearningSkills>();
        craftPotion = Panel.GetComponent<Crafting>();
        inven = true;
        show(false);
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != (int)SceneIndex.BlackScene)
        {
            Player = PlayerManager.instance.player;
            attack = Player.GetComponent<PlayerAttackController>();
            assetsInputs = Player?.GetComponent<StarterAssetsInputs>();
            playerInput = Player.GetComponent<PlayerInput>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool i = Input.GetKeyDown("i");
        if (i)
        {
            if (GameObject.Find("Canvas")?.transform.Find("LoadingScreen")?.gameObject.activeSelf == true) return;

            if (DialogueManager.dialogueIsPlaying ||
            ActionHandler.instance.IsSomeWindowsActivated())
            {
                if (inven == false)
                {
                    AudioManager.instance.Play("open");
                    //close
                    inven = true;
                    show(false);
                    DialogueManager.dialogueIsPlaying = false;
                    Lockscreen(false);
                }
            }
            else
            {
                //open 
                AudioManager.instance.Play("open");
                inven = false;
                show(true);
                DialogueManager.dialogueIsPlaying = true;
                Lockscreen(true);
            }
        }
        if (inven == false &&
            InputManager.instance.GetBackPressed()
            )
        {
            InputManager.instance.GetMenuPressed();
            //close
            AudioManager.instance.Play("open");
            inven = true;
            show(false);
            DialogueManager.dialogueIsPlaying = false;
            Lockscreen(false);
        }
    }
    void Lockscreen(bool l)
    {
        // Stop animetion player
        // Player.SetActive(false);
        // playerInput.enabled = false;
        if (l == true)
        {
            // Player.SetActive(false);
            PlayerManager.instance.player.GetComponent<PlayerAttackController>().attackAble = false;
            // attack.attackAble = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            assetsInputs.cursorInputForLook = false;
            assetsInputs.cursorLocked = false;
            assetsInputs.look = new Vector2(0, 0);
        }
        else
        {
            // Player.SetActive(true);
            PlayerManager.instance.player.GetComponent<PlayerAttackController>().attackAble = true;
            // attack.attackAble = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            assetsInputs.cursorInputForLook = true;
            assetsInputs.cursorLocked = true;
        }

    }
    public void show(bool i)
    {
        CharacterPanel.SetActive(i);
        Character.SetActive(i);
        Status.SetActive(true);
        UpgradeStatus.SetActive(false);
        Potion.SetActive(false);
        Skill.SetActive(false);
        Quest.SetActive(false);

    }
    public void showCharacter()
    {
        CharacterPanel.SetActive(true);
        Character.SetActive(true);
        Potion.SetActive(false);
        Skill.SetActive(false);
        Quest.SetActive(false);
    }
    public void showPotion()
    {
        CharacterPanel.SetActive(true);
        Character.SetActive(false);
        Potion.SetActive(true);
        craftPotion.SetDefault();
        Skill.SetActive(false);
        Quest.SetActive(false);
        Panel.transform.GetComponent<Potions>().UpdateSlot();
    }
    public void showSkill()
    {
        CharacterPanel.SetActive(true);
        Character.SetActive(false);
        Potion.SetActive(false);
        Skill.SetActive(true);
        learnSkill.SetDefault();
        Quest.SetActive(false);
    }

    public void showQuest()
    {
        
        CharacterPanel.SetActive(true);
        Character.SetActive(false);
        Potion.SetActive(false);
        Skill.SetActive(false);
        Quest.SetActive(true);
        Panel.transform.GetComponent<ItemQuests>().UpdateSlotSprite();
    }

}
