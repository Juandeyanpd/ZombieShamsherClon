using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadísticasJugador : MonoBehaviour
{
    public int healthMax = 10;
    public int helthCurrent;

    private void Start()
    {
        helthCurrent = healthMax;
    }
}
