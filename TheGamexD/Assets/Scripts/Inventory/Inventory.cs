using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject slotHolder;
    private bool _inventoryEnable;
    private bool InventoryEnable
    {
        get
        {
            return _inventoryEnable;
        }
        set
        {
            _inventoryEnable = value;
            inventory.SetActive(value);
            
        }
    }

    private int slotCount;
    private int enabledSlotCount;
    private GameObject[] slots;

    private void Start()
    {
        InventoryEnable = false;
        slotCount = slotHolder.transform.childCount;
        slots = new GameObject[slotCount];
        for(int i = 0; i < slotCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryEnable = !InventoryEnable;
        }
    }

}
