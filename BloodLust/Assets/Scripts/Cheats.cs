using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
    [SerializeField] InputField CheatsPanel;
    // Start is called before the first frame update
    void Start()
    {
       // CheatsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( CheatsPanel.text == "abc")
        {
            MainCharacter.mana = 4;
            CheatsPanel.text = null;
        }
    }
}
