using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
}
