using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;


    void Start()
    {
        life = hearts.Length;
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

        }
    }
}
