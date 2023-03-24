using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPasswordCvwst : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject MainWindow;
    void Start()
    {
        MainWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonX_Click()
    {
        MainWindow.SetActive(false);
    }
}
