using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private SpriteRenderer sprite2;
    [SerializeField] private Behaviour _entity;
    [SerializeField] private Behaviour _entity1;
    [SerializeField] private Behaviour _entity2;
    [SerializeField] private GameObject Vrag;
    public Transform picture;
    public Transform picture2;
    public Transform picture3;
    public Transform picture4;
    public Transform picture5;
    public Transform picture6;
    public Transform Rotation;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public int Enemies_HP = 30;
    public float KnockbackPower = 1000;
    public float KnockbackDuration = 1;
    public bool c = false;
    public float a;
    public void Start()
    {
        Color color = sprite.material.color;
        Color color2 = sprite2.material.color;
        color.a = 0f;
        color2.a = 0f;
        sprite.material.color = color;
        sprite2.material.color = color2;
        rb = GetComponent<Rigidbody2D>();
        picture2.gameObject.SetActive(false);
        picture.gameObject.SetActive(false);
        picture3.gameObject.SetActive(false);
        picture4.gameObject.SetActive(false);
        picture5.gameObject.SetActive(false);
        picture6.gameObject.SetActive(false);
    }
   IEnumerator InvisibleSprite()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.005f)
        {
            Color color = sprite.material.color;
            Color color2 = sprite2.material.color;
            color.a = f;
            color2.a = f;
            sprite.material.color = color;
            sprite2.material.color = color2;
            yield return new WaitForSeconds(0.05f);
            Destroy(Vrag,10);

        }
    }
    public void Update()
    {
        picture.position = transform.position;
        picture2.position = transform.position;
        picture3.position = transform.position;
        picture4.position = transform.position;
        picture5.position = transform.position;
        picture6.position = transform.position;
        a = Rotation.eulerAngles.z;

        if (((a > 0 && a < 45) || (a > 315 && a < 360)) && Enemies_HP > 0)
        {
            picture2.gameObject.SetActive(true);
        }
        else 
        {
            picture2.gameObject.SetActive(false);

        }

        if (Enemies_HP > 0 && a > 135 && a < 225)
        {
            picture3.gameObject.SetActive(true);
        }
        else
        {
            picture3.gameObject.SetActive(false);

        }

        if (Enemies_HP > 0 && a > 45 && a < 135)
        {
            picture4.gameObject.SetActive(true);

        }
        else
        {
            picture4.gameObject.SetActive(false);

        }
        if (Enemies_HP > 0 && a > 225 && a < 315 )
        {
            picture.gameObject.SetActive(true);
             
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
                _entity.enabled = false;
                _entity1.enabled = false;
                _entity2.enabled = false;
                transform.GetComponent<Collider2D>().enabled = false;
                Vrag.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                MainCharacter.mana += 2;
               // Destroy(BossFire.Enemy);
                if (a > 0 && a < 180)
                {

                    picture6.gameObject.SetActive(true);
                    Destroy(picture5);
                }
                else
                    if (a > 180 && a < 360)
                {

                    picture5.gameObject.SetActive(true);
                    Destroy(picture6);
                }
                StartCoroutine("InvisibleSprite");

                //Destroy(gameObject);



            }
        }
        if (other.gameObject.CompareTag("Knife"))
        {
            Enemies_HP -= 10;
            if (Enemies_HP <= 0)
            {
                _entity.enabled = false;
                _entity1.enabled = false;
                _entity2.enabled = false;
                transform.GetComponent<Collider2D>().enabled = false;
                Vrag.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                MainCharacter.mana += 2;
                // Destroy(BossFire.Enemy);
                if (a > 0 && a < 180)
                {

                    picture6.gameObject.SetActive(true);
                    Destroy(picture5);
                }
                else
                    if (a > 180 && a < 360)
                {

                    picture5.gameObject.SetActive(true);
                    Destroy(picture6);
                }
                StartCoroutine("InvisibleSprite");
            }
        }

       if (other.gameObject.CompareTag("ZASHITA"))
        {
            StartCoroutine(ringscript.instance.Knockback2(1f, 0.00001f, this.transform));
        }
    }
}
