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
    private int curva = 15;
    private int cantidadEnemigos = 1;

    private void Start()
    {
        // InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
        SpawnEnemies(5);
    }

    private void Update()
    {
        fTime += Time.deltaTime;

        //Tiempo real en el juego
        if(fTime > curva)
        {
            SpawnEnemies(cantidadEnemigos);
            fTime = 0;
            curva = 10;
            cantidadEnemigos = 2;
        }
        if(fTime < curva)
        {
            curva = 5;
            cantidadEnemigos = 3;
            fTime = 0;
        }
        if(fTime < curva)
        {
            curva = 2;
            cantidadEnemigos = 4;
            fTime = 0;
        }
        Debug.Log(curva);
        Debug.Log(cantidadEnemigos);

        /*if(fTime > curva && curva == 15)
        {
            SpawnEnemies(cantidadEnemigos = 2);
            fTime = 0;
            curva = 10;
        }
        if(fTime > curva && curva == 10)
        {
            SpawnEnemies(cantidadEnemigos = 3);
            fTime = 0;
            curva = 5;
        }*/


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
