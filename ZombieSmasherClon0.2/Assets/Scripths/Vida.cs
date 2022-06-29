using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Vida : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;


    //Cronómetro
    [Header("Reloj")]
    [Tooltip("Tiempo inicial en segundos")]
    public int tiempoInicial;

    [Tooltip("Escala del tiempo del reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    [SerializeField] private TMP_Text myText;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;
    private float escalaDeTiempoInicial;


    void Start()
    {
        life = hearts.Length;
        //Cronómetro
        //Establecer la escala de tiempo original
        escalaDeTiempoInicial = escalaDeTiempo;

        //Inicializamos la variable que acumula los tiempos que tiene cada frame con el tiempo inicial
        tiempoAMostrarEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }

    private void Update()
    {
        //La siguiente variable representa el tiempo de cada frame considerando la escala de tiempo
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
        //La siguiente variable va acumulando el tiempo transcurrido para luego mostrarlo en el reloj
        tiempoAMostrarEnSegundos += tiempoDelFrameConTimeScale;
        ActualizarReloj(tiempoAMostrarEnSegundos);
        
    }

    void Checklife()
    {

        if(life < 1)
        {
            hearts[0].SetActive(false);
        }
        else if(life < 2)
        {
            hearts[1].SetActive(false);
        }
        else if(life < 3)
        {
            hearts[2].SetActive(false);
        }

        RestartScene();
    }

    public void PlayerDamaged()
    {
        life--;
        Checklife();
    }

    public void RestartScene()
    {
        if(life < 1)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void ActualizarReloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        //Asegurar que el tiempo no sea negativo
        if (tiempoEnSegundos < 0)
        {
            tiempoEnSegundos = 0;
        }

        //Calculas tiempo en segundos y minutos
        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        //Crear la cadena de carácteres con 2 dígitos para los minutos y segundos, separados por ":"
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");

        //Actualizar el elemento de texto de UI con la cadena de carácteres
        myText.text = textoDelReloj;
    }

    private void Score()
    {

    }
}
