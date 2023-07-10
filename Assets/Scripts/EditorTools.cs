using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class EditorTools : MonoBehaviour
{
    [SerializeField] public bool populate = false;
    [SerializeField] public bool spawnclothes = false;
    public string jsonFilePath;
    public List<GameObject> spawns;


    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (populate)
        {
            Debug.Log("populating");
            populate = false;
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            ClothDataWrapper clothDataWrapper = JsonUtility.FromJson<ClothDataWrapper>(jsonData);

            // Get the clothDataArray from the wrapper object
            ClothData[] clothArray = clothDataWrapper.clothDataArray;
            for(int i = 0; i < clothArray.Length; i++)
            {
                clothArray[i].clothPrefab = spawns[i % spawns.Count];
            }

            transform.gameObject.GetComponent<ClothSpawner>().clothDataList = new List<ClothData>(clothArray);
        }
        if(spawnclothes)
        {
            spawnclothes = false;
            transform.gameObject.GetComponent<ClothSpawner>().InitClothSpawn();
        }
    }
}

public struct ClothDataWrapper
{
    public ClothData[] clothDataArray;
}

