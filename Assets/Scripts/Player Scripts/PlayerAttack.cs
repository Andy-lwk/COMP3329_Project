using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject briefcasePrefab;
    public float projectileSpeed = 20f;
    public float briefcaseFireRate = 0.5f;
    private float nextBriefcaseTime = 0f;

    public GameObject seatbeltHitbox;
    public float meleeDuration = 0.2f;
    public float meleeCooldown = 0.8f;
    private float nextMeleeTime = 0f;
    public int currentWeapon{ get; private set; }

    private PlayerStats stats;

    private Animator anim;

    void Start()
    {
        currentWeapon = 1;
        if (seatbeltHitbox != null)
        {
            seatbeltHitbox.SetActive(false);
        }
        stats = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 2;
        }

        if (currentWeapon == 1 && Input.GetMouseButtonDown(0) && Time.time >= nextBriefcaseTime)
        {
            ShootBriefcase();
            nextBriefcaseTime = Time.time + briefcaseFireRate;
        }
        else if (currentWeapon == 2 && Input.GetMouseButtonDown(0) && Time.time >= nextMeleeTime)
        {
            UseSeatbelt();
            nextMeleeTime = Time.time + meleeCooldown;
        }
    }

    void ShootBriefcase()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector2 direction = (mousePos - transform.position).normalized;
        GameObject briefcase = Instantiate(briefcasePrefab, transform.position, Quaternion.identity);
        Projectile proj = briefcase.GetComponent<Projectile>();
        if (proj != null && stats != null)
            proj.damage = Mathf.RoundToInt(stats.TotalDamage);
        Rigidbody2D rig = briefcase.GetComponent<Rigidbody2D>();
        if(rig != null)
        {
            rig.velocity = direction * projectileSpeed;
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        briefcase.transform.rotation = Quaternion.Euler(0, 0, angle);
        if (anim != null)
            anim.SetTrigger("Throw");
    }

    void UseSeatbelt()
    {
        if (seatbeltHitbox != null)
        {
            MeleeHitbox melee = seatbeltHitbox.GetComponent<MeleeHitbox>();
            if (melee != null && stats != null)
                melee.damage = Mathf.RoundToInt(stats.TotalDamage);
            seatbeltHitbox.SetActive(true);
            Invoke(nameof(DisableHitbox), meleeDuration);
            if (anim != null)
                anim.SetTrigger("Throw");
        }
    }

    void DisableHitbox()
    {
        if (seatbeltHitbox != null)
        {
            seatbeltHitbox.SetActive(false);
        }
    }
}
