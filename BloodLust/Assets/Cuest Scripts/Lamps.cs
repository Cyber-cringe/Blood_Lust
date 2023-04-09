using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamps : Quests
{

    [SerializeField] Button ResetButton;
    [SerializeField] Button[] lamps = new Button[5];
    private bool[] IsActive = new bool[5];


    // Start is called before the first frame update
    void Start()
    {
        ResetButton_Click();
        lamps[0].onClick.AddListener(() => { ChangeLampsState(1, 3, 4); });
        lamps[1].onClick.AddListener(() => { ChangeLampsState(1, 4); });
        lamps[2].onClick.AddListener(() => { ChangeLampsState(2); });
        lamps[3].onClick.AddListener(() => { ChangeLampsState(3); });
        lamps[4].onClick.AddListener(() => { ChangeLampsState(0, 1, 4); });
        AplyButton.onClick.AddListener(() => { ApplyButton_Click(); });
        ResetButton.onClick.AddListener(() => { ResetButton_Click(); });
    }


    private void ChangeLampsState(params int[] ind)
    {
        for (int i=0; i<ind.GetLength(0); i++)
        {
            if (IsActive[ind[i]]!=null && IsActive[ind[i]]==false)
            {
                IsActive[ind[i]] = true;
                lamps[ind[i]].GetComponent<Image>().color = new Color(230 / 255f, 240 / 255f, 75 / 255f, 175 / 255f);
            }
            else if (IsActive[ind[i]] != null && IsActive[ind[i]] == true)
            {
                IsActive[ind[i]] = false;
                lamps[ind[i]].GetComponent<Image>().color = new Color(220 / 255f, 220 / 255f, 220 / 255f, 175 / 255f);
            }
        }
    }

    public void ApplyButton_Click()
    {
        if (IsActive[0] && IsActive[1] && IsActive[2] && IsActive[3] && IsActive[4])
        {
            Quest.SetActive(false);
            Movement.CanShoot = true;
            Movement.CanMove = true;
            GetItem.SetActive(true);
            Interface.MessageText = LowerPanelMessage;
            Interface.ShowPanel = true;
        }
        else
        {
            StartCoroutine(ReturnColor(AplyButton));
        }
    }

    public void ResetButton_Click()
    {
        for (int i = 0; i < lamps.GetLength(0); i++)
        {
            lamps[i].GetComponent<Image>().color = new Color(220 / 255f, 220 / 255f, 220 / 255f, 175 / 255f);
            IsActive[i] = false;
        }
    }
}
