using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject AutorsInfo;
    [SerializeField] GameObject History;
    // Start is called before the first frame update
    void Start()
    {
        AutorsInfo.SetActive(false);
        History.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart()
    {
        History.SetActive(true);
        //SceneManager.LoadScene(1);
    }
    public void Button1()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtonAutorsInfo()
    {
        AutorsInfo.SetActive(true);
    }

    public void ButtonBeck()
    {
        AutorsInfo.SetActive(false);
    }

    public void ButtonContinueGame()
    {
        SceneManager.LoadScene(1);
    }
}
