using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform Canvas;
    public GraphicRaycaster GraphicRaycaster;
    public GameObject Player;
    public GameObject Cam1;
    public GameObject Cam2;

    public Inventory Inventory;
    public Inventory SellectInventory;


    public GameObject InventoryTab;
    bool isInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventory=isInventory? false : true;
            InventoryTab.SetActive(isInventory);
            if (isInventory)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
