using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;
    public static bool CanMove;
    public static bool CanShoot;

    public Rigidbody2D body;

    public float horizontal;
    public float vertical;
    public static float fireTimer;
    public string SprintInput = "Sprint";
    float moveLimiter = 0.7f;

    public float runSpeed = 12.0f;
    public float normalSpeed = 12.0f;
    public float fastSpeed = 35.0f;
    public float slowSpeed = 7.0f;
    public static int reload = 0;

    void Start()
    {
        CanMove= true;
        CanShoot= true;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0) && CanShoot && fireTimer <= 0f && (Pistol.number_of_bullets > 0) )
        {
            Shoot();
            fireTimer = fireRate;
            reload++;
            Pistol.number_of_bullets--;
            //Debug.Log(reload);
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
        if (Input.GetButton("Sprint"))
        {
            runSpeed = fastSpeed;
        }
        else
        {
            runSpeed = normalSpeed;
        }
        //Debug.Log(runSpeed);

    }

    void FixedUpdate()
    {

        if (CanMove)
        {
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
        


    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Habar"))
        {
            Destroy(other.gameObject);
            Pistol.number_of_bullets += 16;

        }

    }
}