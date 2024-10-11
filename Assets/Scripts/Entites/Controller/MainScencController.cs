using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private GameObject Character1Prefab;
    [SerializeField] private GameObject Character2Prefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private NameChanger nameChanger;
    [SerializeField] private Button changeCharacterButton;
    NPCInteraction nPCInteraction;

    GameObject characterInstance = null;
    private int currentCharacterIndex = 0;

    private void Awake()
    {
        nPCInteraction = GetComponent<NPCInteraction>();
        currentCharacterIndex = GameManager.Instance.SelectedCharacterIndex;
        
        InstantiateCharacter(currentCharacterIndex, transform.position);
    }

    private void Start()
    {
        if (changeCharacterButton != null)
        {
            changeCharacterButton.onClick.AddListener(SwitchCharacter);
        }
    }
    
    private void InstantiateCharacter(int characterIndex, Vector3 spawnPostion)
    {
        if (characterInstance != null)
        {
            Destroy(characterInstance);
        }

        if (characterIndex == 0)
        {
            characterInstance = Instantiate(Character1Prefab, spawnPostion, Quaternion.identity);
        }
        else if (characterIndex == 1)
        {
            characterInstance = Instantiate(Character2Prefab, spawnPostion, Quaternion.identity);
        }

        GameManager.Instance.SetPlayerInstance(characterInstance);

        if (characterInstance != null)
        {
            virtualCamera.Follow = characterInstance.transform;
            virtualCamera.LookAt = characterInstance.transform;

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

    private void SwitchCharacter()
    {
        //위치저장
        Vector3 currentPosition = characterInstance != null ? characterInstance.transform.position : transform.position;
        // 0과 1을 반복
        currentCharacterIndex = (currentCharacterIndex + 1) % 2;

        InstantiateCharacter(currentCharacterIndex, currentPosition);

        GameManager.Instance.SelectedCharacterIndex = currentCharacterIndex;

    }
}