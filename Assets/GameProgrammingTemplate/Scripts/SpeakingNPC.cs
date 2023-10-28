using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeakingNPC : MonoBehaviour
{
    GameObject textObject;

    // Start is called before the first frame update
    void Start()
    {
        textObject = transform.GetChild(0).gameObject;

        textObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            textObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            textObject.SetActive(false);
        }
    }
}
