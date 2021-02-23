using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRangeScript : MonoBehaviour
{

    public Enemy parent;
    public Vector3 pathdirection;


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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pathdirection = (gameObject.transform.position - parent.Target.transform.position);
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
