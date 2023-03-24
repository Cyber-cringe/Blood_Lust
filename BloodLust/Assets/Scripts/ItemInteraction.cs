using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] GameObject InfoCanvas;
    [SerializeField] Text TextCanvas;
    [SerializeField] string text = "взаимодействовать";
    protected Transform player;
    protected bool CanTrack;
    // Start is called before the first frame update
    void Start()
    {
        InfoCanvas.SetActive(false);
    }

    protected void PrintInteraction()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (Mathf.Abs(transform.position.x - player.position.x) <= 4 & Mathf.Abs(transform.position.y - player.position.y) <= 3)
            {
                InfoCanvas.SetActive(true);
                CanTrack = true;
            }
            else
            {
                InfoCanvas.SetActive(false);
                CanTrack= false;
            }
        }
    }

    protected void SetText()
    {
        TextCanvas.text = "[R]- " + text;
    }

}
