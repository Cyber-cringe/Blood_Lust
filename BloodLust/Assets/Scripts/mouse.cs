using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public float a;
    public float e;
    public Transform Gun;
    public Transform Gun2;
    public Transform Character;
    public SpriteRenderer spi;
    public bool c= false;
   
    public void Update()
    {
        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        a = (Gun.GetComponent<Transform>().eulerAngles.z);
        Debug.Log(a);

        if (a > 90  && a<270 && c == false) 
        {
            Character.GetComponent<Transform>().localScale = new Vector3(((Character.GetComponent<Transform>().localScale.x) * -1),
            Character.GetComponent<Transform>().localScale.y );
            Gun2.GetComponent<SpriteRenderer>().flipY = true;
           // Gun2.GetComponent<SpriteRenderer>().flipX = false;
            //Gun2.GetComponent<Transform>().position = new Vector3(((Gun.GetComponent<Transform>().position.x) * (-1)), Gun.GetComponent<Transform>().position.y);
            c = true;
        }
        if ((a <= 90 && c == true) || (a >= 270 && c == true))
        {
            Character.GetComponent<Transform>().localScale = new Vector3(((Character.GetComponent<Transform>().localScale.x) * -1),
            Character.GetComponent<Transform>().localScale.y);
            Gun2.GetComponent<SpriteRenderer>().flipY = false;
            //Gun2.GetComponent<SpriteRenderer>().flipX = true;
            //Gun2.GetComponent<Transform>().position = new Vector3(((Gun.GetComponent<Transform>().position.x)*(-1)), Gun.GetComponent<Transform>().position.y);
            c = false;
        }

    }
}