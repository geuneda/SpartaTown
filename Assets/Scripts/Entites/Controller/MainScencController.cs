using UnityEngine;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    [SerializeField] private SpartaTownCharacterChangeSystem characterChangeSystem;
    [SerializeField] private Button changeCharacterButton;

    private void Start()
    {
        if (changeCharacterButton != null)
        {
            changeCharacterButton.onClick.AddListener(OnCharacterChangeButtonClicked);
        }

        int selectedCharacterIndex = GameManager.Instance.SelectedCharacterIndex;
        characterChangeSystem.InstantiateCharacter(selectedCharacterIndex, transform.position);
    }

    public void OnCharacterChangeButtonClicked()
    {
        characterChangeSystem.SwitchCharacter();
    }

}