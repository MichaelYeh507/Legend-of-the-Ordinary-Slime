using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlash : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject meleePrefab;
    public float offset = 5f;
    Vector2 direction;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = cursorPos - (Vector2)transform.position;
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.GetComponent<Projectile>().direction = direction;
            newProjectile.transform.position = transform.position;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newMelee = Instantiate(meleePrefab);
            newMelee.GetComponent<MeleeAttack>().direction = direction.normalized;
            newMelee.transform.parent = transform;
            newMelee.transform.position = (Vector2)transform.position + direction.normalized * offset;
            

        }
    }
}
