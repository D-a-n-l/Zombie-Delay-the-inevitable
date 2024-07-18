using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFence : MonoBehaviour
{
    [SerializeField] private float health;

    [SerializeField] private float maxHealth;

    [SerializeField] private float startRecharger;

    private float recharger;

    private HealthBar _healthBar;

    private void Start()
    {
        health = Mathf.Clamp(health, 0, 100);

        _healthBar = GetComponent<HealthBar>();

        _healthBar.SetHealth(health, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        _healthBar.SetHealth(health, maxHealth);

        if (health <= 0) { Destroy(gameObject); }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent(out MovementPlayer player))
        {
            if (recharger <= 0)
            {
                health += 2;

                _healthBar.SetHealth(health, maxHealth);

                recharger = startRecharger;
            }
            else
            {
                recharger -= Time.deltaTime;
            }
        }
    }
}