using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour
{
    /*
    public Slider Slider;
    public Color low;
    public Color high;
    public Vector2 offset;


    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);

    }
    */
    // Start is called before the first frame update

    float healthRatioScale;
    Vector3 initialScale;
    Destructable enemy;
    void Start()
    {
        initialScale = transform.localScale;

        healthRatioScale = 1;
        enemy = transform.GetComponentInParent<Destructable>();
    }

    // Update is called once per frame
    void Update()
    {
        // what heaklth

        healthRatioScale = enemy.health / enemy.totalHealth;

        Vector3 newScale = initialScale;
        newScale.x *= healthRatioScale;


        transform.localScale = newScale;
        //Slider.transform.position = Camera.main.WorldToScreenPoint((Vector2)transform.parent.position + offset);
    }
}
