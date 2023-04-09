using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandGun: MonoBehaviour
{
    public static int number_of_bullets = 16;
    [SerializeField] Text BulletsInfo;

    void Start()
    {
        BulletsInfo.text = "x" + number_of_bullets.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.HandGunreload == 8)
        {
            Movement.HandGunreload = 0;
            Movement.fireTimer = 3f;
        }
        BulletsInfo.text = "x" + number_of_bullets.ToString();
    }
}
