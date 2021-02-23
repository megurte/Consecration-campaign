using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

}


public enum ItemType { MATERIAL, HEALTH, WEAPON, KEY, QSTITEM, SPECIAL };
public enum Quality { COMMON, UNCOMMON, RARE, EPIC, LEGENDARY }

[System.Serializable]
public class Item 
{
    public ItemType type;

    public Quality quality;
    public Sprite spriteNeutral;
    //public Sprite spriteHighlighted;
    public int maxSize;

    public float cost;
    public int id;

    public int strength, stamina;

    public bool IsSpecialItem;
    public string Special;

    public string itemName;

    [TextArea(3,10)]
    public string description;

    public int Stamina { get; set; }
    public int Strength { get; set; }


    public GameObject Player;

    void Start()
    {

        //Player = GameObject.FindGameObjectWithTag("Player");
    }


    public void Use()
    {
        switch (type)
        {
            case ItemType.MATERIAL:
          
                break;
            case ItemType.HEALTH:
                if (id == 4)
                {
                    Player.GetComponent<PlayerCombat>().Heal(20);
                    Debug.Log("+20 health");
                }
                if (id == 5)
                {
                    Player.GetComponent<PlayerCombat>().Heal(40);
                    Debug.Log("+40 health");
                }
                if (id == 6)
                {
                    Player.GetComponent<PlayerCombat>().Heal(Player.GetComponent<PlayerCombat>().MaxHealth);
                    Debug.Log("+full amount of health");
                }

                break;
            case ItemType.WEAPON:

                break;

            default:
                break;
        }
    }

   

    public string GetToolTip()
    {
        string stats = string.Empty;
        string color = string.Empty;
        string newLine = string.Empty;
        string costTXT = string.Empty;
        string SpecialTXT = string.Empty;


        if (description != string.Empty)
        {
            newLine = "\n";
        }
        switch (quality)
        {
            case Quality.COMMON:
                color = "white";
                break;
            case Quality.UNCOMMON:
                color = "GREEN";
                break;
            case Quality.RARE:
                color = "blue";
                break;
            case Quality.EPIC:
                color = "TEAL";
                break;
            case Quality.LEGENDARY:
                color = "orange";
                break;
        }

        if (strength > 0)
        {
            stats += "\n+" + strength.ToString() + " " + "Strength";
        }

        if (stamina > 0)
        {
            stats += "\n+" + stamina.ToString() + " " + "Stamina";
        }


        costTXT = "\n" + "Sell cost:" + " " + cost;
        SpecialTXT = "\n" + "Effect: " + " " + Special;
        if (IsSpecialItem)
            return string.Format("<color=" + color + "><size=18>{0}</size></color><size=16><color=AQUA>" + newLine + "{1}</color>{2}</size>", itemName, description, SpecialTXT);
        else
            return string.Format("<color=" + color + "><size=18>{0}</size></color><size=16><color=AQUA>" + newLine + "{1}</color>{2}{3}</size>", itemName, description, stats, costTXT);
    }


}






