using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class customSizeController : MonoBehaviour
{
    [SerializeField]
    public GameObject topSizeChart;
    [SerializeField]
    public GameObject bottomSizeChart;

    void Start()
    {
        PlayerPrefs.SetString("topSize","medium");
        PlayerPrefs.SetString("bottomSize","medium");
    }

    public void TopSmall(){
        PlayerPrefs.SetString("topSize","small");
    }

    public void TopMedium(){
        PlayerPrefs.SetString("topSize","medium");
    }    

    public void TopLarge(){
        PlayerPrefs.SetString("topSize","large");
    }

    public void TopExtraLarge(){
        PlayerPrefs.SetString("topSize","extraLarge");
    }

    public void TopExtraExtraLarge(){
        PlayerPrefs.SetString("topSize","extraExtraLarge");
    }

    public void BottomSmall(){
        PlayerPrefs.SetString("bottomSize","small");
    }

    public void BottomMedium(){
        PlayerPrefs.SetString("bottomSize","medium");
    }    

    public void BottomLarge(){
        PlayerPrefs.SetString("bottomSize","large");
    }

    public void BottomExtraLarge(){
        PlayerPrefs.SetString("bottomSize","extraLarge");
    }

    public void BottomExtraExtraLarge(){
        PlayerPrefs.SetString("bottomSize","extraExtraLarge");
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
