using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class InputTextUI : MonoBehaviour
{
    private TextMeshProUGUI title;
    private TMP_InputField inputField;
    private Button confirmBtn;
    private Button cancelBtn;

    private void Awake()
    {
        Debug.Log("Awareeeeee");
        title = transform.Find("Header").GetComponent<TextMeshProUGUI>();
        inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
        confirmBtn = transform.Find("ConfirmBtn").GetComponent<Button>();
        cancelBtn = transform.Find("CancelBtn").GetComponent<Button>();
        DeactivateMenu();
    }
    public void ActivateMenu(string title, UnityAction<string> confirmAction, UnityAction cancelAction)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        this.gameObject.SetActive(true);

        this.title.text = title;
        this.inputField.text = "";

        confirmBtn.onClick.RemoveAllListeners();
        cancelBtn.onClick.RemoveAllListeners();

        confirmBtn.onClick.AddListener(() =>
        {
            if (inputField.text != "")
            {
                DeactivateMenu();
                confirmAction(inputField.text);
            }
        });
        cancelBtn.onClick.AddListener(() =>
        {
            this.inputField.text = "";
            // DeactivateMenu();
            cancelAction();
        });
    }

    private void DeactivateMenu()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        this.gameObject.SetActive(false);
    }

    public bool IsActivated()
    {
        return this.gameObject.activeSelf;
    }
}
