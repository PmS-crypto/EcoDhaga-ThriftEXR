using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dynamicUIController : MonoBehaviour
{
    // public List<dynamicUIModel> UIPanels;

    public ClothData currCloth = new ClothData { id= -1 };

    [SerializeField]
    public Text sizeText = null;
    [SerializeField]
    public string sizeTextMessage = null;

    [SerializeField]
    public Text brandText = null;
    [SerializeField]
    public string brandTextMessage = null;

    [SerializeField]
    public Text materialText = null;
    [SerializeField]
    public string materialTextMessage = null;

    [SerializeField]
    public Text colorText = null;
    [SerializeField]
    public string colorTextMessage = null;

    [SerializeField]
    public Text conditionText = null;
    [SerializeField]
    public string conditionTextMessage = null;

    private RectTransform canvasRectTransform;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        transform.GetComponent<Canvas>().worldCamera = mainCamera;
        canvasRectTransform = GetComponent<RectTransform>();
    }


    void Update()
    {
        //demo
        if (currCloth.id == -1) return;
        sizeText.text = "Size: " + currCloth.size;
        brandText.text = "Brand: " +currCloth.brand;
        materialText.text = "Material: " + currCloth.material;
        colorText.text = "Color: " + currCloth.color;
        conditionText.text = "Condition: " + currCloth.condition;
    }

    private void LateUpdate()
    {
        if (mainCamera == null || canvasRectTransform == null)
            return;

        // Calculate the direction from the canvas position to the camera position
        Vector3 toCamera = mainCamera.transform.position - canvasRectTransform.position;

        // Calculate the rotation angle around the Y-axis
        float angle = Mathf.Atan2(toCamera.x, toCamera.z) * Mathf.Rad2Deg;

        // Set the canvas rotation only on the Y-axis, keeping its original X and Z rotations
        canvasRectTransform.rotation = Quaternion.Euler(new Vector3(0f, 180 + angle, 0f));
    }

    public void ChangeCloth(ClothData newCloth) 
    {
        Debug.Log(newCloth.id);
        currCloth = newCloth;
    }

    public void BuyNow()
    {
        Application.OpenURL(currCloth.link);
    }

    public void enableUI()
    {

    }
}
