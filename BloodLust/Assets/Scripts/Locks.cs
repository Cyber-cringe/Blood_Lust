using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locks : ItemForResearch
{
    [SerializeField] string AlreadyActiveText = "Здесь больше ничего нет.";
    //[SerializeField] byte LockID;
    //public bool Passed  { get; set; }
    [SerializeField] private string ID;
    public static string MainActiveID { get; private set; }
  
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
        if (Input.GetKeyUp(KeyCode.R) && !NextStepOrQuest.activeSelf && CanTrack && !LQ.CheckedPassedID(ID) && (MainCharacter.ActiveItem == ItemForUnlock || ItemForUnlock == "Default"))
        {
            NextStepOrQuest.SetActive(true);
            MainActiveID = ID;
            LQ.StartWork();
            InfoCanvas.SetActive(false);
            Movement.CanShoot = false;
            Movement.CanMove = false;
            
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && !LQ.CheckedPassedID(ID) && MainCharacter.ActiveItem != ItemForUnlock && ItemForUnlock != "Default")
        {
            interf.ShowPanel(ErrorText);
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && LQ.CheckedPassedID(ID))
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
