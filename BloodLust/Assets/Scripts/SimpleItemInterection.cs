using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItemInterection : ItemInteraction
{
    [SerializeField] string TextForInfoPanel;
    [SerializeField] GameObject GotItem;

    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();
        ChangePlayerPos();

        if (Input.GetKeyUp(KeyCode.R) && CanTrack && !GotItem.activeSelf && (MainCharacter.ActiveItem == ItemForUnlock || ItemForUnlock == "Default"))
        {
            GotItem.SetActive(true);
            Interface.MessageText = TextForInfoPanel;
            Interface.ShowPanel = true;
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
