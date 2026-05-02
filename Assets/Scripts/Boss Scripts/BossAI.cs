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
    public float sleepDuration = 1f;
    public float spreadAngle = 45f;
    private bool isAlerted = true;
    private bool isSleeping = true;
    private float sleepTimer;
    public AudioClip shootSound;
    private AudioSource audioSource;
    private Transform player;
    private Rigidbody2D rb;
    private bool useSpreadPattern = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sleepTimer = sleepDuration;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player == null) return;

        // ----- Sleep phase -----
        if (isSleeping)
        {
            sleepTimer -= Time.deltaTime;
            if (sleepTimer <= 0f)
            {
                isSleeping = false;
                // wake-up effect or sound
            }
            else
            {
                rb.velocity = Vector2.zero;
                return;
            }
        }

        // ----- Normal behavior -----
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        if (direction.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Time.time >= nextShootTime)
        {
            if (useSpreadPattern)
                ShootSpread();
            else
                StartCoroutine(ShootBurst());

            // Switch pattern for next attack
            useSpreadPattern = !useSpreadPattern;

            nextShootTime = Time.time + shootCooldown;
        }
    }

    IEnumerator ShootBurst()
    {
        for (int i = 0; i < burstCount; i++)
        {
            ShootStraight();
            yield return new WaitForSeconds(burstDelay);
        }
    }

    void ShootSpread()
    {
        Vector2 baseDirection = (player.position - transform.position).normalized;

        SpawnPaper(baseDirection);

        Vector2 angled1 = RotateVector(baseDirection, spreadAngle);
        SpawnPaper(angled1);

        Vector2 angled2 = RotateVector(baseDirection, -spreadAngle);
        SpawnPaper(angled2);
    }

    void SpawnPaper(Vector2 direction)
    {
        if (shootSound != null && audioSource != null)
            audioSource.PlayOneShot(shootSound);
        GameObject paper = Instantiate(paperPrefab, transform.position, Quaternion.identity);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        paper.transform.rotation = Quaternion.Euler(0, 0, angle);
        Rigidbody2D rbPaper = paper.GetComponent<Rigidbody2D>();
        if (rbPaper != null)
            rbPaper.velocity = direction * 8f;
    }

    void ShootStraight()
    {
        if (shootSound != null && audioSource != null)
            audioSource.PlayOneShot(shootSound);
        Vector2 direction = (player.position - transform.position).normalized;
        SpawnPaper(direction);
    }

    Vector2 RotateVector(Vector2 v, float angleDeg)
    {
        float rad = angleDeg * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        return new Vector2(v.x * cos - v.y * sin, v.x * sin + v.y * cos);
    }

    public bool IsSleeping()
    {
        return isSleeping;
    }
}
