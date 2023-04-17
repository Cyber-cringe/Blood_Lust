using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossRoom : MonoBehaviour
{
    [SerializeField] GameObject HealthBar;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (Mathf.Abs(transform.position.x - player.position.x) <= 35 & Mathf.Abs(transform.position.y - player.position.y) <= 35)
            {
                HealthBar.SetActive(true);
            }
            else
            {
                HealthBar.SetActive(false);
            }
        }
    }

    
}
