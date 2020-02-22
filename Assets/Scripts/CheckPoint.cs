using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public string LocationName;
    public Text LocName;
    public GameObject LocationPanel;
    public GameObject TravelPanel;
    public GameObject HealthBarUI;
    public GameObject Inv;

    // Start is called before the first frame update
    void Start()
    {
        LocName.text = LocationName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPointWindowOpen()
    {
        LocationPanel.SetActive(true);
        LocName.text = LocationName;
        Inv.SetActive(false);
    }

    public void TravelButton()
    {
        TravelPanel.SetActive(true);
        LocationPanel.SetActive(false);
    }

    public void TravelPanelClose()
    {
        TravelPanel.SetActive(false);
        LocationPanel.SetActive(true);
    }


    public void Close()
    {
        LocationPanel.SetActive(false);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckPointWindowOpen();
            }

        }
        else
            Close();
    }
}
