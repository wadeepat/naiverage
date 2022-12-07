using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
public class OpenUI : MonoBehaviour
{
    // Start is called before the first frame update
    // Inventory inventory;
    public GameObject Panel;
    public GameObject Character;
    public GameObject Potion;
    public GameObject Skill;
    public GameObject Quest;
    [SerializeField] private GameObject Status;
    [SerializeField] private GameObject UpgradeStatus;


    public GameObject Player;

    public bool inven;
    public bool craft;


    PlayerAttackController attack;
    StarterAssetsInputs assetsInputs;
    PlayerInput playerInput;

    SwitchInventory switchInv;
    void Start()
    {
        show(false);

        inven = true;
        craft = true;
        attack = Player.GetComponent<PlayerAttackController>();
        assetsInputs = Player.GetComponent<StarterAssetsInputs>();
        playerInput = Player.GetComponent<PlayerInput>();


    }

    // Update is called once per frame
    void Update()
    {
        bool i = Input.GetKeyDown("i");
        if (i)
        {
            if (inven == true)
            {
                //open 
                show(true);
                Lockscreen(true);
                inven = false;
            }
            else
            {
                show(false);
                Lockscreen(false);
                inven = true;

            }
        }
    }
    void Lockscreen(bool l)
    {
        //Stop animetion player
        // Player.SetActive(false);
        // playerInput.enabled = false;
        if (l == true)
        {
            // Player.SetActive(false);
            attack.attackAble = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            assetsInputs.cursorInputForLook = false;
            assetsInputs.cursorLocked = false;
            assetsInputs.look = new Vector2(0, 0);
        }
        else
        {
            // Player.SetActive(true);
            attack.attackAble = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            assetsInputs.cursorInputForLook = true;
            assetsInputs.cursorLocked = true;
        }

    }
    public void show(bool i)
    {
        Panel.SetActive(i);
        Character.SetActive(i);
        Status.SetActive(true);
        UpgradeStatus.SetActive(false);
        Potion.SetActive(false);
        Skill.SetActive(false);
        Quest.SetActive(false);
    }
    public void showCharacter()
    {
        Panel.SetActive(true);
        Character.SetActive(true);
        Potion.SetActive(false);
        Skill.SetActive(false);
        Quest.SetActive(false);
    }
    public void showPotion()
    {
        Panel.SetActive(true);
        Character.SetActive(false);
        Potion.SetActive(true);
        Skill.SetActive(false);
        Quest.SetActive(false);
    }
    public void showSkill()
    {
        Panel.SetActive(true);
        Character.SetActive(false);
        Potion.SetActive(false);
        Skill.SetActive(true);
        Quest.SetActive(false);
    }

    public void showQuest()
    {
        Panel.SetActive(true);
        Character.SetActive(false);
        Potion.SetActive(false);
        Skill.SetActive(false);
        Quest.SetActive(true);
    }

}
