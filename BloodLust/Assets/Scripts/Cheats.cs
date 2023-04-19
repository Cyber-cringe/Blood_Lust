using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheats : MonoBehaviour
{
    [SerializeField] GameObject CheatsPanel;
    InputField field;
    string[] Comands = { "?", "?", "0" };
    float value = 0;
    [SerializeField] GameObject Player;
    Transform PlayerTransform;
    MainCharacter PlayerStat;
    // Start is called before the first frame update
    void Start()
    {
        CheatsPanel.SetActive(false);
        field = CheatsPanel.GetComponent<InputField>();
        PlayerTransform = Player.GetComponent<Transform>();
        PlayerStat = Player.GetComponent<MainCharacter>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            CheatsPanel.SetActive(!CheatsPanel.activeSelf);
            field.text = "";
        }

        if (CheatsPanel.activeSelf && Input.GetKeyUp(KeyCode.Return))
        {
            Comands = (field.text).Split(' ');

            if (Comands[0] == "player")
            {
                switch (Comands[1])
                {
                    case "mana":
                        float.TryParse(Comands[2], out value);
                        PlayerStat.SetMana(value);
                        break;
                    case "HP":
                        float.TryParse(Comands[2], out value);
                        PlayerStat.SetHP(value);
                        break;
                    case "maxHP":
                        float.TryParse(Comands[2], out value);
                        PlayerStat.SetMaxHP(value);
                        break;
                }
            }

            if (Comands[0] == "cartridges")
            {
                switch (Comands[1])
                {
                    case "gun":
                        float.TryParse(Comands[2], out value);
                        Pistol.number_of_bullets = (int)value;
                        break;
                    case "shotgun":
                        float.TryParse(Comands[2], out value);
                        HandGun.number_of_bullets = (int)value;
                        break;
                }
            }
        }


    }
}
