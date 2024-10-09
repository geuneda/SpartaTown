using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private GameObject Character1Prefab;
    [SerializeField] private GameObject Character2Prefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private NameChanger nameChanger;

    GameObject characterInstance = null;

    private void Awake()
    {
        int selectedCharacterIndex = GameManager.Instance.SelectedCharacterIndex;

        if (selectedCharacterIndex == 0)
        {
            characterInstance = Instantiate(Character1Prefab, transform.position, Quaternion.identity);
        }
        else if (selectedCharacterIndex == 1)
        {
            characterInstance = Instantiate(Character2Prefab, transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        if (characterInstance != null && virtualCamera != null)
        {
            virtualCamera.Follow = characterInstance.transform;
            virtualCamera.LookAt = characterInstance.transform;
        }

        if (characterInstance != null && nameChanger != null)
        {
            TextMeshProUGUI nicknameText = characterInstance.GetComponentInChildren<TextMeshProUGUI>();
            if (nicknameText != null)
            {
                nameChanger.SetNicknameText(nicknameText);
            }
            else
            {
                Debug.Log("MainSceneController : Nickname오브젝트를 찾을 수 없음");
            }
        }
    }
}