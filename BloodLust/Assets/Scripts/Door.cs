using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ItemInteraction
{
    [SerializeField] char axis;
    [SerializeField] GameObject HideWall;
    [SerializeField] GameObject ShowWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();
        if (Input.GetKeyUp(KeyCode.R) & CanTrack)
        {
            if(axis == 'X')
            {
                player.position = transform.position.x>player.position.x? new Vector3(transform.position.x + 1, transform.position.y) : new Vector3(transform.position.x - 1, transform.position.y);
            }
        }
        
    }
}
