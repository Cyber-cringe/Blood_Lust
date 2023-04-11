using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDead : MonoBehaviour
{
    [SerializeField] private AudioSource DEad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss.Enemies_HP <= 0)
        {

           
            Boss.Enemies_HP = 2;
        }

    }
}
