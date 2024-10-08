using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInput;
    [SerializeField] private TextMeshProUGUI errorMessage;
    [SerializeField] GameObject characterPanel;

    public void OnStartButtonClicked()
    {
        string nickname = nicknameInput.text;

        if (string.IsNullOrEmpty(nickname) )
        {
            ShowErrorMessage("공백 혹은 설정할 수 없는 값입니다.");
        }
        else if (nickname.Length > 5 )
        {
            ShowErrorMessage("닉네임은 5글자 이하로 설정 바랍니다. 한글도 가능합니다.");
        }
        else
        {
            GameManager.Instance.SetPlayerNickname(nickname);
            characterPanel.SetActive(true);
        }
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
}
