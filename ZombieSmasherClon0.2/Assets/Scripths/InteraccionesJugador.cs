using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionesJugador : MonoBehaviour
{
    //Audio de muerte
    public AudioSource die;

    public EstadísticasJugador EstadoDelJugador;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && Input.GetKeyDown("Fire1"))
        {
            other.gameObject.SetActive(false);
        }
        if(other.tag == "Human" && Input.GetKeyDown("Fire1"))
        {
            other.gameObject.SetActive(false);
            //SceneManager.LoadScene
        }
    }
}
