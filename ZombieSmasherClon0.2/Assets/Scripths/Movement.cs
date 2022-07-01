using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movimiento")]
    //Movimiento
    public float velocidadDeMovimiento;

    public Transform[] puntosDeMovimiento;

    public float distanciaMinima;

    private int siguientePaso = 0;

    [Header("Vida")]
    //Quitar vida a jugador
    public Vida vida;
    public int damage;
    private int actualdamage;

    [Header("Es Humano?")]
    //Identificar si es enemigo o no
    public bool isHuman;

    //Animación
    public GameObject personaje;
    public GameObject explosion;

    private void Start()
    {
        vida = FindObjectOfType<Vida>();

        personaje.SetActive(true);
        explosion.SetActive(false);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosDeMovimiento[siguientePaso].position, velocidadDeMovimiento * Time.deltaTime);

        if(Vector2.Distance(transform.position, puntosDeMovimiento[siguientePaso].position) < distanciaMinima)
        {
            siguientePaso += 1;
            if(siguientePaso >= puntosDeMovimiento.Length)
            {
                siguientePaso = 0;
            }
        }

    }

    private void OnMouseDown()
    {

        if (actualdamage >= damage )
        {

            personaje.SetActive(false);
            velocidadDeMovimiento = 0;
            explosion.SetActive(true);
            SoundManager.Instance.SetSound(1);
            Destroy(gameObject, 1f);
        }

        if(isHuman == true)
        {
            personaje.SetActive(false);
            velocidadDeMovimiento = 0;
            explosion.SetActive(true);
            SoundManager.Instance.SetSound(0);
            vida.PlayerDamaged();
            Destroy(gameObject, 1f);
        }
        actualdamage++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHuman == false)
        {
            Destroy(gameObject);
            vida.PlayerDamaged();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
