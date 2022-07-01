using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float fTime;
    private float curva = 12;
    private int cantidadEnemigos = 4;

    private void Start()
    {
        // InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
        SpawnEnemies(5);
    }

    private void Update()
    {
        fTime += Time.deltaTime;

        //Curva de dificultad
        if(fTime > curva)
        {
            SpawnEnemies(cantidadEnemigos);
            fTime = 0;
            curva = curva - 0.5f;
            cantidadEnemigos = cantidadEnemigos + 1;
        }
        if(curva < 1)
        {
            curva = 1;
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
