using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    Transform platformContainer;
    [SerializeField]
    float platformDistance;
    [SerializeField]
    int maxPlatformCount;
    [SerializeField]
    float spawnTimer;

    List<GameObject> platforms;

    const string platformFolder = "Platforms";


    private List<GameObject> activePlatforms;


    int floorCounter;

    float timer;
    float nextSpawnTime;


    private void Awake()
    {
        LoadAllPlatforms();   
        activePlatforms = new List<GameObject>();
    }

    private void Start()
    {
        floorCounter = 0;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnPlatform();
            nextSpawnTime = timer + spawnTimer;
        }

        //delete first (the oldest) platform when we have to many
        if (activePlatforms.Count > maxPlatformCount) 
        {
            RemoveOldestPlatform();
        }
    }


    private void RemoveOldestPlatform()
    {
        GameObject oldest = activePlatforms[0];
        activePlatforms.RemoveAt(0);

        Destroy(oldest);
    }


    private void SpawnPlatform()
    {
        //take random platform
        GameObject platformPrefab = platforms[Random.Range(0, platforms.Count)];

        GameObject platform = Instantiate(platformPrefab, platformContainer);

        platform.transform.localPosition = CalculatePosition();

        activePlatforms.Add(platform);
    }


    private Vector3 CalculatePosition()
    {
        Vector2 position = new Vector2(0, floorCounter * platformDistance);

        floorCounter++;

        return position;
    }

    private void LoadAllPlatforms()
    {
        platforms = new List<GameObject>();

        Object[] loadedPrefabs = Resources.LoadAll(platformFolder, typeof(GameObject)); // load all prefabs from folder

        foreach (Object obj in loadedPrefabs)
        {
            GameObject prefab = obj as GameObject;
            if (prefab != null)
            {
                platforms.Add(prefab); // loading
            }
        }
    }
}
