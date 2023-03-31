using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ItemInteraction
{
    [SerializeField] char axis;
    [SerializeField] string ItemForUnlock;
    private bool IsOpen;
    [SerializeField] string ErrorText="����� ����.";
    [SerializeField] GameObject Wall;
    [SerializeField] GameObject DoorSprite;
    [SerializeField] GameObject barrier;
    // Start is called before the first frame update
    void Start()
    {
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();

        
        if (Input.GetKeyUp(KeyCode.R) & CanTrack & (MainCharacter.ActiveItem == ItemForUnlock | IsOpen | ItemForUnlock=="Default"))
        {
            if(axis == 'X')
            player.position = transform.position.x > player.position.x? new Vector3(transform.position.x + 1, transform.position.y) :new Vector3(transform.position.x - 1, transform.position.y);
            
            if (axis == 'Y')
            {
                if (transform.position.y > player.position.y)
                player.position = new Vector3(transform.position.x, transform.position.y + 3);
                else
                player.position = new Vector3(transform.position.x, transform.position.y - 3);
            }
            IsOpen= true;
        }
        if (Input.GetKeyUp(KeyCode.R) & CanTrack & MainCharacter.ActiveItem != ItemForUnlock &  !IsOpen & ItemForUnlock != "Default")
        {
            Interface.MessageText = ErrorText;
            Interface.ShowPanel = true;
        }
        
    }
}
