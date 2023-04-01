using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringscript : MonoBehaviour
{
    public static ringscript instance;
    public Rigidbody2D rb;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
