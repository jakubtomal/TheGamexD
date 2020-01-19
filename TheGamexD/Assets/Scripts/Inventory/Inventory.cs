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
    private Slot[] slots;

    private void Start()
    {
        InventoryEnable = false;
        slotCount = slotHolder.GetComponentsInChildren<Slot>().Length;
        slots = new Slot[slotCount];
        for(int i = 0; i < slotCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).GetComponent<Slot>();
            if(slots[i].item == null)
            {
                Debug.Log("22222");
                slots[i].empty = true;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryEnable = !InventoryEnable;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
            AddItem(item);

        }
    }

    private void AddItem(Item item)
    {
        Debug.LogError("add");
        for(int i = 0; i < slotCount; i++)
        {
            Debug.LogError(slotCount);
            if(slots[i].empty)
            {

                item.pickedUp = true;
                slots[i].icon = item.icon;
                slots[i].itemType = item.itemType;
                slots[i].description = item.description;
                slots[i].ID = item.ID;
                slots[i].item = item;
                item.gameObject.transform.parent = slots[i].gameObject.transform;
                item.gameObject.SetActive(false);
                slots[i].empty = false;
                slots[i].UpdateSlot();
                return;
            }
            
        }

    }

}
