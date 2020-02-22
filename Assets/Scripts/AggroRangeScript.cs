using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRangeScript : MonoBehaviour
{

    public Enemy parent;


    private void Start()
    {
        parent = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {     
            parent.Target = collision.transform;           
            //Debug.Log("PlayerEnter");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.Target = null;
            //Debug.Log("PlayerExit");
        }
    }


}
