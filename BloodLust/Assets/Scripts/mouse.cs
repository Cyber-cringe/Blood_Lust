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
    public Transform knife;
    public static Animator anim;
    [SerializeField] float meleeSpeed;
    float timeUntileMellee;
    bool h;
    bool k;


    [SerializeField] public static bool c = false;
    //public bool f = false;
    public void Start()
    {
        //knife.GetComponent<Collider2D>().enabled = false;
    }

    public void Update()
    {
        if (WeaphonScript.currentWeaphonIndex == 1 && WeaphonScript.currentGun != null)
        {
            //anim.SetTrigger("Play");
            anim = WeaphonScript.currentGun.transform.GetComponent<Animator>();
            knife.gameObject.SetActive(true);
            knife.rotation = WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<Transform>().rotation;
            knife.position = WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<Transform>().position;
            knife.GetComponent<SpriteRenderer>().flipY = WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY;
        }
        else
        {
            knife.gameObject.SetActive(false);
        }
        if (true)
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
                        //anim.SetBool("Flip", true);
                        //anim = WeaphonScript.currentGun.transform.GetComponent<Animator>();
                        WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY = true;

                    }
                    WeaphonScript.currentGun.GetComponent<SpriteRenderer>().flipY = false;
                    c = true;

                }
                else
                {

                    if (WeaphonScript.currentWeaphonIndex == 1)
                    {
                        //anim.SetBool("Flip", true);
                        //anim = WeaphonScript.currentGun.transform.GetComponent<Animator>();
                        WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY = true;

                    }
                    Character2.GetComponent<SpriteRenderer>().flipX = true;
                    WeaphonScript.currentGun.GetComponent<SpriteRenderer>().flipY = true;
                }

            }
            if ((a <= 90) || (a >= 270))
            {
                if (c == true)
                {
                    if (WeaphonScript.currentWeaphonIndex == 1)
                    {
                        //anim.SetBool("Flip", false);
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
                    if (WeaphonScript.currentWeaphonIndex == 1)
                    {
                        ///anim.SetBool("Flip", true);
                        WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY = true;

                    }
                }

            }
            if (WeaphonScript.currentWeaphonIndex == 1)
            {
                if (timeUntileMellee <= 0f)
                {


                    if (WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY == true && Input.GetMouseButtonDown(0))
                    {
                        anim.SetBool("Flip", true);
                        anim.SetTrigger("Play");
                        knife.GetComponent<Collider2D>().enabled = true;
                        timeUntileMellee = meleeSpeed;
                    }
                    else
                    if (WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY == true)
                    {
                        knife.GetComponent<Collider2D>().enabled = false;
                    }

                    if (WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY == false && Input.GetMouseButtonDown(0))
                    {
                        anim.SetBool("Flip", false);
                        anim.SetTrigger("Play");
                        knife.GetComponent<Collider2D>().enabled = true;
                        timeUntileMellee = meleeSpeed;
                    }
                    else
                    if (WeaphonScript.currentGun.transform.Find("Knife1").GetComponent<SpriteRenderer>().flipY == false)
                    {
                        knife.GetComponent<Collider2D>().enabled = false;
                    }
                }
                else
                {
                    timeUntileMellee -= Time.deltaTime;
                }
            }
        }
    }
}