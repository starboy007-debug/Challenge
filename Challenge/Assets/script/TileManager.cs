using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] Tileprefabs;
    private Transform Playertransform;
    private float Spawnz = -10.0f;
    private float TileLength = 60.0f;
    private float Safezone = 40.0f;
    private int amountoftile = 4;
    private int LastprefabIndex = 0;
    private List<GameObject> activeTiles;

    void Start()
    {
        activeTiles = new List<GameObject>();
        Playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < amountoftile; i++)
        {
            if (i < 2)
                SpawnTlie(0);
            else
                SpawnTlie();
        }
    }

  
    void Update()
    {
        if(Playertransform.position.z - Safezone > (Spawnz - amountoftile * TileLength))
        {
            SpawnTlie();
            DeleteTile();
        }
    }

    private void SpawnTlie(int PrefabIndex = -1)
    {
        GameObject go;
        if (PrefabIndex == -1)
            go = Instantiate(Tileprefabs[RandomprefabIndex()]) as GameObject;
        else
            go = Instantiate(Tileprefabs[PrefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * Spawnz;
        Spawnz += TileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomprefabIndex()
    {
        if (Tileprefabs.Length <= 1)
            return 0;
        int RandomIndex = LastprefabIndex;
        while(RandomIndex == LastprefabIndex)
        {
            RandomIndex = Random.Range(0, Tileprefabs.Length);
        }
        LastprefabIndex = RandomIndex;
        return RandomIndex;
    }

}
