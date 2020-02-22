using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public int id;
    private Inventory inventory;
    private DataBase dataBase;
    private GameObject cameraobj;
    public Sprite EmptySlot;


    public void Start()
    {
        cameraobj = GameObject.FindGameObjectWithTag("MainCamera");
        inventory = cameraobj.GetComponent<Inventory>();
        dataBase = cameraobj.GetComponent<DataBase>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        inventory.SelectedItemid = id;

        if ( inventory.SelectedItemid != 0)
        {
            inventory.visualText.text = dataBase.items[id].GetToolTip();
            inventory.tooltip.SetActive(true);
            inventory.MoveToolTip();
        }
        else
            inventory.tooltip.SetActive(false); 

        if (inventory.SelectedItemid == 0)
            inventory.IsEmpty = true;     
        else
            inventory.IsEmpty = false;

      
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        inventory.tooltip.SetActive(false);
    }


    private void UseItem()
    {
        if (inventory.SelectedItemid != 0)
        {
            dataBase.items[id].Use();          
            inventory.RemoveItem(inventory.SelectedItemid);             
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (!inventory.IsEmpty)
            {
                UseItem();
                Debug.Log("Use item");
                inventory.UpdateInventory();
            }         
        }
    }
}
