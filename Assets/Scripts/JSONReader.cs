using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsontext;
    
    [System.Serializable]
    public class ClothPrefab
    {
        public string size;
        public string brand;
        public string material;
        public string color;
        public string condition;
    }

    [System.Serializable]
    public class ClothPrefabData
    {
        public ClothPrefab[] clothDataArray;
    }

    public ClothPrefabData clothDataList = new ClothPrefabData();

    void Start()
    {
        clothDataList = JsonUtility.FromJson<ClothPrefabData>(jsontext.text);
    }
}
