using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItemInterection : ItemInteraction
{
    [SerializeField] GameObject GotItem;
    [SerializeField] int ItemID;
    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();
      
            if (Input.GetKeyUp(KeyCode.R) & CanTrack)
            {
                GotItem.SetActive(true);
                Inventory.LastItemID = Inventory.LastItemID < ItemID ? ItemID : Inventory.LastItemID;
            }

    }
}
