using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPasswordCuest : MonoBehaviour
{
    // Start is called before the first frame update
    string password = "";

    [SerializeField] GameObject Quest;
    [SerializeField] GameObject GetItem;
    [SerializeField] int NewPassword=9999;
    [SerializeField] Button AplyButton;
    [SerializeField] string LowerPanelMessage = "Найден прудмет: ключ";
    [SerializeField] Text[] PS = new Text[4];
    [SerializeField] Button[] buttons = new Button[4];
    

    void Start()
    {
        if(NewPassword>999 & NewPassword<10000)
        password= NewPassword.ToString();
        buttons[0].onClick.AddListener(() => { Button1_Click(); });
        buttons[1].onClick.AddListener(() => { Button2_Click(); });
        buttons[2].onClick.AddListener(() => { Button3_Click(); });
        buttons[3].onClick.AddListener(() => { Button4_Click(); });
        AplyButton.onClick.AddListener(() => { ApplyButton_Click(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1_Click()
    {
        if (Convert.ToInt32(PS[0].text)<9)
            PS[0].text=(Convert.ToInt32(PS[0].text) + 1).ToString();
        else
            PS[0].text = "0";
    }
    public void Button2_Click()
    {
        if (Convert.ToInt32(PS[1].text) < 9)
            PS[1].text = (Convert.ToInt32(PS[1].text) + 1).ToString();
        else
            PS[1].text = "0";
    }
    public void Button3_Click()
    {
        if (Convert.ToInt32(PS[2].text) < 9)
            PS[2].text = (Convert.ToInt32(PS[2].text) + 1).ToString();
        else
            PS[2].text = "0";
    }
    public void Button4_Click()
    {
        if (Convert.ToInt32(PS[3].text) < 9)
            PS[3].text = (Convert.ToInt32(PS[3].text) + 1).ToString();
        else
            PS[3].text = "0";
    }

    IEnumerator ReturnColor()
    {
        yield return new WaitForSeconds(0.5f);
            AplyButton.GetComponent<Image>().color = new Color(90/255f, 90/255f, 90/255f);
    }
    public void ApplyButton_Click()
    {
        if ((PS[0].text + PS[1].text + PS[2].text + PS[3].text) == password)
        {
            Quest.SetActive(false);
            Movement.CanShoot = true;
            Movement.CanMove = true;
            GetItem.SetActive(true);
            Interface.MessageText = LowerPanelMessage;
            Interface.ShowPanel=true;
        }
        else
        {
            AplyButton.GetComponent<Image>().color = new Color(1, 0, 0);
            StartCoroutine(ReturnColor());
        }   
    }


}
