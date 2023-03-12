using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class InputTextUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button confirmBtn;
    [SerializeField] private Button cancelBtn;

    // private void Awake()
    // {
    //     title = transform.Find("Header").GetComponent<TextMeshProUGUI>();
    //     inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
    //     confirmBtn = transform.Find("ConfirmBtn").GetComponent<Button>();
    //     cancelBtn = transform.Find("CancelBtn").GetComponent<Button>();
    //     DeactivateMenu();
    // }
    private void Update()
    {
        if (InputManager.instance.GetSubmitPressed()) confirmBtn.onClick.Invoke();
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void ActivateMenu(string title, UnityAction<string> confirmAction, UnityAction cancelAction, string confirmText = "ยืนยัน", string cancelText = "เคลียร์")
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        this.gameObject.SetActive(true);

        this.title.text = title;
        this.inputField.text = "";
        confirmBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = confirmText;
        cancelBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = cancelText;

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

    public void DeactivateMenu()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;

        this.gameObject.SetActive(false);
    }

    public bool IsActivated()
    {
        return this.gameObject.activeSelf;
    }
}
