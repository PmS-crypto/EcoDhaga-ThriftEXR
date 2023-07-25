using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roomContext;
    [SerializeField] List<GameObject> objectsToHide;

    private void Awake()
    {
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        SetLayerAllChildren(roomContext.transform, LayerMask.NameToLayer("Default"));
        foreach(GameObject obj in objectsToHide)
        {
            obj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        SetLayerAllChildren(roomContext.transform, LayerMask.NameToLayer("InsidePortal"));
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }

    void SetLayerAllChildren(Transform root, int layer)
    {
        var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
        foreach (var child in children)
        {
            Debug.Log(child.name);
            child.gameObject.layer = layer;
        }
    }


}
