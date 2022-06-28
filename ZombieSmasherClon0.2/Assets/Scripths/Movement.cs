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

    [Header("Es Humano?")]
    //Identificar si es enemigo o no
    public bool isHuman;

    //Control visual de personaje
    private SpriteRenderer SpriteRenderer;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        vida = FindObjectOfType<Vida>();

        Girar();
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

    private void Girar()
    {
        if(transform.position.x < puntosDeMovimiento[siguientePaso].position.x)
        {
            SpriteRenderer.flipX = true;
        }
        else
        {
            SpriteRenderer.flipX = false;
        }
    }


    private void OnMouseDown()
    {
        Destroy(gameObject);

        /*if(isHuman == false)
        {
            Score ==
        }*/

        if(isHuman == true)
        {
            vida.PlayerDamaged(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.tag == "Enemy")
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
