using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemInterection : ItemForResearch
{
    [SerializeField] GameObject GotItem;
    [SerializeField] GameObject Sprite;
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
        if (player != null && transform.position.y > player.position.y)
            Sprite.GetComponent<SpriteRenderer>().sortingOrder = 3;
        else if (player != null && transform.position.y < player.position.y)
            Sprite.GetComponent<SpriteRenderer>().sortingOrder = 110;
        PrintInteraction();
        if (Input.GetKeyUp(KeyCode.R) && CanTrack && !GotItem.activeSelf && (MainCharacter.ActiveItem == ItemForUnlock || ItemForUnlock == "Default"))
        {
            NextStepOrQuest.SetActive(true);
            InfoCanvas.SetActive(false);
            Movement.CanShoot = false;
            Movement.CanMove = false;
            WeaphonScript.totalWeaphons = 3;
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && !GotItem.activeSelf && MainCharacter.ActiveItem != ItemForUnlock && ItemForUnlock != "Default")
        {
            Interface.MessageText = ErrorText;
            Interface.ShowPanel = true;
        }
        else if (Input.GetKeyUp(KeyCode.R) && CanTrack && GotItem.activeSelf && !Interface.ShowPanel)
        {
            Interface.MessageText = "����� ������ ������ ���.";
            Interface.ShowPanel = true;
        }
    }
}
