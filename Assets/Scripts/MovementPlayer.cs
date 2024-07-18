using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float health;

    [SerializeField] private float maxHealth;

    private Rigidbody2D _rigidbody;

    private HealthBar _healthBar;

    private string Horizontal = nameof(Horizontal);

    private bool looksToRight = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _healthBar = GetComponent<HealthBar>();

        _healthBar.SetHealth(health, maxHealth);
    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis(Horizontal);

        _rigidbody.velocity = new Vector2(moveInput * moveSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);

        if (moveInput > 0 && looksToRight == false) { FlipPlayer(); }
        else if (moveInput < 0 && looksToRight == true) { FlipPlayer(); }

        //Debug.Log(moveInput);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        _healthBar.SetHealth(health, maxHealth);

        if(health == 0) { Destroy(gameObject); }
    }

    private void FlipPlayer()
    {
        looksToRight = !looksToRight;

        transform.Rotate(0f, -180f, 0f);
    }
}