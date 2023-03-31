using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject AutorsInfo;
    // Start is called before the first frame update
    void Start()
    {
        AutorsInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonAutorsInfo()
    {
        AutorsInfo.SetActive(true);
    }

    public void ButtonBeck()
    {
        AutorsInfo.SetActive(false);
    }
}
