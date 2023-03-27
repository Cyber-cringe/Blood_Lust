using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPasswordCvwst : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int NewPassword;
    int password = 999;
    Text[] PS = new Text[3]; 
    void Start()
    {
        if(NewPassword>99 & NewPassword<1000)
        password= NewPassword;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1_Click()
    {
        /*if (password[0].text<10)
            password[0] += 1;
        else
            passwordd[0] = 0;
        BS[0].text = password[0];
    }
    
    public void Button2_Click()
    {
        if (password[1] < 10)
            password[1] += 1;
        else
            password[1] = 0;
        BS[1].text = passwordd[1];*/
    }
}
