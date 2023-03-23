using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public int Enemies_HP = 30;

  
    private void OnCollisionEnter2D(Collision2D other)
    {
     
         if (other.gameObject.CompareTag("Bullet")) 
        {
            Destroy(other.gameObject);
            Enemies_HP -= 10;
            if (Enemies_HP == 0)
            {
                
                Destroy(gameObject);
            }
        }
    }
}
