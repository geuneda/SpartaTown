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
    //ĳ���� �̹��� ��ư Ŭ���� �ߵ�
    public void OnCharacter1Selected()
    {
        characterSeleteSystem.StartMainScene(0);
    }

    public void OnCharacter2Selected()
    {
        characterSeleteSystem.StartMainScene(1);
    }

}
