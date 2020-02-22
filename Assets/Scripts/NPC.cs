using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC : MonoBehaviour
{
    public string npcname;
    public GameObject textobj;
    public int Currenthp;
    public GameObject DialogeNPC;



    void Start()
    {
        textobj.GetComponent<Text>().text = npcname;
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Currenthp -= damage;     
        //if (currentHealth <= 0)
        //    Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //}
            DialogeNPC.GetComponent<DialogNPC>().ShowDialog();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DialogeNPC.GetComponent<DialogNPC>().ShowDialog();

        }
        else
        {
            DialogeNPC.GetComponent<DialogNPC>().UnShowDialog();

        }
    }
}
