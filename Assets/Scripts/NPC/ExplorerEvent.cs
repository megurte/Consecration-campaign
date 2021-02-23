using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorerEvent : MonoBehaviour
{
    public bool IsEventTriggered = false;
    public Transform point;
    public GameObject Explorer;
    public GameObject ExplorerTriggered;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (IsEventTriggered)
        {
            ExplorerTriggered.SetActive(true);
            anim.SetBool("IsEventTriggered",true);
            transform.Translate(point.forward * Time.deltaTime, Space.World);
            if(transform.position == point.position)
            {
                anim.SetBool("IsEventTriggered", false);
                transform.Translate(0, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
