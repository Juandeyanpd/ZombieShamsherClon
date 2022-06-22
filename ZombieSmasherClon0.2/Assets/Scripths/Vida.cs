using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    public Animator animator;

    void Start()
    {
        life = hearts.Length;
    }

    void Checklife()
    {

        if(life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");
        }
        else if(life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");
        }
        else if(life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");
        }
    }

    public void PlayerDamaged()
    {
        life--;
        Checklife();
    }
}
