using UnityEngine;
using UnityEngine.UI;

public class SpartaTownNicknameDisplay : MonoBehaviour
{
    [SerializeField] private Text nicknameText;

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            string nickname = GameManager.Instance.PlayerNickname;
            nicknameText.text = nickname;
        }
        else
        {
            Debug.LogError("게임매니저를 인식할 수 없습니다.");
        }
    }
}