using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter instance;
    public int HP = 30;
    [SerializeField] Text HPInfo;
    public static string ActiveItem="Default";
    [SerializeField] Text ActiveItemInfo;
    public GameObject Maincharacter;
    public Rigidbody2D rb;
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
            HP += 20;

        }

        if (other.gameObject.CompareTag("Enemies"))
        {
           
           

            HP -= 10;

            if (HP <= 0)
            {
                Destroy(gameObject);
            }


        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            //Maincharacter.GetComponent<Transform>().position = Maincharacter.GetComponent<Transform>().position + new Vector3(2, 0, 0);
            HP -= 10;

            if (HP <= 0)
            {
                Destroy(gameObject);
            }


        }
    }
    public IEnumerator Knockback(float KnockbackDuration, float KnockbackPower, Transform obj)
    {
        float timer = 0;
        while (KnockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * KnockbackPower);
        }
        yield return 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        HPInfo.text = HP.ToString();
        ActiveItemInfo.text=($"Активный предмет: {ActiveItem}").ToString();
    }
}
