using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movimiento
    public float velocidadDeMovimiento;

    public Transform[] puntosDeMovimiento;

    public float distanciaMinima;

    private int siguientePaso = 0;

    //Control visual de personaje
    private SpriteRenderer SpriteRenderer;
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(transform.tag == "Enemy" && collision)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
