using UnityEngine;
public class ItemObject : MonoBehaviour, IInteract
{
    public GameObject Item;
    public int ItemCount;
    public void Execute()
    {
        bool control = false;
        foreach (var item in GameManager.Instance.Inventory.Slots)
        {
            if (item.IsFull)
            {
                StacableItem stacableItem = item.GetComponentInChildren<StacableItem>();
                if (stacableItem != null)
                {
                    if (stacableItem.ItemName == Item.GetComponent<Item>().ItemName)
                    {
                        stacableItem.SetItemCount(ItemCount);
                        control = true;
                        break;
                    }
                }
            }
        }

        if (!control)
        {
            foreach (var item in GameManager.Instance.Inventory.Slots)
            {
                if (!item.IsFull)
                {
                    GameObject newItemObject = Instantiate(Item, item.transform);                    
                    item.IsFull = true;

                    newItemObject.GetComponent<Item>().CurrentSlot = item;
                    StacableItem stacableItem = newItemObject.GetComponent<StacableItem>();
                    if (stacableItem!=null)
                    {
                        stacableItem.SetItemCount(ItemCount);
                    }
                    break;
                }
            }
        }
    }
}
