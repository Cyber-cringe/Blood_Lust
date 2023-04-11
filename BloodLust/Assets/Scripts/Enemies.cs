using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Transform target;
    public Transform picture;
    public Transform picture2;
    public Transform picture3;
    public Transform picture4;
    public Transform Rotation;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public int Enemies_HP = 30;
    public float KnockbackPower = 1000;
    public float KnockbackDuration = 1;
    public bool c = false;
    public float a;

    public void Update()
    {
        //public Transform picture;

        picture.position = transform.position;
        picture2.position = transform.position;
        picture3.position = transform.position;
        picture4.position = transform.position;
        picture2.gameObject.SetActive(false);
        picture.gameObject.SetActive(false);
        picture3.gameObject.SetActive(false);
        picture4.gameObject.SetActive(false);
        a = Rotation.eulerAngles.z;

        if ((a > 0 && a < 45) || (a > 315 && a < 360))
        {
            picture2.gameObject.SetActive(true);
        }
        else 
        {
            picture2.gameObject.SetActive(false);

        }

        if (a > 135 && a < 225)
        {
            picture3.gameObject.SetActive(true);
        }
        else
        {
            picture3.gameObject.SetActive(false);

        }

        if (a > 45 && a < 135)
        {
            picture4.gameObject.SetActive(true);
            // picture.GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            picture4.gameObject.SetActive(false);

        }
        if (a > 225 && a < 315)
        {
            picture.gameObject.SetActive(true);
           // picture.GetComponent<SpriteRenderer>().flipX = false;
             
        }
        else
        {
            picture.gameObject.SetActive(false);

        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MainCharacter.instance.Knockback(KnockbackDuration, KnockbackPower, this.transform));
        }

        if (other.gameObject.CompareTag("Bullet")) 
        {
            Destroy(other.gameObject);
            Enemies_HP -= 10;

            if (Enemies_HP <= 0)
            {
                MainCharacter.mana += 2;
                Destroy(gameObject);
                Destroy(BossFire.Enemy);
                picture.gameObject.SetActive(false);
                picture2.gameObject.SetActive(false);
                picture3.gameObject.SetActive(false);
                picture4.gameObject.SetActive(false);
              
            }
        }
        if (other.gameObject.CompareTag("ZASHITA"))
        {
            StartCoroutine(ringscript.instance.Knockback2(1f, 0.00001f, this.transform));
        }
    }
}
