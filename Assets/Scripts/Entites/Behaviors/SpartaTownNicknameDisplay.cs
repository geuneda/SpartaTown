using UnityEngine;
using TMPro;

public class SpartaTownNicknameDisplay : MonoBehaviour
{
    public TextMeshProUGUI nicknameText;

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            SetName();
        }
        else
        {
            Debug.LogError("게임매니저를 인식할 수 없습니다.");
        }
    }

    public void SetName()
    {
        nicknameText.text = GameManager.Instance.PlayerNickname;
    }
}