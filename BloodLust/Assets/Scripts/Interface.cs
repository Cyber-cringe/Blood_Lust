using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Interface : MonoBehaviour
{
    [SerializeField] GameObject LowerPanel;
    public static bool ShowPanel;
    [SerializeField] Text PanelText;
    public static string MessageText;
    // Start is called before the first frame update
    IEnumerator ShowLPanel()
    {
        LowerPanel.SetActive(true);
        PanelText.text = MessageText;
        yield return new WaitForSeconds(3f);
        LowerPanel.SetActive(false);
        ShowPanel = false;
    }
    
    void Start()
    {
        LowerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowPanel & !LowerPanel.activeSelf)
        {
 
            StartCoroutine(ShowLPanel());
        }
    }

   

  
}
