using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private GameObject Character1Prefab;
    [SerializeField] private GameObject Character2Prefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

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
    }
}