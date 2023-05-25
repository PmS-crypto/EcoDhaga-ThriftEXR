using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;


[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool placedPortal;

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        placedPortal = false;
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;

        if (!placedPortal && aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            GameObject obj = Instantiate(prefab, pose.position, pose.rotation);
            placedPortal = true;
        }
    }
}
