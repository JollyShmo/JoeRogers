using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public Vector2 movement;
    public Animator enAnim;
    public GameObject enemy;
    public Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        enAnim = GetComponent<Animator>();
    }
    void Update()
    {
        Animation();
    }
    private void FixedUpdate()
    {
        Radar();
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    void Animation()
    {
        enAnim.SetFloat("Horizontal", movement.x);
        enAnim.SetFloat("Vertical", movement.y);
        enAnim.SetFloat("Speed", movement.sqrMagnitude);
        enAnim.SetBool("moving", true);
    }
    void Radar()
    {
        float targetDis = Vector2.Distance(transform.position, player.position);

        if (targetDis <= 3f)
        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
        }
        if (targetDis <= 0.5f)
        {
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement -= direction;
        }
    }
}
