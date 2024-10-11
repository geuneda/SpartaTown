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
        //��ġ����
        Vector3 currentPosition = characterInstance != null ? characterInstance.transform.position : transform.position;
        // 0�� 1�� �ݺ�
        currentCharacterIndex = (currentCharacterIndex + 1) % 2;

        InstantiateCharacter(currentCharacterIndex, currentPosition);

        GameManager.Instance.SelectedCharacterIndex = currentCharacterIndex;

    }

    public void InstantiateCharacter(int characterIndex, Vector3 spawnPostion)
    {
        //���� ĳ���� ����
        if (characterInstance != null)
        {
            Destroy(characterInstance);
        }
        //IndexȮ�� �� ���ο� ĳ���� ����
        if (characterIndex == 0)
        {
            characterInstance = Instantiate(Character1Prefab, spawnPostion, Quaternion.identity);
        }
        else if (characterIndex == 1)
        {
            characterInstance = Instantiate(Character2Prefab, spawnPostion, Quaternion.identity);
        }
        //���ӸŴ����� ����
        GameManager.Instance.SetPlayerInstance(characterInstance);
        //ī�޶�����ֱ�
        if (characterInstance != null)
        {
            virtualCamera.Follow = characterInstance.transform;
            virtualCamera.LookAt = characterInstance.transform;
            //�г��Ӽ���
            TextMeshProUGUI nicknameText = characterInstance.GetComponentInChildren<TextMeshProUGUI>();
            if (nicknameText != null && nameChanger != null)
            {
                nameChanger.SetNicknameText(nicknameText);
            }
            else
            {
                Debug.Log("MainSceneController (NicknameȤ�� nameChanger�� null��)");
            }
        }
    }
}