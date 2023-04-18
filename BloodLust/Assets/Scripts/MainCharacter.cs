using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainCharacter : MonoBehaviour
{
    public static MainCharacter instance;
    public GameObject bulletprefab;
    public GameObject ring;
    [SerializeField] float MaxHP = 100;
    float HP = 30;
    [SerializeField] Image HPBar;
    [SerializeField] Text HPInfo;
    public static string ActiveItem="Default";
    [SerializeField] Text ActiveItemInfo;
    public GameObject Maincharacter;
    public Rigidbody2D rb;
    Collider2D IO, PC;
    public static float mana = 4;
    [SerializeField] Image ManaBar;
    [SerializeField] Text ManaInfo;
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject Cross;
    [SerializeField] private AudioSource Damage;
    [SerializeField] private AudioSource Hills;
    [SerializeField] private AudioSource MAXHills;
    [SerializeField] private GameObject Killed;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Killed.SetActive(false);
        HP = MaxHP;
        Arrow.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        IO = bulletprefab.GetComponent<Collider2D>();
        PC = ring.GetComponent<Collider2D>();
        StartCoroutine(Recovery());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            Hills.Play();
            Destroy(other.gameObject);
            HP += MaxHP - HP>=20? 20: MaxHP - HP;

        }

        if (other.gameObject.CompareTag("Pumping"))
        {
            MAXHills.Play();
            Destroy(other.gameObject);
            MaxHP += 50;

        }

        if (other.gameObject.CompareTag("Enemies"))
        {
            //Destroy(other.gameObject);
            HP -= 10;
            Damage.Play();
            if (HP <= 0)
            {
                HPInfo.text = ($"{HP}/{MaxHP}");
                HPBar.fillAmount = HP / MaxHP;
                Destroy(gameObject);
                Killed.SetActive(true);
            }


        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            //Maincharacter.GetComponent<Transform>().position = Maincharacter.GetComponent<Transform>().position + new Vector3(2, 0, 0);
            HP -= 10;
            
            if (HP <= 0)
            {
                HPInfo.text = ($"{HP}/{MaxHP}");
                HPBar.fillAmount = HP / MaxHP;
                Destroy(gameObject);
                Killed.SetActive(true);
            }


        }
        if (other.gameObject.CompareTag("PYLIAVRAGA"))
        {
            Damage.Play();
            Destroy(other.gameObject);
            //Maincharacter.GetComponent<Transform>().position = Maincharacter.GetComponent<Transform>().position + new Vector3(2, 0, 0);
            HP -= 10;

            if (HP <= 0)
            {
                HPInfo.text = ($"{HP}/{MaxHP}");
                HPBar.fillAmount = HP / MaxHP;
                Destroy(gameObject);
                Killed.SetActive(true);
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

    IEnumerator Recovery()
    {
        HP += (Cross.activeSelf && MaxHP > HP) ? 1 : 0;
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(Recovery());
    }
    // Update is called once per frame
    void Update()
    {
        if(Maincharacter!=null)
        {
            HPInfo.text = ($"{HP}/{MaxHP}");
            HPBar.fillAmount = HP / MaxHP;

            ManaInfo.text = ($"{Math.Round(mana, 1)}/4");
            ManaBar.fillAmount = mana / 4;
            if(mana>4) Arrow.SetActive(true);
            else Arrow.SetActive(false);
        }
    }

    public string RandReward()
    {
        int PistolCartridges = 0;
        int ShoutGunCartridges = 0;
        int rand = UnityEngine.Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                HP = MaxHP;
                return "Здоровье восстановлено.";
            case 1:
                MaxHP += 15;
                return ("Увеличен максимальный запас здоровья");
            case 2:
                PistolCartridges = UnityEngine.Random.Range(5, 15);
                Pistol.number_of_bullets += PistolCartridges;
                return ($"Найдены патроны для пистолета: {PistolCartridges}");
            case 3:
                ShoutGunCartridges = UnityEngine.Random.Range(2, 8);
                HandGun.number_of_bullets += ShoutGunCartridges;
                return ($"Найдены патроны для дробовика: {PistolCartridges}");
        }
        return "error";
       
    }
}
