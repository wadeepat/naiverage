using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class UsePotions : MonoBehaviour
{
    private GameObject Player, Panel, SlotPotion, positionP;
    private bool l;
    //TODO implement for other potions
    public delegate void OnUsePotion();
    public static OnUsePotion onUsePotion;
    Potions potions;
    PlayerStatus player;
    PlayerAttackController attack;
    StarterAssetsInputs assetsInputs;
    void Start()
    {
        Panel = GameObject.Find("Canvas/Panel");
        Player = GameObject.Find("Player");
        SlotPotion = GameObject.Find("Canvas/Panel/Slot potion");
        positionP = GameObject.Find("Canvas/Panel/PositionP");
        potions = Panel.GetComponent<Potions>();
        player = Player?.GetComponent<PlayerStatus>();
        attack = player?.GetComponent<PlayerAttackController>();
        assetsInputs = player?.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.GetUsePotionPressed())
        {
            UsePotionT(0);
        }
        else if (InputManager.instance.GetSelectingPotion())
        {
            SelectPotion();
        }
        else
        {
            if (l)
            {
                attack.attackAble = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                assetsInputs.cursorInputForLook = true;
                assetsInputs.cursorLocked = true;
                SlotPotion.gameObject.transform.position = positionP.gameObject.transform.position;
                l = false;
            }
        }


    }

    public void UsePotionT(int slot)
    {
        if (potions.slotP[slot] != -1)
        {
            AudioManager.instance.Play("usePotion");
            int skillId = potions.yourPotions[potions.slotP[slot]].id;
            Panel.GetComponent<Potions>().UpdateSlot();
            switch (skillId)
            {
                case 1:
                    PlayerStatus.HealthHP(20);
                    break;
                case 2:
                    PlayerStatus.GetMP(20);
                    break;
                case 3:
                    LaunchProjectile.FlaskOfPoison();
                    break;
                case 4:
                    LaunchProjectile.FlaskOfIllusion();
                    break;
                case 5:
                    GetComponent<PlayerStatus>().PhialOfFreedom();
                    break;
                case 6:
                    PlayerStatus.HealthHP(50);
                    break;
                case 7:
                    PlayerStatus.GetMP(50);
                    break;
                case 8:
                    LaunchProjectile.FlaskOfAgony();
                    break;
                case 9:
                    GetComponent<PlayerStatus>().ElixirOfRage();
                    break;
                case 10:
                    PlayerStatus.HealthHP(100);
                    break;
                case 11:
                    PlayerStatus.GetMP(100);
                    break;
                case 12:
                    PlayerStatus.MaxHPnMP();
                    break;
            }
            potions.slotStack[potions.slotP[slot]] -= 1;
            if (potions.slotStack[potions.slotP[slot]] == 0)
            {
                potions.yourPotions[potions.slotP[slot]] = Database.potionList[0];
                potions.slotStack[potions.slotP[slot]] = 0;
                potions.slotP[slot] = -1;
                potions.slot[slot].sprite = potions.slotSprite[0];
            }
        }
        onUsePotion?.Invoke();
    }

    void SelectPotion()
    {
        l = true;
        attack.attackAble = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        assetsInputs.cursorInputForLook = false;
        assetsInputs.cursorLocked = false;
        assetsInputs.look = new Vector2(0, 0);
        SlotPotion.gameObject.transform.position = new Vector2(Screen.width / 2 + 50, Screen.height / 2 - 50);
    }


}
