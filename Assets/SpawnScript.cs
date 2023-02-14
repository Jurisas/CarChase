using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private RoadSkinManager skinManager;
    [SerializeField] private CollectibleManager collectibleManager;
    public int numberOfSpawnedItems;
    public GameObject coin;
    public GameObject tenXCoin;
    private GameObject carSpawn;
    public GameObject[] array;
    public GameObject[] flowers;
    private float x = -10;
    public GameObject[] spawns;
    public bool[] used;
    public int last = -1;
    public int actual = -1;
    void Start()
    {
        carSpawn = array[skinManager.SkinIndex()];
        numberOfSpawnedItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        carSpawn = array[skinManager.SkinIndex()];
        if (numberOfSpawnedItems < 3)
        {
            int itemNumber = Random.Range(1, 102);
            int spawnPositionNumber = Random.Range(0, 4);
            if (used[spawnPositionNumber] != true && spawnPositionNumber != last && spawnPositionNumber != actual)
            {
                numberOfSpawnedItems++;
                used[spawnPositionNumber] = true;
                for (int i = 0; i < 4; i++)
                {
                    if (i != spawnPositionNumber || i != last && i != actual)
                    {
                        used[spawnPositionNumber] = false;
                    }
                }
                if (itemNumber >= 1 && itemNumber <= 70)
                {
                    
                    Instantiate((GameObject)carSpawn, new Vector3(spawns[spawnPositionNumber].transform.position.x, 8, -1), Quaternion.identity);
                }

                if (itemNumber >= 71 && itemNumber <= 95)
                {
                    Instantiate(coin, new Vector3(spawns[spawnPositionNumber].transform.position.x, 8, -1), Quaternion.identity);
                }
                if (itemNumber >= 96 && itemNumber <= 100)
                {
                    Instantiate(tenXCoin, new Vector3(spawns[spawnPositionNumber].transform.position.x, 8, -1), Quaternion.identity);
                }
                if (itemNumber >= 101 && itemNumber <= 102 && collectibleManager.GetFlower(skinManager.SkinIndex()) < 10)
                {
                    Instantiate(flowers[skinManager.SkinIndex()], new Vector3(spawns[spawnPositionNumber].transform.position.x, 8, -1), Quaternion.identity);
                }
                last = actual;
                actual = spawnPositionNumber;
                
            }

        }
    }
}
