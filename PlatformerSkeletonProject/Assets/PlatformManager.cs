using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    Transform platformContainer;
    [SerializeField]
    Transform backgroundContainer;
    [SerializeField]
    float backgroundHeight;
    [SerializeField]
    int startSpawnCount;
    [SerializeField]
    Vector2 horizontalSpawnRange;
    [SerializeField]
    float platformDistance;
    [SerializeField]
    int maxPlatformCount;
    [SerializeField]
    float spawnTimer;
    [SerializeField]
    Transform player;

    List<GameObject> platforms;
    List<GameObject> backgrounds;

    const string platformFolder = "Platforms";
    const string backgroundFolder = "Backgrounds";


    private List<GameObject> activePlatforms;
    private List<GameObject> activeBackgrounds;


    int floorCounter;

    float timer;
    float nextSpawnTime;


    private void Awake()
    {
        LoadAllPlatforms();
        LoadAllBackgrounds();
        activePlatforms = new List<GameObject>();
        activeBackgrounds = new List<GameObject>();
    }

    private IEnumerator Start()
    {
        floorCounter = 0;
        timer = 0;

        for (int i = 0; i < startSpawnCount; i++)
        {
            SpawnPlatform();
            if(i % 4 == 0)
            {
                yield return null;
            }
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (activePlatforms.Last().transform.position.y - player.position.y < 40)
        {
            SpawnPlatform();
        }
        if (timer >= nextSpawnTime)
        {
            //SpawnPlatform();
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

        if (oldest.transform.position.y > activeBackgrounds[0].transform.position.y)
        {
            GameObject background = activeBackgrounds[0];
            activeBackgrounds.RemoveAt(0);
            Destroy(background);
        }

        Destroy(oldest);
    }


    private void SpawnPlatform()
    {
        
        //take random platform
        GameObject platformPrefab = platforms[Random.Range(0, platforms.Count)];

        GameObject platform = Instantiate(platformPrefab, platformContainer);

        platform.transform.localPosition = CalculatePosition();

        activePlatforms.Add(platform);

        if (activeBackgrounds.Count == 0 || platform.transform.position.y > activeBackgrounds[activeBackgrounds.Count - 1].transform.position.y)
        {
            SpawnBackground();
        }
    }


    private void SpawnBackground()
    {
        GameObject backgroundPrefab = backgrounds[Random.Range(0, backgrounds.Count)];

        GameObject background = Instantiate(backgroundPrefab, backgroundContainer);

        if (activeBackgrounds.Count > 0)
        {
            float topPosition = activeBackgrounds[activeBackgrounds.Count - 1].transform.localPosition.y;

            background.transform.localPosition = new Vector2(0, topPosition + backgroundHeight);
        }
        else
        {
            background.transform.localPosition = new Vector2(0, 0);
        }

        activeBackgrounds.Add(background);
    }


    private Vector3 CalculatePosition()
    {
        float horizontal = Random.Range(horizontalSpawnRange.x, horizontalSpawnRange.y);
        Vector2 position = new Vector2(horizontal, floorCounter * platformDistance);

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

    private void LoadAllBackgrounds()
    {
        backgrounds = new List<GameObject>();

        Object[] loadedPrefabs = Resources.LoadAll(backgroundFolder, typeof(GameObject)); // load all prefabs from folder

        foreach (Object obj in loadedPrefabs)
        {
            GameObject prefab = obj as GameObject;
            if (prefab != null)
            {
                backgrounds.Add(prefab); // loading
            }
        }
    }
}
