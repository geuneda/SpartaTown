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
            Debug.LogError("���ӸŴ����� �ν��� �� �����ϴ�.");
        }
    }

    public void SetName()
    {
        nicknameText.text = GameManager.Instance.PlayerNickname;
    }
}