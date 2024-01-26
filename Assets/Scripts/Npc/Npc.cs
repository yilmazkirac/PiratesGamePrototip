using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour, IInteract
{
    public GameObject Item;
    public GameObject Item2;
    public int ItemCount;
    public string StartDialogueText;
    public string EndDialogueText;

    bool isQuest;
    public void Execute()
    {   
        if (!isQuest)
        {
            SetText(StartDialogueText);
            SetButton();
            Cursor.lockState = CursorLockMode.None;
            isQuest = true;
        }
        else
        {
            SetText(EndDialogueText);
            SetButton2();
            Cursor.lockState = CursorLockMode.None;
            isQuest=false;
        }       
    }  



    private void SetText(string Text)
    {
        UIManager.Instance.DialogueText.text = Text;
        UIManager.Instance.DialoguePanel.SetActive(true);
    }
    private void SetButton()
    {
        UIManager.Instance.DialogueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        UIManager.Instance.DialogueButton.GetComponent<Button>().onClick.AddListener(() => { SetItem(); });
    }
    private void SetButton2()
    {
        UIManager.Instance.DialogueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        UIManager.Instance.DialogueButton.GetComponent<Button>().onClick.AddListener(() => { SetItem2(); });
    }
    private void SetItem()
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
                    if (stacableItem != null)
                    {
                        stacableItem.SetItemCount(ItemCount);
                    }
                    break;
                }
            }
        }
        UIManager.Instance.DialoguePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetItem2()
    {

        bool control = false;
        foreach (var item in GameManager.Instance.Inventory.Slots)
        {
            if (item.IsFull)
            {
                StacableItem stacableItem = item.GetComponentInChildren<StacableItem>();
                if (stacableItem != null)
                {
                    if (stacableItem.ItemName == Item2.GetComponent<Item>().ItemName)
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
                    GameObject newItemObject = Instantiate(Item2, item.transform);
                    item.IsFull = true;

                    newItemObject.GetComponent<Item>().CurrentSlot = item;
                    StacableItem stacableItem = newItemObject.GetComponent<StacableItem>();
                    if (stacableItem != null)
                    {
                        stacableItem.SetItemCount(ItemCount);
                    }
                    break;
                }
            }
        }
        UIManager.Instance.DialoguePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
