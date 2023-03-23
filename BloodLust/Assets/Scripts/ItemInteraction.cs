using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] GameObject InfoCanvas;
    [SerializeField] Transform player;
    [SerializeField] GameObject GotItem;

    // Start is called before the first frame update
    void Start()
    {
        InfoCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player!= null)
        {
            if ( Mathf.Abs(transform.position.x - player.position.x) <= 7 & Mathf.Abs(transform.position.y - player.position.y) <= 5)
            {
                InfoCanvas.SetActive(true);
                if (Input.GetKeyUp(KeyCode.R))
                    GotItem.SetActive(true);
            }
            else
                InfoCanvas.SetActive(false);
        }
        
    }
}
