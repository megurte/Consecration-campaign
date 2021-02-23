using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRuneScript : MonoBehaviour
{

    public GameObject ActiveAnim;
    public GameObject CheckPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ActiveAnim.SetActive(true);                   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!CheckPoint.active)
                    CheckPoint.SetActive(true);
                else
                    CheckPoint.SetActive(false);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
            CheckPoint.SetActive(false);
    }
}
