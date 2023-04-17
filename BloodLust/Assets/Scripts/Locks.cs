using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locks : ItemForResearch
{
    [SerializeField] string AlreadyActiveText = "Здесь больше ничего нет.";
    [SerializeField] byte LockID;
    public bool Passed  { get; set; }
    
  
    [SerializeField]  LockQuest LQ;
    // Start is called before the first frame update
    void Start()
    {
        LQ = NextStepOrQuest.GetComponent<LockQuest>();
        SetText();
        ExitButton.onClick.AddListener(() => { ExitButton_Click(); });
        NextStepOrQuest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();
        ChangePlayerPos();
        if (Input.GetKeyUp(KeyCode.R) && !NextStepOrQuest.activeSelf && CanTrack && !Passed && (MainCharacter.ActiveItem == ItemForUnlock || ItemForUnlock == "Default"))
        {
            NextStepOrQuest.SetActive(true);
            LQ.StartWork();
            LQ.PassedLockInd = LockID;
            InfoCanvas.SetActive(false);
            Movement.CanShoot = false;
            Movement.CanMove = false;
            WeaphonScript.totalWeaphons = 3;
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && !Passed && MainCharacter.ActiveItem != ItemForUnlock && ItemForUnlock != "Default")
        {
            interf.ShowPanel(ErrorText);
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && Passed)
        {
            interf.ShowPanel(AlreadyActiveText);
        }
    }

    private new void ExitButton_Click()
    {
        LQ.StopWork();
        NextStepOrQuest.SetActive(false);
        Movement.CanShoot = true;
        Movement.CanMove = true;
    }
}
