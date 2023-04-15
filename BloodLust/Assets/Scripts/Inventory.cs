using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject[] Stuff = new GameObject[3];
    [SerializeField] GameObject[] SItems = new GameObject[2];

    [SerializeField] GameObject Inv;
    [SerializeField] bool IsActive;

    public static int LastItemID=-1;
    public static string ActiveItem = "Defoult";



    // Start is called before the first frame update
    void Start()
    {
        Inv.SetActive(false);
        IsActive = false;

        for (int i = 0; i < Stuff.GetLength(0); i++)
        {
            Stuff[i].SetActive(false);
        }

        for (int i = 0; i < SItems.GetLength(0); i++)
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
        Movement.CanShoot =(EventSystem.current.IsPointerOverGameObject()) ? false :(Movement.CanMove)? true: false;
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
