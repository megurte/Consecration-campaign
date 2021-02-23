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
        if (Currenthp <= 0)
            Death();
    }


    void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
                if (!DialogeNPC.active)
                {
                    DialogeNPC.GetComponent<DialogueNPC>().ShowDialogue();
                }
                else
                {
                    DialogeNPC.GetComponent<DialogueNPC>().UnShowDialogue();
                }
           
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
        DialogeNPC.GetComponent<DialogueNPC>().UnShowDialogue();
       
    }
}
