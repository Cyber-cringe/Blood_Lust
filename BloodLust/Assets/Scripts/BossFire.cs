using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BossFire : MonoBehaviour
{
    [SerializeField]
    int numberofProjectiles;
    [SerializeField]
    GameObject Boss;
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] public GameObject enemyPrefabs;
    [SerializeField] public GameObject enemyPrefabs2;
    [SerializeField] public GameObject enemyPrefabs3;
    [SerializeField] public GameObject MainCharacter;

    [SerializeField] private bool canSpawn = true;

    [SerializeField] GameObject projectiles;
    Vector2 startPoint;
    public float fireTimer;
    public float fireTimer2;
    public float fireTimer3;
    public float fireRate = 2000000000f;
    public float fireRate2 = 20000f;
    public float fireRate3 = 15f;
    public float angle = 0f;
    // public Transform EnemySpawnerPosition;
    public Transform EnemySpawnerPosition2;
    public Transform EnemySpawnerPosition3;
    public Transform EnemySpawnerPosition4;

    public GameObject ring;
    public bool k = false;
    public static GameObject Enemy;
    public static GameObject Enemy2;
    public static GameObject Enemy3;
    [SerializeField] private AudioSource BossSound;



    float radius, moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        radius = 5f;
        moveSpeed = 8f;
        fireTimer = fireRate;
        fireTimer2 = fireRate2;
        ring.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log((Vector2.Distance(Boss.GetComponent<Transform>().position, MainCharacter.GetComponent<Transform>().position)));



        if ((Boss != null && MainCharacter != null) && (Vector2.Distance(Boss.GetComponent<Transform>().position, MainCharacter.GetComponent<Transform>().position) <= 30))
        {


            if (k == true && Enemy == null && Enemy2 == null && Enemy3 == null)
            {
                ring.gameObject.SetActive(false);
                k = false; fireTimer2 -= Time.deltaTime;
            }
            if (Enemy != null || Enemy2 != null || Enemy3 != null)
            {
                fireTimer2 = fireRate2;
            }
            if (Boss != null)
            {


                fireTimer2 -= Time.deltaTime;
                fireTimer -= Time.deltaTime;
                startPoint = Boss.transform.position;
                if (fireTimer <= 0f && fireTimer2 >= 0f && k == false)
                {
                    fireTimer = fireRate;
                    SpawnProjectiles(numberofProjectiles);
                }
                if (fireTimer2 <= 0f)
                {
                    fireTimer2 = fireRate2;
                    ring.gameObject.SetActive(true);
                    k = true;
                    SpawnEnemies();
                }
            }
        }
        else
        {
             BossSound.Play();
        }
    }
    void SpawnProjectiles(int numberofProjectiles)
    {

        float angleStep = 360f / numberofProjectiles;
        angle = Random.Range(10f, 360f);
        for (int i = 0; i <= numberofProjectiles - 1; i++)
        {
            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

            var proj = Instantiate(projectiles, startPoint, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;

        }
    }
    void SpawnEnemies()
    {
        //  Instantiate(enemyPrefabs, EnemySpawnerPosition.position, Quaternion.identity);
        Enemy = Instantiate(enemyPrefabs, EnemySpawnerPosition2.position, Quaternion.identity);
        Enemy2 = Instantiate(enemyPrefabs2, EnemySpawnerPosition3.position, Quaternion.identity);
        Enemy3 = Instantiate(enemyPrefabs3, EnemySpawnerPosition4.position, Quaternion.identity);


    }
}
