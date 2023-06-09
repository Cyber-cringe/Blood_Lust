using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    [SerializeField] Text BulletsInfo;
    [SerializeField] private AudioSource PistolReload;

    void Start()
    {
        BulletsInfo.text = "x" + Movement.Pistolnumber_of_bullets.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.Pistolreload == 8)
        {
            Movement.Pistolreload = 0;
            Movement.fireTimer = 2f;
            PistolReload.Play();
        }

        BulletsInfo.text = "x" + Movement.Pistolnumber_of_bullets.ToString();
    }
}