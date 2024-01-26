using UnityEngine.EventSystems;

public class WeaponItem : Item
{
    public int Damage;

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            SetItem();
        }
    }

    private void SetItem()
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
    public void UseItem()
    {
        switch (ItemName) 
        {
            case "Sword":
                GunManager.Instance.SellectWeapon();
                break;      
        }
    }
}

