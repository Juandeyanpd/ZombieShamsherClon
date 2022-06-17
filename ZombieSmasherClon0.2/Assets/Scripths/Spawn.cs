using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] prefabs;
    public Transform spawn;

    private void Update()
    {
        Transform go = Instantiate(prefabs.Length, );
    }
}
