using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour
{

    public GameObject HealthBar;
    public GameObject Inventory;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void ShowDialogue()
    {
        HealthBar.gameObject.SetActive(false);
        Inventory.gameObject.SetActive(false);

        gameObject.SetActive(true);
    }

    public void UnShowDialogue()
    {
        HealthBar.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }

}
