using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroRangeAngel : MonoBehaviour
{
    public AngelEnemy parent;


    private void Start()
    {
        parent = GetComponentInParent<AngelEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.IsTriggered = true;
          //parent.Target = collision.transform;
          //Debug.Log("PlayerEnter");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.IsTriggered = false;
          //parent.Target = null;
          //Debug.Log("PlayerExit");
        }
    }
}
