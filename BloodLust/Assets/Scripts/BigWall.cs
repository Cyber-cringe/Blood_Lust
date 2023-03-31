using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWall : MonoBehaviour
{
    private protected Transform player;
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject DoorSprite;
    [SerializeField] GameObject barrier;
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
            if ( player.position.y > transform.position.y)
            {
                barrier.SetActive(true);
                barrier.GetComponent<BoxCollider2D>().enabled = true;
                Wall.GetComponent<BoxCollider2D>().enabled = false;
                Wall.GetComponent<SpriteRenderer>().sortingOrder = 109;
                DoorSprite.GetComponent<SpriteRenderer>().sortingOrder = 110;
                Wall.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 110f / 255f);
            }
            if(barrier.GetComponent<Transform>().position.y > player.position.y)
            {
                barrier.SetActive(false);
                Wall.GetComponent<SpriteRenderer>().sortingOrder = 2;
                Wall.GetComponent<BoxCollider2D>().enabled = true;
                DoorSprite.GetComponent<SpriteRenderer>().sortingOrder = 3;
                Wall.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            }
        }

    }
}
