using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    Color Green = new Color(0 , 75 / 255f, 0 , 175 / 255f);
    Color Red = new Color(75 / 255f, 0, 0, 175 / 255f);
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = 1;
        GetComponent<Image>().color = Green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOffSounds()
    {
        
        if(AudioListener.volume > 0)
        {
            AudioListener.volume = 0;
            GetComponent<Image>().color = Red;
        }
        else
        {
            AudioListener.volume = 1;
            GetComponent<Image>().color = Green;
        }
    }
}
