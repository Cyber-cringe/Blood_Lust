using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItemInterection : ItemInteraction
{
    [SerializeField] string TextForInfoPanel;
    [SerializeField] GameObject GotItem;
    //[SerializeField] int ItemID;
    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {

        PrintInteraction();
      
        if (Input.GetKeyUp(KeyCode.R) && CanTrack && !GotItem.activeSelf && (MainCharacter.ActiveItem == ItemForUnlock || ItemForUnlock == "Default"))
        {
            GotItem.SetActive(true);
            Interface.MessageText = TextForInfoPanel;
            Interface.ShowPanel = true;
            //Inventory.LastItemID = Inventory.LastItemID < ItemID ? ItemID : Inventory.LastItemID;
        }

        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && !GotItem.activeSelf && MainCharacter.ActiveItem != ItemForUnlock && ItemForUnlock != "Default")
        {
            Interface.MessageText = ErrorText;
            Interface.ShowPanel = true;
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && GotItem.activeSelf && !Interface.ShowPanel)
        {
            Interface.MessageText = "Здесь больше ничего нет.";
            Interface.ShowPanel = true;
        }

    }
}
