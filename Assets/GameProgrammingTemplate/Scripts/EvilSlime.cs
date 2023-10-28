using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSlime : MonoBehaviour
{
    Rigidbody2D rb;
    public float health;
    public float maxHealth = 5f;
    public HealthBehavior healthbar;
    public Vector2 direction = Vector2.right;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 newPos = rb.position + direction * speed * Time.deltaTime;
        rb.MovePosition(newPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            health -= 1f;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

            direction *= -1;

    }

}
