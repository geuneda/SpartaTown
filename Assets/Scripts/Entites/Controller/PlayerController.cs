using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PlayerController : MonoBehaviour
{

    private string playerNickname;

    private void Awake()
    {
        
    }

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