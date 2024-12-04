using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    [Header("特效预制体")]
    public GameObject normalEffect;
    public GameObject goodEffect;
    public GameObject perfectEffect;
    public GameObject missEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                //GameManager.instance.NoteHit();
                if (transform.position.y > -3.3f || transform.position.y < -4.7f) 
                {
                    GameManager.instance.NormalHit(); 
                    Instantiate(normalEffect, transform.position, normalEffect.transform.rotation);
                }
                else if(transform.position.y > -3.6f || transform.position.y < -4.4f)
                {
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //why
        if (other.tag=="Activator")
        {
            canBePressed = false;
            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
