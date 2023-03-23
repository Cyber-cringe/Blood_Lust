using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] SItems = new GameObject[2];

    [SerializeField] GameObject Inv;
    [SerializeField] bool IsActive;

    public static int LastItemID=-1;
    public static string ActiveItem = "Defoult";



    // Start is called before the first frame update
    void Start()
    {
        LastItemID = PlayerPrefs.GetInt("LastItemID");
        Inv.SetActive(false);
        IsActive = false;
        
        if (LastItemID != -1)
        {
            for (int i = 0; i <= LastItemID; i++)
            {
                SItems[i].SetActive(true);
            }

        }


        for (int i = LastItemID+1; i < SItems.GetLength(0); i++)
        {
            SItems[i].SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.E) & !IsActive )
        {
            IsActive = true;
            Inv.SetActive(true);
        } 
       else if (Input.GetKeyUp(KeyCode.E) & IsActive)
        {
            IsActive = false;
            Inv.SetActive(false);
        }

    }

   
    
    
    public void SetSave()
    {
        PlayerPrefs.SetInt("LastItemID", LastItemID);
    }

    public void RemSave()
    {
        PlayerPrefs.SetInt("LastItemID", -1);
    }


}
