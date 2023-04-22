using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleItemInterection : ItemInteraction
{
    [SerializeField] string TextForInfoPanel;
    [SerializeField] string AlreadyActiveText = "Здесь больше ничего нет.";
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
            interf.ShowPanel(TextForInfoPanel);
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && !GotItem.activeSelf && MainCharacter.ActiveItem != ItemForUnlock && ItemForUnlock != "Default")
        {
            interf.ShowPanel(ErrorText);
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && GotItem.activeSelf )
        {
            interf.ShowPanel(AlreadyActiveText);
        }

    }
}
