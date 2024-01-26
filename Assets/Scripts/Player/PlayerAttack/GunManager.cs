using UnityEngine;
public class GunManager : MonoBehaviour
{
    public static GunManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    [SerializeField] private AnimationController animationController;
    [SerializeField] private GameObject Sword;
    public bool IsSword;

    WeaponItem newWeaponItem;
    StacableItem newStacableItem;

    private void Start()
    {
        Sword.SetActive(false);
    }
    private void Update()
    {
        Inputs();
        if (newWeaponItem != null)
        {
            if (newWeaponItem.CurrentSlot.GetComponentInParent<Inventory>().CurrentInventory != InventoryType.SELLECTINVENTORY)
            {
                newWeaponItem.UseItem();
                newWeaponItem = null;
            }
        }        
    }
    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            newWeaponItem = GameManager.Instance.SellectInventory.Slots[0].GetComponentInChildren<WeaponItem>();
            if (newWeaponItem != null)
            {
                newWeaponItem.UseItem();
            }


            newStacableItem = GameManager.Instance.SellectInventory.Slots[0].GetComponentInChildren<StacableItem>();
            if (newStacableItem != null)
            {
                newStacableItem.UseItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            newWeaponItem = GameManager.Instance.SellectInventory.Slots[1].GetComponentInChildren<WeaponItem>();
            if (newWeaponItem != null)
            {
                newWeaponItem.UseItem();
            }


            newStacableItem = GameManager.Instance.SellectInventory.Slots[1].GetComponentInChildren<StacableItem>();
            if (newStacableItem != null)
            {
                newStacableItem.UseItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            newWeaponItem = GameManager.Instance.SellectInventory.Slots[2].GetComponentInChildren<WeaponItem>();
            if (newWeaponItem != null)
            {
                newWeaponItem.UseItem();
            }


            newStacableItem = GameManager.Instance.SellectInventory.Slots[2].GetComponentInChildren<StacableItem>();
            if (newStacableItem != null)
            {
                newStacableItem.UseItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            newWeaponItem = GameManager.Instance.SellectInventory.Slots[3].GetComponentInChildren<WeaponItem>();
            if (newWeaponItem != null)
            {
                newWeaponItem.UseItem();
            }


            newStacableItem = GameManager.Instance.SellectInventory.Slots[3].GetComponentInChildren<StacableItem>();
            if (newStacableItem != null)
            {
                newStacableItem.UseItem();
            }
        }
    }

    public void SellectWeapon()
    {
        if (!IsSword)
        {
            Sword.SetActive(true);
            IsSword = true;
            animationController.SetBool("SwordState", true);
        }
        else
        {
            Sword.SetActive(false);
            IsSword = false;
            animationController.SetBool("SwordState", false);
            animationController.CrossFade("SwordDrop", .2f);
        }       
    }
}




  