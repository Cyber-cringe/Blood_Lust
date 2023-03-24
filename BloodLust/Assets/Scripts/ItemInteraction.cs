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
            if (Mathf.Abs(transform.position.x - player.position.x) <= 8 & Mathf.Abs(transform.position.y - player.position.y) <= 5)
                InfoCanvas.SetActive(true);
            else
                InfoCanvas.SetActive(false);
        }
    }

    protected void SetText()
    {
        TextCanvas.text = "[R]- " + text;
    }

}
