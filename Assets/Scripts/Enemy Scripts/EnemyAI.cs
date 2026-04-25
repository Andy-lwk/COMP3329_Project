using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected GameObject paperPrefab;
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 8f;
    public float shootCooldown = 1.5f;
    protected float nextShootTime = 0f;
    private bool isAlerted = false;

    protected Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        if (!isAlerted)
        {
            float dist = Vector2.Distance(transform.position, player.position);
            if (dist <= detectionRange)
            {
                Alert();
            }
            else
            {
                rb.velocity = Vector2.zero;
                return;
            }
        }
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (distanceToPlayer <= attackRange && Time.time >= nextShootTime)
        {
            ShootPaper();
            nextShootTime = Time.time + shootCooldown;
        }
    }

    protected virtual void ShootPaper()
    {
        Vector2 direction = (player.position - transform.position).normalized;
    
        GameObject paper = Instantiate(paperPrefab, transform.position, Quaternion.identity);
    
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        paper.transform.rotation = Quaternion.Euler(0, 0, angle);
    
        Rigidbody2D rbPaper = paper.GetComponent<Rigidbody2D>();
        if (rbPaper != null)
        {
            rbPaper.velocity = direction * 8f;
        }
    }

    public void Alert()
    {
        Debug.Log("Enemy alerted!");
        isAlerted = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}
