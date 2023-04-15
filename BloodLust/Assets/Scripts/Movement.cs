using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioSource PistolShoot;
    [SerializeField] private AudioSource ShootGunShoot;
    [SerializeField] private AudioSource Moving;

    private Animator anim;
    private Animator anim2;
    //[SerializeField] private Transform firePoint;
    [Range(0.1f, 2f)]
    [SerializeField]
    private float fireRate = 0.5f;
    private float fireRate2 = 0.8f;
    public static bool CanMove;
    public static bool CanShoot;

    public Rigidbody2D body;

    public float horizontal;
    public float vertical;
    public static float fireTimer;
    public static float fireTimer2;
    public string SprintInput = "Sprint";
    float moveLimiter = 0.7f;

    public float runSpeed = 12.0f;
    public float normalSpeed = 12.0f;
    public float fastSpeed = 35.0f;
    public float slowSpeed = 7.0f;
    public static int HandGunreload = 0;
    public static int Pistolreload = 0;
    public float numShots = 3f;            // Number of shots fired (should be odd); 
    public float spreadAngle = 20.0f;       // Angle between shots
    public float timeBetweenShots = 0.5f;
    public Transform ring;
    private float nextShot = 0.0f;
    public Quaternion qDelta;
    [SerializeField] Text Bullets1Info;
    [SerializeField] Text Bullets2Info;
    [SerializeField] GameObject InventoryKnife;
    [SerializeField] private AudioSource Habar;

    void Start()
    {

        CanMove = true;
        CanShoot = true;
    }

    void Update()
    {
   
        if (ring != null)
        {
            ring.transform.position = transform.position;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

       

        if (Input.GetMouseButtonDown(0) && CanShoot && fireTimer <= 0f && WeaphonScript.currentWeaphonIndex == 2 && Pistol.number_of_bullets != 0)
        {
            PistolShoot.Play();
            anim2 = WeaphonScript.currentGun.transform.GetComponent<Animator>();
            PlayAnim2();
            Shoot1();
            Pistol.number_of_bullets--;
            Pistolreload++;
            fireTimer = fireRate;

        }
        else if (WeaphonScript.currentWeaphonIndex == 2 && Pistol.number_of_bullets != 0)
        {
            fireTimer -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && CanShoot && fireTimer2 <= 0f && WeaphonScript.currentWeaphonIndex == 3 && HandGun.number_of_bullets != 0)
        {
            ShootGunShoot.Play();
            anim = WeaphonScript.currentGun.transform.GetComponent<Animator>();
            Shoot2();
            PlayAnim();
            HandGun.number_of_bullets--;
            HandGunreload++;
            fireTimer2 = fireRate2;


        }
        else if (WeaphonScript.currentWeaphonIndex == 3 && HandGun.number_of_bullets != 0)
        {
            fireTimer2 -= Time.deltaTime;
        }
/*if (Input.GetMouseButtonDown(0) && CanShoot && fireTimer <= 0f && WeaphonScript.currentWeaphonIndex == 1 && Pistol.number_of_bullets != 0)
        {
            PistolShoot.Play();
            anim2 = WeaphonScript.currentGun.transform.GetComponent<Animator>();
            PlayAnim2();
            Shoot1();
            Pistol.number_of_bullets--;
            Pistolreload++;
            fireTimer = fireRate;

        }
        else if (WeaphonScript.currentWeaphonIndex == 2 && Pistol.number_of_bullets != 0)
        {
            fireTimer -= Time.deltaTime;
        }*/
        if (Input.GetButton("Sprint"))
        {
            runSpeed = fastSpeed;
        }
        else
        {
            runSpeed = normalSpeed;
        }
    }

    void FixedUpdate()
    {

        if (CanMove)
        {
            
            if (horizontal != 0 || vertical != 0)
            {
               
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
            else
            { Moving.Play();
            }
           
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }



    }
    public void PlayAnim()
    {
        anim.SetTrigger("Play");
    }
    public void PlayAnim2()
    {
        anim2.SetTrigger("Play");
    }
    private void Shoot2()
    {
        var qAngle = Quaternion.AngleAxis(-numShots / 2.0f * 15, WeaphonScript.currentGun.transform.Find("firepoint").transform.up) * WeaphonScript.currentGun.transform.Find("firepoint").rotation;
        if (mouse.c == true)
        {
            qDelta = new Quaternion(-0.08f, 0.0f, 0.0f, 1.0f);
        }
        else
            qDelta = new Quaternion(0.08f, 0.0f, 0.0f, 1.0f);
        for (var i = 0; i < numShots; i++)
        {
            Instantiate(bulletPrefab, WeaphonScript.currentGun.transform.Find("firepoint").position, qAngle);
            qAngle *= qDelta;
            Debug.Log(qDelta);
        }

    }
    private void Shoot1()
    {


        Instantiate(bulletPrefab, WeaphonScript.currentGun.transform.Find("firepoint").position, WeaphonScript.currentGun.transform.Find("firepoint").rotation);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Habar"))
        {
            Habar.Play();
            Destroy(other.gameObject);
            Pistol.number_of_bullets += 16;
            Bullets1Info.text = "x" + Pistol.number_of_bullets.ToString();

        }
        if (other.gameObject.CompareTag("Habar2"))
        {
            Habar.Play();
            Destroy(other.gameObject);
            HandGun.number_of_bullets += 8;
            Bullets2Info.text = "x" + HandGun.number_of_bullets.ToString();

        }
        if (other.gameObject.CompareTag("Knife"))
        {
            Habar.Play();
            Destroy(other.gameObject);
            WeaphonScript.totalWeaphons = 2;
            InventoryKnife.SetActive(true);
            //WeaphonScript.currentWeaphonIndex = 2;

        }
    }
}