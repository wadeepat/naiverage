using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";
    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [Header("Clear Data Button")]
    [SerializeField] private Button clearBtn;
    public bool hasData { get; private set; } = false;
    private Button saveSlotBtn;
    private void Awake()
    {
        saveSlotBtn = this.GetComponent<Button>();
    }
    public void SetData(GameData data)
    {
        if (data == null)
        {
            hasData = false;
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            clearBtn.interactable = false;
        }
        else
        {
            hasData = true;
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            clearBtn.interactable = true;
        }
    }

    public string GetProfileId()
    {
        return profileId;
    }
    public void SetInteractable(bool interactable)
    {
        saveSlotBtn.interactable = interactable;

        if (interactable)
        {
            clearBtn.interactable = hasData;
        }
        else
        {
            clearBtn.interactable = interactable;
        }

    }
}
