using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : SpartaTownController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.WorldToScreenPoint(newAim);
        //����ȭ
        newAim = (worldPos - (Vector2)transform.position).normalized;
        //ĳ���Ϳ� ���콺�� �����Ÿ� �̻��϶��� CallLookEvent�۵�
        if(newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }

}
