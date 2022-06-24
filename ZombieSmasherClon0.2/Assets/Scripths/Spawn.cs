using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    //Creación de mostruos
    public GameObject[] prefabs;

    public float timeSpawn = 1;
    public float repeatSpawnRate = 3;

    public Transform xRangeLeft;
    public Transform xRangeRight;

    public Transform yRangeUp;
    public Transform yRangeDown;

    //Cada cierto tiempo aumenta la dificultad
    private float time = 0;

    //Text textOfTime;

    private void Start()
    {
        // InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
        SpawnEnemies(10);
    }

    private void Update()
    {
        //Aquí colocaré lo del tiempo y los spawns
        time = time + Time.deltaTime;

        if(time > 10)
        {
            SpawnEnemies(5);
            time = 0;
        }
    }

    public void SpawnEnemies(int cantidadPersonajes)
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        int personajesActuales = 0;
       

        while (personajesActuales < cantidadPersonajes)
        { 
            spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);
            GameObject enemie = Instantiate(prefabs[Random.Range(0, prefabs.Length)],spawnPosition, gameObject.transform.rotation);
            personajesActuales++;
        }

    }
}
