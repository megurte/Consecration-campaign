using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
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

    public void ShowDialog()
    {
        HealthBar.gameObject.SetActive(false);
        Inventory.gameObject.SetActive(false);

        gameObject.SetActive(true);
    }

    public void UnShowDialog()
    {
        HealthBar.gameObject.SetActive(true);

        gameObject.SetActive(false);
    }

}
