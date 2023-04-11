using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] protected GameObject Sprite;
    //[SerializeField] float deviation = 0f;
    [SerializeField] bool Is3D = true;
    [SerializeField] protected GameObject InfoCanvas;
    [SerializeField] Text TextCanvas;
    [SerializeField] protected string ItemForUnlock;
    [SerializeField] protected string ErrorText = "Ошибка.";
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
            if (Mathf.Abs(transform.position.x - player.position.x) <= 5 & Mathf.Abs(transform.position.y - player.position.y) <= 4)
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

    protected void ChangePlayerPos()
    {
        if (Is3D && CanTrack)
        {
            if (player != null && transform.position.y> player.position.y)
                Sprite.GetComponent<SpriteRenderer>().sortingOrder = 3;
            else if (player != null && transform.position.y < player.position.y)
                Sprite.GetComponent<SpriteRenderer>().sortingOrder = 110;
        }

    }

    protected void SetText()
    {
        TextCanvas.text = "[R]- " + text;
    }

}
