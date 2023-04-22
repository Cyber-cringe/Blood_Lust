using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemInterection : ItemForResearch
{
    [SerializeField] GameObject GotItem;
    [SerializeField] string AlreadyActiveText = "Здесь больше ничего нет.";
    // Start is called before the first frame update
    void Start()
    {
        SetText();
        ExitButton.onClick.AddListener(() => { ExitButton_Click(); });
        NextStepOrQuest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();
        ChangePlayerPos();
        if (Input.GetKeyUp(KeyCode.R) && CanTrack && !GotItem.activeSelf && (MainCharacter.ActiveItem == ItemForUnlock || ItemForUnlock == "Default"))
        {
            NextStepOrQuest.SetActive(true);
            InfoCanvas.SetActive(false);
            Movement.CanShoot = false;
            Movement.CanMove = false;
            //WeaphonScript.totalWeaphons += 1;
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
