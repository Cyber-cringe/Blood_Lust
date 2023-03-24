using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemInterection : ItemForResearch
{
    [SerializeField] GameObject GotItem;
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
            if (Input.GetKeyUp(KeyCode.R) & CanTrack)
            {
                NextStepOrQuest.SetActive(true);
                Movement.CanShoot = false;
                Movement.CanMove = false;
            }
    }
}
