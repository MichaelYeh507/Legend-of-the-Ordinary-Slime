using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    float healthRatioScale;
    Vector3 initialScale;
    PlayerController player;
    void Start()
    {
        initialScale = transform.localScale;

        healthRatioScale = 1;
        player = transform.GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // what heaklth

        healthRatioScale = player.health / player.totalHealth;

        Vector3 newScale = initialScale;
        newScale.x *= healthRatioScale;


        transform.localScale = newScale;
        //Slider.transform.position = Camera.main.WorldToScreenPoint((Vector2)transform.parent.position + offset);
    }
}
