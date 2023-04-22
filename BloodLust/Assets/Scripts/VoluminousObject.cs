using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoluminousObject : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (Mathf.Abs(transform.position.x - player.position.x) <= 7 & Mathf.Abs(transform.position.y - player.position.y) <= 7)
            {
                if (player != null && transform.position.y > player.position.y)
                    GetComponent<SpriteRenderer>().sortingOrder = 3;
                else if (player != null && transform.position.y < player.position.y)
                    GetComponent<SpriteRenderer>().sortingOrder = 110;
            }

        }
    }
}
