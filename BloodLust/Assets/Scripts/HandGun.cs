using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun: MonoBehaviour
{
    public static int number_of_bullets = 16;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.HandGunreload == 8)
        {
            Movement.HandGunreload = 0;
            Movement.fireTimer = 3f;
        }
    }
}
