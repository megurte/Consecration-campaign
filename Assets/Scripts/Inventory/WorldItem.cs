using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public int id;
    public Inventory inventory;
    public DataBase dataBase;
    private int i=0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            for (int j = 0; j <= 15; j++)
            {
                i = inventory.items[j].ItemgameObject.GetComponent<Slot>().id;

                if (id == inventory.items[j].id)
                {
                    inventory.items[j].count = inventory.items[j].count + 1;
                    inventory.UpdateInventory();
                    i = 0;
                    break;
                }

                if (i == 0)
                {
                    inventory.Additem(j, dataBase.items[id], dataBase.items[id].maxSize);
                    inventory.UpdateInventory();
                    i = 0;
                    break;
                }

            }     
            i = 0;
            Destroy(gameObject);
        }
    }
}