using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destructable : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 5;
    public float totalHealth = 5;
    public bool bossDefeated = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && bossDefeated == false)
        {
            Destroy(gameObject);
        } else if (health <= 0 && bossDefeated)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            health -= 1;
        }
    }
}
