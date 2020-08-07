using UnityEngine;
public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject KOtext;

    private Rigidbody2D rb;
    private Animator anim;
    Vector2 movement;

    void Start()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        KOtext.SetActive(false);
    }

    void Update()
    {
        movement = Vector2.zero;
        Movement();
        IsMoving();
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }  
    void Movement()
{
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
}
void Animation()
{
    anim.SetFloat("Horizontal", movement.x);
    anim.SetFloat("Vertical", movement.y);
    anim.SetFloat("Speed", movement.sqrMagnitude);
    anim.SetBool("moving", true);
}
void IsMoving()
{
    if (movement != Vector2.zero)
    {
        Animation();
    }
    else
    {
        anim.SetBool("moving", false);
    }
}
void TakeDamage(int damage)
{
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
    Die();
}
void Die()
{
    if (currentHealth <= 0)
    {
        CoinCounterScript.coinAmount = 0;
        Time.timeScale = 0f;
        KOtext.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}

private void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("enemy"))
    {
        TakeDamage(25);
        CoinCounterScript.coinAmount -= 1;
        FindObjectOfType<SoundManager>().Play("playerHit");

        if (CoinCounterScript.coinAmount <= 0)
        {
            CoinCounterScript.coinAmount = 0;
        }
    }
}
}