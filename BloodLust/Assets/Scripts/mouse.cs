using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{

    public float a;
    public float e;
    public Transform Gun;

    public Transform Character;
    public Transform Character2;
    public SpriteRenderer spi;

    [SerializeField] public static bool c = false;
    //public bool f = false;

    public void Update()
    {

        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        a = (Gun.GetComponent<Transform>().eulerAngles.z);

        if (a > 90 || a < 270)
        {

            if (c == false)
            {
                //WeaphonScript.currentGun.transform.Find("firepoint").position += new Vector3(0, 0.1f, 0);
                Character2.GetComponent<SpriteRenderer>().flipX = true;
                if (WeaphonScript.currentWeaphonIndex == 1)
                {
                    WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY = true;

                }
                WeaphonScript.currentGun.GetComponent<SpriteRenderer>().flipY = false;
                c = true;

            }
            else

                Character2.GetComponent<SpriteRenderer>().flipX = true;
            WeaphonScript.currentGun.GetComponent<SpriteRenderer>().flipY = true;

        }
        if ((a <= 90) || (a >= 270))
        {
            if (c == true)
            {
                if (WeaphonScript.currentWeaphonIndex == 1)
                {
                    WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY = false;

                }
                Character2.GetComponent<SpriteRenderer>().flipX = false;
                WeaphonScript.currentGun.GetComponent<SpriteRenderer>().flipY = false;
                c = false;
            }
            else
            {
                Character2.GetComponent<SpriteRenderer>().flipX = true;
                WeaphonScript.currentGun.GetComponent<SpriteRenderer>().flipY = false;
                WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY = true;
            }

        }


    }
}