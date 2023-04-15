using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ItemInteraction
{
    [SerializeField] char axis;
    private bool IsOpen;
    [SerializeField] GameObject DoorSprite;
    //[SerializeField] GameObject barrier;
    // Start is called before the first frame update
    void Start()
    {
        SetText();
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();

        if (axis == 'Y')
        {
            if (player != null && transform.position.y > player.position.y)
                DoorSprite.GetComponent<SpriteRenderer>().sortingOrder = 3;
            else
                DoorSprite.GetComponent<SpriteRenderer>().sortingOrder = 110;
        }


        if (Input.GetKeyUp(KeyCode.R) && CanTrack && (MainCharacter.ActiveItem == ItemForUnlock || IsOpen || ItemForUnlock=="Default"))
        {
            if(axis == 'X')
            player.position = transform.position.x > player.position.x? new Vector3(transform.position.x + 3, transform.position.y) :new Vector3(transform.position.x - 3, transform.position.y);
            
            if (axis == 'Y')
            {
                if (transform.position.y >= player.position.y)
                {
                    player.position = new Vector3(transform.position.x, transform.position.y + 3);
                }

                else
                {
                    player.position = new Vector3(transform.position.x, transform.position.y - 3);
                }
                
            }
            IsOpen= true;
        }

        if (Input.GetKeyUp(KeyCode.R) & CanTrack & MainCharacter.ActiveItem != ItemForUnlock &  !IsOpen & ItemForUnlock != "Default")
        {
            interf.ShowPanel(ErrorText);
        }
        
    }
}
