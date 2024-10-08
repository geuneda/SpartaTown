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
        //정규화
        newAim = (worldPos - (Vector2)transform.position).normalized;
        //캐릭터와 마우스가 일정거리 이상일때만 CallLookEvent작동
        if(newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }

}
