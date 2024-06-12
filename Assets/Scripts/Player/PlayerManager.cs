using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public HealthBar healthBar;
    public float damageCooldown = 1f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {

        }
        Destroy(gameObject);

    }

    private void Update()
    {
        if (damageCooldown > 0)
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && damageCooldown <= 0)
        {
            EnemyManager em = collision.gameObject.GetComponent<EnemyManager>();
            if (em != null)
            {
                em.TakeDamage(damage);
            }
            damageCooldown = 1f;
        }
    }
}
