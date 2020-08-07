using UnityEngine;

public class Knockback : MonoBehaviour
{
    public Vector2 movement;
    public Transform enemy;

    private void Start()
    {
        this.GetComponent<Rigidbody2D>();
    }
    // May need to change trigger and collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Push();
        }
    }
  void Push()
    {
        float targetDis = Vector2.Distance(transform.position, enemy.position);

        if (targetDis <= 0.6f)
        {
            Vector2 direction = enemy.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement -= direction;
        }
    }
}
