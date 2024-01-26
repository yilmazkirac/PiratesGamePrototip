using System.Collections.Generic;
using UnityEngine;

public enum InventoryType { INVENTORY,SELLECTINVENTORY}
public class Inventory : MonoBehaviour
{
    public InventoryType CurrentInventory;
    public List<Slot> Slots;
}
