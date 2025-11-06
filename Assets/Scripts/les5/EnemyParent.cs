using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int health = 3;

    private int direction = 1; 
    private float minX = -10f;
    private float maxX = 10f;

    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        if (transform.position.x > maxX)
            direction = -1;
        else if (transform.position.x < minX)
            direction = 1;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
