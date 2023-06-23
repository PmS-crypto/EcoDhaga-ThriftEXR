using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roomContext;

    private void OnTriggerEnter(Collider other)
    {
        if(true)
        {
            Debug.Log("enter");
            SetLayerAllChildren(roomContext.transform, LayerMask.NameToLayer("Default"));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (true)
        {
            Debug.Log("exit");
            SetLayerAllChildren(roomContext.transform, LayerMask.NameToLayer("InsidePortal"));
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
