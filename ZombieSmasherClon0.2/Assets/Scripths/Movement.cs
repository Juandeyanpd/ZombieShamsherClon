using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Matar))]
public class Movement : MonoBehaviour
{
    public float velocidadDeMovimiento;
    private int numeroAleatorio;
    private SpriteRenderer SpriteRenderer;
    public Transform puntoDeMovimiento;

    private void Start()
    {
        //SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntoDeMovimiento.position, velocidadDeMovimiento * Time.deltaTime);
    }
}
