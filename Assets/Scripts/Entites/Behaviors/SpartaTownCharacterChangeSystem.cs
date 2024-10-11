using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

    public class SpartaTownCharacterChangeSystem : MonoBehaviour
{
    [SerializeField] private GameObject Character1Prefab;
    [SerializeField] private GameObject Character2Prefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private NameChanger nameChanger;

    NPCInteraction nPCInteraction;

    GameObject characterInstance = null;
    private int currentCharacterIndex = 0;

    private void Awake()
    {
        nPCInteraction = GetComponent<NPCInteraction>();
        currentCharacterIndex = GameManager.Instance.SelectedCharacterIndex;

        InstantiateCharacter(currentCharacterIndex, transform.position);
    }

    public void SwitchCharacter()
    {
        //위치저장
        Vector3 currentPosition = characterInstance != null ? characterInstance.transform.position : transform.position;
        // 0과 1을 반복
        currentCharacterIndex = (currentCharacterIndex + 1) % 2;

        InstantiateCharacter(currentCharacterIndex, currentPosition);

        GameManager.Instance.SelectedCharacterIndex = currentCharacterIndex;

    }

    public void InstantiateCharacter(int characterIndex, Vector3 spawnPostion)
    {
        //기존 캐릭터 삭제
        if (characterInstance != null)
        {
            Destroy(characterInstance);
        }
        //Index확인 후 새로운 캐릭터 생성
        if (characterIndex == 0)
        {
            characterInstance = Instantiate(Character1Prefab, spawnPostion, Quaternion.identity);
        }
        else if (characterIndex == 1)
        {
            characterInstance = Instantiate(Character2Prefab, spawnPostion, Quaternion.identity);
        }
        //게임매니저에 저장
        GameManager.Instance.SetPlayerInstance(characterInstance);
        //카메라잡아주기
        if (characterInstance != null)
        {
            virtualCamera.Follow = characterInstance.transform;
            virtualCamera.LookAt = characterInstance.transform;
            //닉네임설정
            TextMeshProUGUI nicknameText = characterInstance.GetComponentInChildren<TextMeshProUGUI>();
            if (nicknameText != null && nameChanger != null)
            {
                nameChanger.SetNicknameText(nicknameText);
            }
            else
            {
                Debug.Log("MainSceneController (Nickname혹은 nameChanger이 null임)");
            }
        }
    }
}