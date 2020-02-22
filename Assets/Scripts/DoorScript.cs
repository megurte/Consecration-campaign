using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{

    public GameObject player;
    public int Keyid;
    public Inventory inv;
    public Collider2D doorcoll;
    public Sprite sprite;
    public Text textmessage;

    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for(int i =0; i < 15; i++)
            {
                if (Keyid == inv.items[i].id)
                {                    
                    Debug.Log("Opened");
                    //gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                    doorcoll.enabled = false;
                    //textmessage.gameObject.SetActive(true);
                    //textmessage.text = "Item " + Keyid +" used";
                    inv.RemoveItem(Keyid);
                    break;
                }

            }
            
       }

    }
}
