using UnityEngine.EventSystems;

public class AvailableItem : StacableItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }

    private void UseItem()
    {
        switch (CurrentSlot.GetComponentInParent<Inventory>().CurrentInventory)
        {
            case InventoryType.INVENTORY:

                foreach (var item in GameManager.Instance.SellectInventory.Slots)
                {
                    if (!item.IsFull)
                    {
                        transform.SetParent(item.gameObject.transform);
                        transform.position = item.gameObject.transform.position;
                        CurrentSlot.IsFull = false;
                        CurrentSlot = item.gameObject.GetComponent<Slot>();
                        CurrentSlot.IsFull = true;
                        break;
                    }
                }
                break;

            case InventoryType.SELLECTINVENTORY:
                foreach (var item in GameManager.Instance.Inventory.Slots)
                {
                    if (!item.IsFull)
                    {
                        transform.SetParent(item.gameObject.transform);
                        transform.position = item.gameObject.transform.position;
                        CurrentSlot.IsFull = false;
                        CurrentSlot = item.gameObject.GetComponent<Slot>();
                        CurrentSlot.IsFull = true;
                        break;
                    }
                }
                break;
        }
    }
}
