using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction firstFingerTouch;
    private InputAction secondFingerTouch;
    private ActionsManager actionsManager;

    public GameObject canvas;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        actionsManager = GetComponent<ActionsManager>();
        firstFingerTouch = playerInput.actions.FindAction("FirstFingerTouch");
        secondFingerTouch = playerInput.actions.FindAction("SecondFingerTouch");
    }

    private void OnEnable()
    {
        firstFingerTouch.performed += TouchPressedSingle;
    }

    private void OnDisable()
    {
        firstFingerTouch.performed -= TouchPressedSingle;
    }

    private void TouchPressedSingle(InputAction.CallbackContext context)
    {
        TouchState touch = context.ReadValue<TouchState>();
        bool isPo = IsPointerOverUIObject(touch.position);
        Debug.Log(isPo);
        if (isPo) return;
        if(touch.phase.Equals(UnityEngine.InputSystem.TouchPhase.Began))
        {
            actionsManager.InstantiatePortal(touch.position);
        }
        else if(touch.phase.Equals(UnityEngine.InputSystem.TouchPhase.Moved))
        {
            actionsManager.MovePortal(touch.position);
        }
        else if(touch.phase.Equals(UnityEngine.InputSystem.TouchPhase.Ended))
        {
            actionsManager.LockPortal();
            canvas.SetActive(true);
        }
        Debug.Log(touch);
    }

    private bool IsPointerOverUIObject(Vector3 position)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = position;
        EventSystem.current.RaycastAll(eventData, new List<RaycastResult>());
        return eventData.pointerCurrentRaycast.isValid;
    }
}
