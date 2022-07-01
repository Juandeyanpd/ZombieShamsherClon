using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{    
    public static SoundManager Instance;
   
    public AudioSource grabadora;

    public AudioClip[] sonido;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSound(int index)
    {
        grabadora.PlayOneShot(sonido[index]);
    }
}
