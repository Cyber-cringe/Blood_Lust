using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemInterection : ItemInteraction
{
    [SerializeField] GameObject Quest;
    [SerializeField] GameObject GotItem;
    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        PrintInteraction();
        if (player != null)
        {
            if (Input.GetKeyUp(KeyCode.R) & Mathf.Abs(transform.position.x - player.position.x) <= 8
                & Mathf.Abs(transform.position.y - player.position.y) <= 5 & !GotItem.activeSelf)
            {
                Quest.SetActive(true);
                Movement.CanShoot = false;
                Movement.CanMove = false;
            }
        }
    }
}
