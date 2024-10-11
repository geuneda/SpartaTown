using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;

public class NameChanger : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button changeNameButton;
    [SerializeField] private Button confirmButton;
    [SerializeField] private GameObject nickNameChangePanel;
    [SerializeField] private TextMeshProUGUI errorMessage;
    private TextMeshProUGUI nicknameText;

    SpartaTownNicknameDisplay spartaTownNicknameDisplay;

    private void Awake()
    {
        spartaTownNicknameDisplay = GetComponent<SpartaTownNicknameDisplay>();
    }

    private void Start()
    {
        if (nickNameChangePanel)
        {
            nickNameChangePanel.gameObject.SetActive(false);
        }
        changeNameButton.onClick.AddListener(OnChangeNameButtonClicked);
        confirmButton.onClick.AddListener(OnConfirmButtonClicked);
    }

    public void OnChangeNameButtonClicked()
    {
        nickNameChangePanel.SetActive(true);
    }

    public void OnConfirmButtonClicked()
    {

        String newName = nameInputField.text;

        if (!string.IsNullOrEmpty(newName) && newName.Length <= 5)
        {
            GameManager.Instance.SetPlayerNickname(newName);
            nicknameText.text = newName;
        }
        else
        {
            ShowErrorMessage("공백 혹은 6글자 이상은 불가합니다.");
        }

        nickNameChangePanel.SetActive(false);
    }

    private void ShowErrorMessage(string message)
    {
        errorMessage.text = message;
        errorMessage.gameObject.SetActive(true);
        StartCoroutine(HideErrorMessageAfterDelay(3f));
    }

    private IEnumerator HideErrorMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorMessage.text = "";
        errorMessage.gameObject.SetActive(false);
    }

    public void SetNicknameText(TextMeshProUGUI text)
    {
        nicknameText = text;
    }
}