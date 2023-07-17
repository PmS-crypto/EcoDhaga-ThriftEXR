using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dynamicUIController : MonoBehaviour
{
    // public List<dynamicUIModel> UIPanels;

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
        sizeText.text = sizeTextMessage + "heal";
        brandText.text = brandTextMessage + "heal";
        materialText.text = materialTextMessage + "heal";
        colorText.text = colorTextMessage + "heal";
        conditionText.text = conditionTextMessage + "heal";
    }

    public void BuyNow()
    {
        Application.OpenURL("https://www.ecodhaga.com");
    }

    public void enableUI()
    {

    }
}
