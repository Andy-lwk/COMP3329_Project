using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public GameObject paperPrefab;
    public float moveSpeed = 2f;
    public float attackRange = 10f;
    public float shootCooldown = 1.2f;
    public int burstCount = 3;
    public float burstDelay = 0.2f;
    private float nextShootTime = 0f;
    private bool isAlerted = true;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (Time.time >= nextShootTime)
        {
            StartCoroutine(ShootBurst());
            nextShootTime = Time.time + shootCooldown;
        }
    }

    System.Collections.IEnumerator ShootBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            ShootPaper();
            yield return new WaitForSeconds(burstDelay);
        }
    }

    void ShootPaper()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        GameObject paper = Instantiate(paperPrefab, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        paper.transform.rotation = Quaternion.Euler(0, 0, angle);
        Rigidbody2D rbPaper = paper.GetComponent<Rigidbody2D>();
        if (rbPaper != null) rbPaper.velocity = direction * 8f;
    }
}
