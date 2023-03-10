using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ConfirmationPopupMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI displayTest;
    [SerializeField] private Button confirmBtn;
    [SerializeField] private Button cancelBtn;

    public bool IsActivated()
    {
        return this.gameObject.activeSelf;
    }
    private void Update()
    {
        if (InputManager.instance.GetBackPressed() && cancelBtn.gameObject.activeSelf) cancelBtn.onClick.Invoke();
        else if (InputManager.instance.GetSubmitPressed()) confirmBtn.onClick.Invoke();
    }
    public void ActivateMenu(string displayText, bool enableCancelBtn, UnityAction confirmAction, UnityAction cancelAction)
    {
        this.displayTest.text = displayText;

        confirmBtn.onClick.RemoveAllListeners();
        cancelBtn.onClick.RemoveAllListeners();

        confirmBtn.onClick.AddListener(() =>
        {
            DeactivateMenu();
            confirmAction();
        });
        cancelBtn.onClick.AddListener(() =>
        {
            DeactivateMenu();
            cancelAction();
        });
        cancelBtn.gameObject.SetActive(enableCancelBtn);

        this.gameObject.SetActive(true);
    }

    private void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
