using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    //   public Transform target;
    //   //private bool Check = false;


    //void Update ()
    //   {

    //       if (target)
    //       {
    //           transform.position = Vector3.Lerp(transform.position, target.position, 0.7f) + new Vector3(0, 1.8f, -10);
    //           //if (Input.GetKeyDown(KeyCode.S) && Check == false)
    //           //{
    //           //    transform.position = Vector3.Lerp(transform.position, target.position, 0.7f) + new Vector3(0, 0.8f, -10);
    //           //    Check = true;
    //           //}

    //           //if (Input.GetKeyUp(KeyCode.S) && Check == true)
    //           //{
    //           //    transform.position = Vector3.Lerp(transform.position, target.position, 0.7f) + new Vector3(0, 1.8f, -10);
    //           //    Check = false;
    //           //}
    //       }
    //}

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }
}
