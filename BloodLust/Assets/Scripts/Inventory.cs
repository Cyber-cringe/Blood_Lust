using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject Inv;
    [SerializeField] bool IsActive;
    public  GameObject[] SItems= new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        Inv.SetActive(false);
        IsActive = false;
        
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

    }



}
