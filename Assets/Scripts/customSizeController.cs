using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class customSizeController : MonoBehaviour
{
    [SerializeField]
    public GameObject topSizeChart;
    [SerializeField]
    public GameObject bottomSizeChart;

    [SerializeField]
    public List<Button> topButtons;

    [SerializeField]
    public List<Button> bottomButtons;

    private string topSize;

    private string bottomSize;

    private Dictionary<string, int> sizeLookup = new Dictionary<string, int>(){
        {"S", 0},
        {"M", 1},
        {"L", 2},
        {"XL", 3},
        {"XXL", 4},
    };

    void Start()
    {

    }

    private void Update()
    {
        topSize = PlayerPrefs.GetString("topSize", "M");
        bottomSize = PlayerPrefs.GetString("bottomSize", "M");
        int topSizeIndex = sizeLookup[topSize];
        int bottomSizeIndex = sizeLookup[bottomSize];
        foreach (var btn in topButtons)
        {
            btn.interactable = true;
            if (btn == topButtons[topSizeIndex])
            {
                btn.interactable = false;
            }
        }

        foreach (var btn in bottomButtons)
        {
            btn.interactable = true;
            if (btn == bottomButtons[bottomSizeIndex])
            {
                btn.interactable = false;
            }
        }
    }

    public void TopSmall(){
        PlayerPrefs.SetString("topSize","S");
    }

    public void TopMedium(){
        PlayerPrefs.SetString("topSize","M");
    }    

    public void TopLarge(){
        PlayerPrefs.SetString("topSize","L");
    }

    public void TopExtraLarge(){
        PlayerPrefs.SetString("topSize","XL");
    }

    public void TopExtraExtraLarge(){
        PlayerPrefs.SetString("topSize","XXL");
    }

    public void BottomSmall(){
        PlayerPrefs.SetString("bottomSize","S");
    }

    public void BottomMedium(){
        PlayerPrefs.SetString("bottomSize","M");
    }    

    public void BottomLarge(){
        PlayerPrefs.SetString("bottomSize","L");
    }

    public void BottomExtraLarge(){
        PlayerPrefs.SetString("bottomSize","XL");
    }

    public void BottomExtraExtraLarge(){
        PlayerPrefs.SetString("bottomSize","XXL");
    }

    public void OnTopSizeChartClick(){
        topSizeChart.SetActive(true);
    }

    public void OnTopSizeChartCloseClick(){
        topSizeChart.SetActive(false);
    }
    
    public void OnBottomSizeChartClick(){
        bottomSizeChart.SetActive(true);
    }

    public void OnBottomSizeChartCloseClick(){
        bottomSizeChart.SetActive(false);
    }

    public void Explore(){
        SceneManager.LoadScene("RaycastPortal");
    }

    public void getInput(){
        Debug.Log("Top Size: " + PlayerPrefs.GetString("topSize"));
        Debug.Log("Bottom Size: " + PlayerPrefs.GetString("bottomSize"));}
}
