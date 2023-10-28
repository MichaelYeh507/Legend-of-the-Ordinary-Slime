using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody2D rb;
    public float slashTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (slashTime > 0)
        {
            slashTime -= Time.deltaTime;
        }
        if (slashTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
