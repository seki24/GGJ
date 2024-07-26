using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public int maxHealth = 4;
    private int currentHealth;
    public PlayerHealth playerHealth;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;

    public float fireRate;
    private float timeToFire;

    public Transform firingPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Musuh menerima " + damage + " damage. Kesehatan Saat Ini: " + currentHealth);

        if (currentHealth <= 0)
        {
            LevelManager.manager.IncreaseScore(1); // Tingkatkan skor saat musuh berhasil dihancurkan
            Destroy(gameObject);
            target = null;
        }
        else if (currentHealth <= maxHealth - 4) // Periksa apakah musuh sudah terkena 4 kali
        {
            LevelManager.manager.GameOver();
        }
    }


    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
        if (target != null && Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (timeToFire <= 0f)
        {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                rb.velocity = transform.up * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);

                if (playerHealth.GetCurrentHealth() <= 0)
                {
                    LevelManager.manager.GameOver();
                }
            }

            Destroy(gameObject);
            target = null;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            LevelManager.manager.IncreaseScore(3);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
