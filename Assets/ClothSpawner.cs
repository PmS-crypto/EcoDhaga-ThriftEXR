using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClothSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct ClothData
    {
        public string clothID;
        public GameObject clothPrefab;
    }

    [SerializeField] private List<ClothData> clothDataList;
    [SerializeField] private List<Transform> spawnerPositions;
    [SerializeField] private float rotationSpeed = 15f;
    private List<GameObject> instantiatedClothes = new List<GameObject>();
    private Dictionary<string, GameObject> clothDictionary = new Dictionary<string, GameObject>();

    private void Start()
    {
        // Populate the cloth dictionary using the cloth data list
        foreach (ClothData clothData in clothDataList)
        {
            if (!clothDictionary.ContainsKey(clothData.clothID))
            {
                clothDictionary.Add(clothData.clothID, clothData.clothPrefab);
            }
        }
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


    public void SetClothesOnSpawners(List<string> clothIDs)
    {
        // Delete old instantiated clothes
        DeleteInstantiatedClothes();

        // Spawn new clothes on spawners
        for (int i = 0; i < clothIDs.Count; i++)
        {
            string clothID = clothIDs[i];
            if (clothDictionary.ContainsKey(clothID))
            {
                GameObject clothPrefab = clothDictionary[clothID];
                Transform spawner = spawnerPositions[i];
                GameObject instantiatedCloth = Instantiate(clothPrefab, spawner.position, spawner.rotation, spawner);
                instantiatedCloth.transform.localPosition = Vector3.zero;
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


