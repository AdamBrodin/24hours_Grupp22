using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Health : MonoBehaviour
{
    public GameObject bloodparticle;

    public float maxHealth = 20f;
    public float cameraShakeMagnitude = 0f;
    public int cameraShakes = 0;

    private float health;
    private CamerShake cameraShake;

    private void Start()
    {
        health = maxHealth;
        Camera cam = Camera.main;
        cameraShake = cam.GetComponent<CamerShake>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            cameraShake.DoCameraShake(cameraShakeMagnitude, cameraShakes);
            health = 0;
            Die();
        }
    }

    public void FullHeal()
    {
        health = maxHealth;
    }

    private void Die()
    {
        // spawn particles
        if (cameraShakes > 0 && cameraShake != null)
        {
            cameraShake.DoCameraShake(cameraShakeMagnitude, cameraShakes);
        }

        Instantiate(bloodparticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
