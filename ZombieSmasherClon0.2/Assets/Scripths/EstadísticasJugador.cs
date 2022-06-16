using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadísticasJugador : MonoBehaviour
{
    public int healthMax;
    public int helthCurrent;

    private void Start()
    {
        helthCurrent = healthMax;
    }
}
