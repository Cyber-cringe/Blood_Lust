using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public static int number_of_bullets = 32;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.Pistolreload == 8)
        {
            Movement.Pistolreload = 0;
            Movement.fireTimer = 4f;
        }
    }
}