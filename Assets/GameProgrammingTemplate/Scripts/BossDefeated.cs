using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDefeated : MonoBehaviour
{

    Destructable boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = gameObject.GetComponent<Destructable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.health == 1)
        {
            boss.bossDefeated = true;
        }
    }
}
