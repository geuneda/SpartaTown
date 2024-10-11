using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2.0f; // 상호작용거리
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject dialogueText;
    [SerializeField] private Button closeButton;
    private Transform playerTransform;
    private bool isPlayerInRange = false;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        closeButton.onClick.AddListener(CloseDialoguePanel);

        interactionText.gameObject.SetActive(false);
        dialoguePanel.SetActive(false);
        dialogueText.SetActive(false);
    }

    private void CloseDialoguePanel()
    {
        dialoguePanel.SetActive(false);
        dialogueText.SetActive(false);
    }

    private void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        float distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance < interactionRange)
        {
            if (!isPlayerInRange)
            {
                ShowInteractionText();
            }
            isPlayerInRange = true;

            if (Input.GetKeyDown(KeyCode.G))
            {
                StartDialogue();
            }
        }
        else
        {
            if (isPlayerInRange)
            {
                HideInteractionText();
            }
            isPlayerInRange = false;
        }
    }

    private void ShowInteractionText()
    {
        interactionText.gameObject.SetActive(true);
    }

    private void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.SetActive(true);
    }
}

