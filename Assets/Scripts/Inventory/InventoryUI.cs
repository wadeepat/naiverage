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

    public GameObject Player;

    public bool invenIsClose;

    PlayerAttackController attack;
    StarterAssetsInputs assetsInputs;
    PlayerInput playerInput;

    void Start()
    {
        Matarials.SetActive(false);
        Potions.SetActive(false);
        Quests.SetActive(false);

        invenIsClose = true;


        attack = Player.GetComponent<PlayerAttackController>();
        assetsInputs = Player.GetComponent<StarterAssetsInputs>();
        playerInput = Player.GetComponent<PlayerInput>();


        // Inventory.instance;
        // Inventory.onItemChangedCallback += Update;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("i")){
            if(invenIsClose == true){
                //open inventory
                Matarials.SetActive(true);
                Potions.SetActive(true);
                Quests.SetActive(true);
                invenIsClose = false;

                //Stop animetion player
                // Player.SetActive(false);
                // playerInput.enabled = false;
                attack.attackAble = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                assetsInputs.cursorInputForLook = false;
                assetsInputs.cursorLocked = false;
                assetsInputs.look = new Vector2(0,0);

            }else{
                Matarials.SetActive(false);
                Potions.SetActive(false);
                Quests.SetActive(false);
                invenIsClose = true;

                // Player.SetActive(true);
                // playerInput.enabled = true;
                attack.attackAble = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                assetsInputs.cursorInputForLook = true;
                assetsInputs.cursorLocked = true;
            }
        }
    }

    // void UpdateUI()
    // {
    //     Debug.Log("UPDATING UI");
    // }
}
