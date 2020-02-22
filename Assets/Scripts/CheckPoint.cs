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

    // Start is called before the first frame update
    void Start()
    {
        LocName.text = LocationName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TravelButton()
    {
        TravelPanel.gameObject.SetActive(true);
        LocationPanel.gameObject.SetActive(false);
    }

    public void TravelPanelClose()
    {
        TravelPanel.gameObject.SetActive(false);
        LocationPanel.gameObject.SetActive(true);
    }


    public void Close()
    {
        LocationPanel.gameObject.SetActive(false);
    }
}
