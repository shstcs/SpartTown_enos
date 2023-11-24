using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControl : CharacterControl
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }
    public void OnMove(InputValue value)
    {
        Vector2 move = value.Get<Vector2>().normalized;
        CallMoveEvent(move);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;
        if(newAim.magnitude > .9f)
        {
            CallLookEvent(newAim);
        }
    }

    public void OnAttack(InputValue value)
    {
        CallAttackEvent();
    }
    
}