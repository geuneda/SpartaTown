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
            Debug.LogError("���ӸŴ����� �ν��� �� �����ϴ�.");
        }
    }
}