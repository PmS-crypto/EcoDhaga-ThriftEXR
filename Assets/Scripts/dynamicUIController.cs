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

    void Update()
    {
        //demo
        if (currCloth.id == -1) return;
        sizeText.text = currCloth.size;
        brandText.text = currCloth.brand;
        materialText.text = currCloth.material;
        colorText.text = currCloth.color;
        conditionText.text = currCloth.condition;
    }

    public void ChangeCloth(ClothData newCloth) 
    {
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
