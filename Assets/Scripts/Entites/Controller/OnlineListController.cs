using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OnlineListController : MonoBehaviour
{
    [SerializeField] private GameObject showOnlinePanel;
    [SerializeField] private TextMeshProUGUI onlineListText;
    [SerializeField] private Button showOnlineButton;
    [SerializeField] private Button closeButton;

    private List<string> onlineNames = new List<string>();

    private void Start()
    {
        showOnlinePanel.SetActive(false);

        showOnlineButton.onClick.AddListener(OpenOnlinePanel);
        closeButton.onClick.AddListener(CloseOnlinePanel);
    }

    private void OpenOnlinePanel()
    {
        showOnlinePanel.SetActive(true);
        UpdateOnlineList();
    }

    private void CloseOnlinePanel()
    {
        showOnlinePanel.SetActive(false);
    }

    private void UpdateOnlineList()
    {
        onlineNames.Clear();

        if (GameManager.Instance != null)
        {
            onlineNames.Add("학생: " + GameManager.Instance.PlayerNickname);
        }

        GameObject[] mnpcs = GameObject.FindGameObjectsWithTag("MNPC");

        foreach (var mnpc in mnpcs)
        {
            TextMeshPro npcNameText = mnpc.GetComponentInChildren<TextMeshPro>();

            if (npcNameText != null)
            {
                onlineNames.Add("매니저: " + npcNameText.text);
            }
        }

        onlineListText.text = string.Join("\n", onlineNames);
    }
}
