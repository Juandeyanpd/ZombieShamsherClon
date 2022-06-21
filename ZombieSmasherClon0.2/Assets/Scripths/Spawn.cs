using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefabs;

    public float timeSpawn = 1;
    public float repeatSpawnRate = 3;

    public Transform xRangeLeft;
    public Transform xRangeRight;

    public Transform yRangeUp;
    public Transform yRangeDown;

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);

        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

        GameObject enemie = Instantiate(prefabs[Random.Range(0, prefabs.Length)],spawnPosition, gameObject.transform.rotation);

        prefabs.Find("WhiteSkeleton");
    }
}
