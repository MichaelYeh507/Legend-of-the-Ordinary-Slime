using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCoolDown = 5f;
    private float dashCounter;
    private float dashCoolCounter;
    public float coolDown = 0f;
    public float health;
    public float totalHealth = 3f;



    Rigidbody2D rb;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed;
        health = 3f;
    }

    // Update is called once per frame


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        direction.x = horizontalInput;
        direction.y = verticalInput;
        rb.velocity = direction * activeMoveSpeed;

        //Dash
        if (Input.GetKeyDown(KeyCode.Space) && coolDown == 0f)
        {
            coolDown = 1f;
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCounter;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            if (dashCoolCounter <= 0)
            {
                dashCoolCounter = 0;
            }
        }
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            if(coolDown <= 0)
            {
                coolDown = 0;
            }
        }

        if (health == 0)
        {
            Debug.Log("gameover");
            SceneManager.LoadScene("Game Over");
        }

    }
    void FixedUpdate()
    {

        //Player Movement with WASD
        //Vector2 newPos = rb.position + direction * Time.deltaTime * speed;
        //rb.MovePosition(newPos);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }



}
