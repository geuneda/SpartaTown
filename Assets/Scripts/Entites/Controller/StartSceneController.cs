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
            ShowErrorMessage("���� Ȥ�� ������ �� ���� ���Դϴ�.");
        }
        else if (nickname.Length > 5 )
        {
            ShowErrorMessage("�г����� 5���� ���Ϸ� ���� �ٶ��ϴ�. �ѱ۵� �����մϴ�.");
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
