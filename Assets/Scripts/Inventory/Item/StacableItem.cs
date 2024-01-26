using TMPro;

public class StacableItem : Item
{
    public int ItemCount;
    public int MaxItemCount;
    public TextMeshProUGUI ItemCountText;

    public void SetItemCount(int value)
    {     
        ItemCount += value;
        ItemCountText.text = ItemCount.ToString();
    }

    public void UseItem()
    {
        switch (ItemName)
        {
            case "Banana":
                if (ItemCount >0)
                {
                    GameManager.Instance.Player.GetComponent<PlayerStats>().SetHealt(50);
                    ItemCount -= 1;
                    ItemCountText.text = ItemCount.ToString();
                }
                if (ItemCount <=0)
                {
                    Destroy(gameObject);
                }                
                break;
        }
    }
}
