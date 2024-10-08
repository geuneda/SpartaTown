using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CharacterSelectionController : MonoBehaviour
{
    SpartaTownCharacterSeleteSystem characterSeleteSystem;

    private void Awake()
    {
        characterSeleteSystem = GetComponent<SpartaTownCharacterSeleteSystem>();
    }
    //캐릭터 이미지 버튼 클릭시 발동
    public void OnCharacter1Selected()
    {
        characterSeleteSystem.StartMainScene(0);
    }

    public void OnCharacter2Selected()
    {
        characterSeleteSystem.StartMainScene(1);
    }

}
