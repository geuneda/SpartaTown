using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    //0∆Î±œ 1≥Ø∑•¿Ã
    public int SelectedCharacterIndex { get; set; }

    public GameObject PlayerInstance { get; private set; }

    public string PlayerNickname {  get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerNickname(string nickname)
    {
        PlayerNickname = nickname;
    }

    public void SetselectedCharacterIndex(int index)
    {
        SelectedCharacterIndex = index;
    }

    public void SetPlayerInstance(GameObject player)
    {
        PlayerInstance = player;
    }
}
