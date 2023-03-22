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

    public Rigidbody2D body;

    public float horizontal;
    public float vertical;
    private float fireTimer;
    public string SprintInput = "Sprint";
    float moveLimiter = 0.7f;

    public float runSpeed = 12.0f;
    public float normalSpeed = 12.0f;
    public float fastSpeed = 35.0f;
    public float slowSpeed = 7.0f;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
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
        Debug.Log(runSpeed);

    }

    void FixedUpdate()
    {


        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);


    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}