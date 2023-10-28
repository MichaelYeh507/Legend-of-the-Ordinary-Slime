using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Vector2 direction;
    PlayerController player;
    Rigidbody2D rb;
    public float followSpeed = -3f;
    float aggressiveRange;
    public float detectionRange = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        aggressiveRange = Vector2.Distance(transform.position, player.transform.position);
        direction = transform.position - player.transform.position;
        direction = direction.normalized;

        
        

    }

    private void FixedUpdate()
    {
        Vector2 newPos = rb.position + direction * followSpeed * Time.deltaTime;

        if (aggressiveRange < detectionRange)
        {
            rb.MovePosition(newPos);
        }
    }
}
