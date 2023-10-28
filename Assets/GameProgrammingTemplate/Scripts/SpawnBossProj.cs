using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossProj : MonoBehaviour
{
    public GameObject SpawnBossProjPrefab;
    Vector2 direction;
    PlayerController player;
    public float coolDown = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.position - player.transform.position;
        if (coolDown <= 0 )
        {
            GameObject newProjectile = Instantiate(SpawnBossProjPrefab);
            newProjectile.GetComponent<BossProjectile>().direction = direction * -1;
            newProjectile.transform.position = transform.position;
            coolDown = 5f;
        }
    }

    private void FixedUpdate()
    {
        coolDown -= Time.deltaTime;
    }
}
