using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringscript : MonoBehaviour
{
    public static ringscript instance;
    public Rigidbody2D rb;
    public GameObject ring;
    [SerializeField] private float lifeTime;
    public GameObject krest;
    private float curr_time;
    public bool aktivatime;
    [SerializeField] private AudioSource RingMysic;
    public bool d = false;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        krest.gameObject.SetActive(false);
        ring.gameObject.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        
        //rb.isKinematic = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PYLIAVRAGA"))
        {

            {
                Destroy(other.gameObject);
            }
        }
    }
        public IEnumerator Knockback2(float KnockbackDuration, float KnockbackPower, Transform obj)
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
    void Update()
    {
        if (krest != null && ring != null)
        {

       
           
            if (MainCharacter.mana > 0 && (Input.GetMouseButton(1)))
            {
                

                MainCharacter.mana -= Time.deltaTime;
                if (MainCharacter.mana <= 0)
                {
                    //RingMysic.Play();
                    krest.gameObject.SetActive(false);
                    ring.gameObject.SetActive(false);

                }
                else
                {
                   
                    krest.gameObject.SetActive(true);
                    ring.gameObject.SetActive(true);
                   
                }

            }
            else
            {
                krest.gameObject.SetActive(false);
                ring.gameObject.SetActive(false);
                RingMysic.Play();
                
            }
          
            
        }
       

          
    }
}
