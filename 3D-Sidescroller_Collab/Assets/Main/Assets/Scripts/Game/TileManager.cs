using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] Terrain_Tiles;

    private Transform playerTransform;
    private float spawnZ = 0f;
    private float tilelength = 5f;
    private int amntoftiles = 2;
    private float safezone = 8;
    private int lastprefabIndex = 0;

    private List<GameObject> activetiles;
    void Start()
    {
        activetiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amntoftiles; i++)
        {
            if (i < 2)
                spawnTiles(0);
            else
                spawnTiles();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z-safezone >(spawnZ - amntoftiles * tilelength))
        {
            spawnTiles();
            DeleteTiles();
        }
    }
    private void spawnTiles(int prefabIndex = -1)
    {
        
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(Terrain_Tiles[RandomPrefabIndex()] as GameObject);
        else
            go = Instantiate(Terrain_Tiles[prefabIndex] as GameObject);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tilelength;
        activetiles.Add(go);
    }
    private void DeleteTiles()
    {
        Destroy(activetiles[0]);
        activetiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (Terrain_Tiles.Length <= 1)
            return 0;

        int randomIndex = lastprefabIndex;
        while (randomIndex == lastprefabIndex)
        {
            randomIndex = Random.Range(0, Terrain_Tiles.Length);
        }

        lastprefabIndex = randomIndex;
        return randomIndex;
    }
}
