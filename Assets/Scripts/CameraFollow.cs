using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    //private bool Check = false;
	

	void Update ()
    {

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.7f) + new Vector3(0, 1.8f, -10);
            //if (Input.GetKeyDown(KeyCode.S) && Check == false)
            //{
            //    transform.position = Vector3.Lerp(transform.position, target.position, 0.7f) + new Vector3(0, 0.8f, -10);
            //    Check = true;
            //}

            //if (Input.GetKeyUp(KeyCode.S) && Check == true)
            //{
            //    transform.position = Vector3.Lerp(transform.position, target.position, 0.7f) + new Vector3(0, 1.8f, -10);
            //    Check = false;
            //}
        }
	}
}
