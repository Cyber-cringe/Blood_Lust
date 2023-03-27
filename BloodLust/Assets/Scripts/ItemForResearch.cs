using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemForResearch :  ItemInteraction
{
    [SerializeField] protected GameObject NextStepOrQuest;
    [SerializeField] protected Button ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        SetText();
        NextStepOrQuest.SetActive(false);
        ExitButton.onClick.AddListener(() => { ExitButton_Click(); });
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();

        if (Input.GetKeyUp(KeyCode.R) & CanTrack)
        {
            NextStepOrQuest.SetActive(true);
            InfoCanvas.SetActive(false);
            Movement.CanShoot = false;
            Movement.CanMove = false;


        }

    }

    public void ExitButton_Click()
    {
        NextStepOrQuest.SetActive(false);
        Movement.CanShoot = true;
        Movement.CanMove = true;
    }
}
