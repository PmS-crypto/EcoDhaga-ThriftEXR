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
    private InputAction xRMove;
    private ActionsManager actionsManager;

    [SerializeField] private VirtualJoystick joystickData;

    [SerializeField] private float movementSpeed = 1.5f;

    private Vector3 joystickInput;

    public GameObject canvas;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        actionsManager = GetComponent<ActionsManager>();
        firstFingerTouch = playerInput.actions.FindAction("FirstFingerTouch");
        secondFingerTouch = playerInput.actions.FindAction("SecondFingerTouch");
        xRMove = playerInput.actions.FindAction("XRMove");
        canvas.SetActive(false);
    }

    private void OnEnable()
    {
        //xRMove.Enable();
        //xRMove.performed += OnJoystickMove;
        // xRMove.canceled += OnJoystickMove;
        firstFingerTouch.performed += TouchPressedSingle;
    }

    private void Update()
    {
        joystickInput = joystickData.InputDirection;
        Vector3 movement = new Vector3(joystickInput.x, 0f, joystickInput.z);
        Vector3 newPosition = transform.position + (movement * movementSpeed * Time.deltaTime);
        transform.position = newPosition;
        Debug.Log(joystickInput);
    }

    private void OnDisable()
    {
        firstFingerTouch.performed -= TouchPressedSingle;
    }

    private void OnJoystickMove(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        joystickInput = context.ReadValue<Vector2>();
        //Debug.Log(joystickInput);
        Vector3 movement = new Vector3(joystickInput.x, 0f, joystickInput.y);
        Vector3 newPosition = transform.position + (movement * movementSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    private void TouchPressedSingle(InputAction.CallbackContext context)
    {
        TouchState touch = context.ReadValue<TouchState>();
        bool isPo = IsPointerOverUIObject(touch.position);
        //Debug.Log(isPo);
        //if (isPo) return;
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
            if(actionsManager.placedPortal) canvas.SetActive(true);
        }
        //Debug.Log(touch);
    }

    private bool IsPointerOverUIObject(Vector3 position)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = position;
        EventSystem.current.RaycastAll(eventData, new List<RaycastResult>());
        return eventData.pointerCurrentRaycast.isValid;
    }
}
