using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceA : MonoBehaviour
{
    [SerializeField] private float health;

    [SerializeField] private float damage;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}