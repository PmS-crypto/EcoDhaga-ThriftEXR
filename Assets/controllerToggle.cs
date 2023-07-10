using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerToggle : MonoBehaviour
{
    public bool toggleBool = false;
    [SerializeField]
    private GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void toggle()
    {
        toggleBool = !toggleBool;
        controller.SetActive(toggleBool);
    }
}
