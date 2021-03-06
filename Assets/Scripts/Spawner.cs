using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    // public variables
    public float minsecondsBetweenSpawning = 0.0f;
    public float maxsecondsBetweenSpawning = 0.1f;
    public float xMinRange = -25.0f;
    public float xMaxRange = 25.0f;
    public float yMinRange = 8.0f;
    public float yMaxRange = 25.0f;
    public float zMinRange = -25.0f;
    public float zMaxRange = 25.0f;

    public GameObject[] spawnObjects; // what prefabs to spawn

    private float nextSpawnTime;

    // Use this for initialization
    void Start()
    {
        // determine when to spawn the next object
        nextSpawnTime = Time.time + Random.Range(minsecondsBetweenSpawning, maxsecondsBetweenSpawning);
    }

    // Update is called once per frame
    void Update()
    {
        // if time to spawn a new game object
        if (Time.time >= nextSpawnTime && !gameManager.Instance.gameIsOver)
        {
            // Spawn the game object through function below
            MakeThingToSpawn();

            // determine the next time to spawn the object
            nextSpawnTime = Time.time + Random.Range(minsecondsBetweenSpawning, maxsecondsBetweenSpawning);
        }
    }

    void MakeThingToSpawn()
    {
        Vector3 spawnPosition;

        // get a random position between the specified ranges
        spawnPosition.x = Random.Range(xMinRange, xMaxRange);
        spawnPosition.y = Random.Range(yMinRange, yMaxRange);
        spawnPosition.z = Random.Range(zMinRange, zMaxRange);

        // determine which object to spawn
        int objectToSpawn = Random.Range(0, spawnObjects.Length);

        // actually spawn the game object
        GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;

        // make the parent the spawner so hierarchy doesn't get super messy
        spawnedObject.transform.parent = gameObject.transform;
    }
}
