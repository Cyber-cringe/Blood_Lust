using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    [SerializeField] float MaxEnemies_HP = 30f;
    public static float Enemies_HP = 30f;
    [SerializeField] Image HPBar;
    [SerializeField] Text HPInfo;
    public float KnockbackPower = 1000;
    public float KnockbackDuration = 1;
    public static float mana = 4;
    public float timer = 3f;
    [SerializeField] private AudioSource DEad;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Enemies_HP = MaxEnemies_HP;
        HPInfo.text = ($"{Enemies_HP}/{MaxEnemies_HP}");
        HPBar.fillAmount = Enemies_HP / MaxEnemies_HP;
    }
    public void Update()
    {
        HPInfo.text = ($"{Enemies_HP}/{MaxEnemies_HP}");
        HPBar.fillAmount = Enemies_HP / MaxEnemies_HP;
        if (Enemies_HP <= 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            deadFunc();
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
                mana += 2;
                DEad.Play();
               

            }
        }
        if (other.gameObject.CompareTag("ZASHITA"))
        {
            StartCoroutine(ringscript.instance.Knockback2(1f, 0.00001f, this.transform));
        }
    }
    public void deadFunc()
    {
        Destroy(gameObject);
    }
}
