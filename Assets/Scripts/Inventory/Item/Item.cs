using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class Item : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public InventoryType[] CurrentInventory;
    public string ItemName;
    public Slot CurrentSlot;

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.SetParent(GameManager.Instance.Canvas);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;    
    } 

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        eventData.position = Input.mousePosition;
        List<RaycastResult> result = new();
        GameManager.Instance.GraphicRaycaster.Raycast(eventData, result);

        foreach (RaycastResult r in result)
        {
            if (r.gameObject.name == "Slot")
            {
                if (!r.gameObject.GetComponent<Slot>().IsFull)
                {
                    foreach (var item in CurrentInventory)
                    {
                        if (r.gameObject.GetComponentInParent<Inventory>().CurrentInventory == item)
                        {
                            transform.SetParent(r.gameObject.transform);
                            transform.position = r.gameObject.transform.position;
                            CurrentSlot.IsFull = false;
                            CurrentSlot = r.gameObject.GetComponent<Slot>();
                            CurrentSlot.IsFull = true;
                            break;
                        }
                    }                   
                }
            }
            else
            {
                transform.position = CurrentSlot.transform.position;
            }
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
    }


}
