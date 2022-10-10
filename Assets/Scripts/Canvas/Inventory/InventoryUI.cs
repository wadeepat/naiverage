using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    // Inventory inventory;
    public GameObject Matarials;
    public GameObject Potions;
    public GameObject Quests;

    public GameObject Crafting;

    public GameObject Player;

    public bool inven;
    public bool craft;


    PlayerAttackController attack;
    StarterAssetsInputs assetsInputs;
    PlayerInput playerInput;

    void Start()
    {
        showInventory(false);
        showCraft(false);

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
        bool o = Input.GetKeyDown("o");
        if(i){
            if(inven == true){
                //open 
                showInventory(true);               
                inven = false;
            }else{
                showInventory(false);
                inven = true;
                
            }
        }

        if(o){
            if(craft == true){
                //open 
                showCraft(true);               
                craft = false;
            }else{
                showCraft(false);
                craft = true;
            }
        }

        if(!inven || !craft){
            Lockscreen(true);
        }else{
            Lockscreen(false);
        }
    }
    void Lockscreen(bool l){
        //Stop animetion player
        // Player.SetActive(false);
        // playerInput.enabled = false;
        if(l == true){
            attack.attackAble = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            assetsInputs.cursorInputForLook = false;
            assetsInputs.cursorLocked = false;
            assetsInputs.look = new Vector2(0,0);
        }else{
            attack.attackAble = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            assetsInputs.cursorInputForLook = true;
            assetsInputs.cursorLocked = true;
        }
        
    }

    void showInventory(bool i){
        Matarials.SetActive(i);
        Potions.SetActive(i);
        Quests.SetActive(i);
    }

    void showCraft(bool o){
        Crafting.SetActive(o);
    }

}
