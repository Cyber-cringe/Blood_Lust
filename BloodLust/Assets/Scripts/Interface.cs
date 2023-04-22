using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Interface : MonoBehaviour
{
    [SerializeField] GameObject LowerPanel;
    [SerializeField] Text PanelText;
    //public static  MessageText;
    // Start is called before the first frame update
    IEnumerator ShowLPanel(string message)
    {
        LowerPanel.SetActive(true);
        PanelText.text = message;
        yield return new WaitForSeconds(3f);
        LowerPanel.SetActive(false);
    }
    
    void Start()
    {
        LowerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowPanel(string message)
    {
        if (!LowerPanel.activeSelf)
        {

            StartCoroutine(ShowLPanel(message));
        }
    }
}

   

  

