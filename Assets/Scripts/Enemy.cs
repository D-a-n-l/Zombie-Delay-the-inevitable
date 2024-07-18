using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    [SerializeField] private float speedMovement;

    private float recharger;

    [SerializeField] private float startRecharger;

    [SerializeField] private int damage;

    [SerializeField] private int health;

    [SerializeField] private float maxHealth;

    private Transform player;


    private Transform leftFence;

    private Transform rightFence;

    private Animator _animator;

    private void Start()
    {
        recharger = startRecharger;

        _animator = GetComponent<Animator>();

        _healthBar.SetHealth(health, maxHealth);

        if(leftFence != null)
            leftFence = FindObjectOfType<LeftFence>().transform;
        else if(rightFence != null)
            rightFence = FindObjectOfType<RightFence>().transform;

        player = FindObjectOfType<MovementPlayer>().transform;

        FlipEnemy();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speedMovement * Time.deltaTime);
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent(out MovementPlayer player))
        {
            if (recharger <= 0)
            {
                _animator.SetTrigger("Attack");

                player.TakeDamage(10f);

                recharger = startRecharger;
            }
            else
            {
                recharger -= Time.deltaTime;
            }
        }
        if (col.TryGetComponent(out LeftFence leftFence))
        {
            if(recharger <= 0)
            {
                _animator.SetTrigger("Attack");

                leftFence.TakeDamage(10f);

                recharger = startRecharger;
            }
            else
            {
                recharger -= Time.deltaTime;
            }
        }
        else if (col.TryGetComponent(out RightFence rightFence))
        {
            if (recharger <= 0)
            {
                _animator.SetTrigger("Attack");

                rightFence.TakeDamage(10f);

                recharger = startRecharger;
            }
            else
            {
                recharger -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BulletPlayer>())
        {
            health -= damage;

            _healthBar.SetHealth(health, maxHealth);

            Destroy(col.gameObject);

            if(health == 0) { Destroy(gameObject); }
        }
    }

    private void FlipEnemy()
    {
        if (player.transform.position.x > transform.position.x)
            transform.Rotate(0f, 0f, 0f);
        else
            transform.Rotate(0f, 180f, 0f);
    }
}