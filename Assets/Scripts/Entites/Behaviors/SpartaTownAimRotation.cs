using System;
using UnityEngine;

public class SpartaTownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private SpartaTownController _controller;

    private void Awake()
    {
        _controller = GetComponent<SpartaTownController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        RotateCharacter(newAimDirection);
    }

    private void RotateCharacter(Vector2 direction)
    {
        characterRenderer.flipX = direction.x < 0;
    }
}