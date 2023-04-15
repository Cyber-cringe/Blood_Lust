using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] protected GameObject Sprite;
    [SerializeField] bool Is3D = true;
    [SerializeField] protected GameObject InfoCanvas;
    [SerializeField] Text TextCanvas;
    [SerializeField] protected string ItemForUnlock;
    [SerializeField] protected string ErrorText = "Ошибка.";
    [SerializeField] string text = "взаимодействовать";
    [SerializeField] protected Interface interf;
    protected Transform player;
    protected bool CanTrack;

    void Start() //устанавливаем текст для взаимодействия с предметом
    {
        InfoCanvas.SetActive(false);
    }

    protected void PrintInteraction() // Если игрок находится в предеделах заданного расстояния от предмета, то взаимодействие с ним становится возможным,
        // отображается текст взаимодействия
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

    protected void ChangePlayerPos() //изменение слоя, на котором находится объект, для создания видимости, что предмет объемный
    {
        if (Is3D && CanTrack)
        {
            if (player != null && transform.position.y> player.position.y)
                Sprite.GetComponent<SpriteRenderer>().sortingOrder = 3;
            else if (player != null && transform.position.y < player.position.y)
                Sprite.GetComponent<SpriteRenderer>().sortingOrder = 110;
        }
    }

    protected void SetText() // изменение текста взаимодействия с предметом
    {
        TextCanvas.text = "[R]- " + text;
    }

}
