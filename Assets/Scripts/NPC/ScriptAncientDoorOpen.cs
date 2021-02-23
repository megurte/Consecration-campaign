using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAncientDoorOpen : MonoBehaviour
{
    public bool ActivePhaseBool;

    public GameObject AncientDoor;
    public GameObject Explorer;

    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {

        if (ActivePhaseBool)
        {
            ActivePhase();
        }

    }

    void ActivePhase()
    {
        Explorer.SetActive(true);
        Explorer.GetComponent<Animator>().SetTrigger("IsAnimated");

        showdialog();

    }

    void showdialog()
    {
        StartCoroutine(waiting());
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(5);
        AncientDoor.GetComponent<Animator>().SetTrigger("IsAnimated");
        yield return new WaitForSeconds(1.5f);
        Destroy(AncientDoor.GetComponent<Collider2D>());
    }

}
