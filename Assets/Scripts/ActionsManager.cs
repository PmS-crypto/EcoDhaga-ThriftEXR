using System    ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class ActionsManager: MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public Transform placedPortal = null;
    private bool isPortalLocked = false; 



    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    public static event Action onPlacedObject;


    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
    }

    public void InstantiatePortal(Vector3 screenPosition)
    {
        if (!placedPortal && aRRaycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            GameObject obj = Instantiate(prefab, pose.position, pose.rotation);
            placedPortal = obj.transform;
            if (onPlacedObject != null) onPlacedObject();
        }
    }

    public void MovePortal(Vector3 screenPosition)
    {
        if(!isPortalLocked && placedPortal && aRRaycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;
            placedPortal.SetPositionAndRotation(pose.position, pose.rotation);
        }
    }

    public void LockPortal()
    {
        isPortalLocked = true;
    }

    public void UnlockPortal()
    {
        isPortalLocked = false;
    }

    public void NextClothing()
    {
        Debug.Log("next clothing");
        if (!placedPortal) return;
        placedPortal.GetComponent<ClothSpawner>().SpawnNextCloth();
    }

    public void PrevClothing()
    {
        Debug.Log("prev clothing");
        if (!placedPortal) return;
        placedPortal.GetComponent<ClothSpawner>().SpawnPrevCloth();
    }


}
