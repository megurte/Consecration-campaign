using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Inventory : MonoBehaviour
{

    public DataBase dataBase;

    public List<InventoryItem> items = new List<InventoryItem>();

    public GameObject gameObjShow;

    public GameObject InventoryMainObject;
    public int maxCount;

    public Camera cam;
    public EventSystem es;

    public int Currentid;
    public InventoryItem currentItem;
    
    //test
    public int SelectedItemid;
    public bool IsEmpty;

    public RectTransform movingobject;
    public Vector3 offset;

    public GameObject tooltip;
    public Text visualText;

    public void Start()
    {
        if (items.Count == 0)
        {
            AddGraphics();
        }

        UpdateInventory();
    }

    public void Update()
    {
        if (Currentid != -1 || Currentid != 0)
        {
            MovingObject();
        }     
      
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryMainObject.SetActive(!InventoryMainObject.activeSelf);
            if (InventoryMainObject.activeSelf)
                UpdateInventory();
            if (tooltip)
                tooltip.SetActive(false);
        }
    }

    public void UpdateInventory()
    {
        for(int i = 0; i<maxCount; i++)
        {
            if(items[i].id !=0 && items[i].count > 1)          
                items[i].ItemgameObject.GetComponentInChildren<Text>().text = items[i].count.ToString();           
            else
                items[i].ItemgameObject.GetComponentInChildren<Text>().text = "";

            items[i].ItemgameObject.GetComponent<Image>().sprite = dataBase.items[items[i].id].spriteNeutral;
        }      
    }

    public void SearchForSameItem(Item item, int count)
    {
        for (int i=0; i < maxCount; i++)
        {
            if (items[i].id == item.id)
            {
                
                if (items[0].count < 200)
                {
                    items[i].count += count;

                    if (items[0].count > 200)
                    {
                        count = items[i].count - 200;
                        items[i].count = 200;
                    }
                    else
                    {
                        count = 0;
                        i = maxCount;
                    }
                }
            }
        }
        if (count > 0)
        {
            for(int i =0; i < maxCount; i++)
            {
                if (items[i].id == 0)
                {
                    Additem(i,item,count);
                    i = maxCount;
                }
            }
        }
    }
   

    public void AddGraphics()
    {
        for (int i = 0; i<maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;
            newItem.name = i.ToString();
            InventoryItem ii = new InventoryItem();
            ii.ItemgameObject = newItem;
            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempbutton = newItem.GetComponent<Button>();

            tempbutton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
        
    }

    public void SelectObject()
    {

        
            if (Currentid == -1)
            {
                if (!IsEmpty)
                {
                    Currentid = int.Parse(es.currentSelectedGameObject.name);
                    currentItem = CopyInventoryItem(items[Currentid]);
                
                    movingobject.gameObject.SetActive(true);
                    movingobject.GetComponent<Image>().sprite = dataBase.items[currentItem.id].spriteNeutral;
                }
                
                Additem(Currentid, dataBase.items[0], 0);

            }
            else
            {
                InventoryItem ii = items[int.Parse(es.currentSelectedGameObject.name)];
                if (currentItem.id != ii.id)
                {
                    AddInventoryitem(Currentid, ii);

                    AddInventoryitem(int.Parse(es.currentSelectedGameObject.name), currentItem);

                }
                else
                {
                    if (ii.count + currentItem.count <= 200)
                        ii.count += currentItem.count;
                    else
                    {
                        Additem(Currentid, dataBase.items[ii.id], ii.count + currentItem.count);
                        ii.count = 200;
                    }
                    ii.ItemgameObject.GetComponentInChildren<Text>().text = ii.count.ToString();
                }

                Currentid = -1;

                movingobject.gameObject.SetActive(false);
            }        
    }

    public InventoryItem CopyInventoryItem(InventoryItem old)
    {
        InventoryItem New = new InventoryItem();
        New.id = old.id;
        New.ItemgameObject = old.ItemgameObject;
        New.count = old.count;
        return New;
    }

    public void MovingObject()
    {
            Vector3 pos = Input.mousePosition + offset;
            pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
            movingobject.position = cam.ScreenToWorldPoint(pos);       
    }

    public void MoveToolTip()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        tooltip.transform.position = cam.ScreenToWorldPoint(pos);
    }
    

    public void Additem(int id, Item item, int count)
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].ItemgameObject.GetComponent<Image>().sprite = item.spriteNeutral;
        items[id].ItemgameObject.GetComponent<Slot>().id = item.id;

        if (count > 1 && item.id != 0)
        {
            items[id].ItemgameObject.GetComponentInChildren<Text>().text = count.ToString();
        }
        else
        {
            items[id].ItemgameObject.GetComponentInChildren<Text>().text = "";
        }

    }
    
    public void RemoveItem(int itemid)
    {
        for (int i = 0; i < 16; i++)
        {
            if(itemid == items[i].id)
            {
                if (items[i].count > 1)
                {
                    items[i].count = items[i].count - 1;
                    UpdateInventory();
                }
                else
                {
                    items[i].id = 0;
                    items[i].count = 0;
                    items[i].ItemgameObject.GetComponent<Image>().sprite = gameObjShow.GetComponent<Image>().sprite;
                    items[i].ItemgameObject.GetComponent<Slot>().id = 0;
                    Debug.Log("Cleared slot: " + i);
                    UpdateInventory();
                }
                
                break;
            }

        }

    }




    public void AddInventoryitem(int id, InventoryItem invitem)
    {
        items[id].id = invitem.id;
        items[id].count = invitem.count;
        items[id].ItemgameObject.GetComponent<Image>().sprite = dataBase.items[invitem.id].spriteNeutral;
        items[id].ItemgameObject.GetComponent<Slot>().id = invitem.id;

        if (invitem.count > 1 && invitem.id != 0)
        {
            items[id].ItemgameObject.GetComponentInChildren<Text>().text = invitem.count.ToString();
        }
        else
        {
            items[id].ItemgameObject.GetComponentInChildren<Text>().text = " ";
        }

    }

}

[System.Serializable]
public class InventoryItem
{
    public int id;
    public GameObject ItemgameObject;
    public int count;
}