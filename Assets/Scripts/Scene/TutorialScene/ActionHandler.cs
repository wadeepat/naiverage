using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour, IDataPersistence
{
    [Header("Conponents")]
    [SerializeField] private InputTextUI UI_Input_Window;
    private string playerName;
    public static ActionHandler instance;
    private void Awake()
    {
        instance = this;
    }
    public void ReceiveAction(string action)
    {
        if (action == "GetPlayerName")
        {
            GetPlayerName();
        }
    }
    public bool IsInputWindowActivated()
    {
        return UI_Input_Window.IsActivated();
    }
    private void GetPlayerName()
    {
        UI_Input_Window.ActivateMenu(
            "เจ้าชื่ออะไร",
            (string inputValue) =>
            {
                if (inputValue != "") playerName = inputValue;

                Debug.Log("name = " + playerName);
            },
            () =>
            {

            }
        );
    }

    public void LoadData(GameData data)
    {
        playerName = data.name;
    }

    public void SaveData(GameData data)
    {
        data.name = playerName;
    }
}
