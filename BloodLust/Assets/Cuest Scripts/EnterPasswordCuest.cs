using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPasswordCuest : Quests
{
    // Start is called before the first frame update
    string password = "";

    [SerializeField] int NewPassword=9999;
    [SerializeField] Text[] PS = new Text[4];
    [SerializeField] Button[] buttons = new Button[4];
    

    void Start()
    {
        if(NewPassword>999 & NewPassword<10000)
        password= NewPassword.ToString();
        buttons[0].onClick.AddListener(() => { Button_Click(0); });
        buttons[1].onClick.AddListener(() => { Button_Click(1); });
        buttons[2].onClick.AddListener(() => { Button_Click(2); });
        buttons[3].onClick.AddListener(() => { Button_Click(3); });
        AplyButton.onClick.AddListener(() => { ApplyButton_Click(); });
    }

    public void Button_Click(int i)
    {
        if (Convert.ToInt32(PS[i].text)<9)
            PS[i].text=(Convert.ToInt32(PS[i].text) + 1).ToString();
        else
            PS[i].text = "0";
    }
    
    public void ApplyButton_Click()
    {
        if ((PS[0].text + PS[1].text + PS[2].text + PS[3].text) == password)
        {
            Quest.SetActive(false);
            Movement.CanShoot = true;
            Movement.CanMove = true;
            GetItem.SetActive(true);
            interf.ShowPanel(LowerPanelMessage);
        }
        else
        {
            StartCoroutine(ReturnColor(AplyButton));
        }   
    }


}
