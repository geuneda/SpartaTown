using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string playerNickname;

    private void Start()
    {
        playerNickname = PlayerPrefs.GetString("PlayerNickname", "Player");
        Debug.Log($"Loaded Nickname: {playerNickname}");
    }

    public string GetPlayerNickname()
    {
        return playerNickname;
    }
}