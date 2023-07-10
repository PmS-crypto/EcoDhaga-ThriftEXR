using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ClothData
{
    public int id;
    public string size;
    public string brand;
    public string material;
    public string color;
    public string condition;
    public int price;
    public string type;
    public string link;
    public GameObject clothPrefab;
}


public class ClothSpawner : MonoBehaviour
{

    [SerializeField] public List<ClothData> clothDataList;
    [SerializeField] private List<Transform> spawnerPositions;
    [SerializeField] private float rotationSpeed = 15f;
    private List<GameObject> instantiatedClothes = new List<GameObject>();
    private Dictionary<int, GameObject> clothDictionary = new Dictionary<int, GameObject>();

    private int currCloth;

    private string bottomSize;
    private string topSize;

    private List<int> customizedList;

    private Dictionary<string, int> sizeLookup = new Dictionary<string, int>(){
        {"S", 0},
        {"M", 1},
        {"L", 2},
        {"XL", 3},
        {"XXL", 4},
    };

    private void Start()
    {
        InitClothSpawn();
    }

    public void InitClothSpawn()
    {
        foreach (ClothData clothData in clothDataList)
        {
            if (!clothDictionary.ContainsKey(clothData.id))
            {
                clothDictionary.Add(clothData.id, clothData.clothPrefab);
            }
        }
        topSize = PlayerPrefs.GetString("topSize", "M");
        bottomSize = PlayerPrefs.GetString("bottomSize", "M");
        clothDataList.Sort((a, b) =>GetScore(a) - GetScore(b));
        currCloth = 1;
        SetClothesOnSpawners();
        //for(int i = 0; i < clothDataList.Count; i++)
        //{
        //    Debug.Log(clothDataList[i].size + " " + clothDataList[i].brand);    
        //}
    }

    public void SpawnNextCloth()
    {
        currCloth += 1;
        SetClothesOnSpawners();
    }

    public void SpawnPrevCloth()
    {
        currCloth -= 1;
        SetClothesOnSpawners();
    }

    private int GetScore(ClothData cloth)
    {
        if (cloth.type == "top") return Math.Abs(sizeLookup[cloth.size] - sizeLookup[topSize]);
        else return Math.Abs(sizeLookup[cloth.size] - sizeLookup[bottomSize]);
    }

    private void Update()
    {
        RotateSpawners();
    }

    private void RotateSpawners()
    {
        for (int i = 0; i < spawnerPositions.Count; i++)
        {
            Transform spawner = spawnerPositions[i];
            spawner.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    public void SetClothesOnSpawners()
    {
        if (currCloth >= clothDataList.Count) currCloth = clothDataList.Count - 2;
        if (currCloth <= 0) currCloth = 1;

        int a = currCloth - 1;
        int b = currCloth;
        int c = currCloth + 1;
        List<int> clothIDs = new List<int>() { clothDataList[a].id, clothDataList[b].id, clothDataList[c].id };

        Debug.Log(clothDataList[a].material + " " + clothDataList[b].material + " " + clothDataList[c].material);

        // Delete old instantiated clothes
        DeleteInstantiatedClothes();

        // Spawn new clothes on spawners
        for (int i = 0; i < clothIDs.Count; i++)
        {
            int clothID = clothIDs[i];
            if (clothDictionary.ContainsKey(clothID))
            {
                GameObject clothPrefab = clothDictionary[clothID];
                Transform spawner = spawnerPositions[i];
                GameObject instantiatedCloth = Instantiate(clothPrefab, spawner.position, spawner.rotation, spawner);
                instantiatedCloth.transform.localPosition = new Vector3(0,0,0.01f);
                instantiatedCloth.layer = spawner.gameObject.layer;
                instantiatedClothes.Add(instantiatedCloth);
            }
        }
    }

    private void DeleteInstantiatedClothes()
    {
        for (int i = 0; i < instantiatedClothes.Count; i++)
        {
            Destroy(instantiatedClothes[i]);
        }
        instantiatedClothes.Clear();
    }
}


