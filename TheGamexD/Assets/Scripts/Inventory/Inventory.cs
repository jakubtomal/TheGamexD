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
    [SerializeField]
    private Item[] Weapons;

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
        for(int i = 0; i < slotCount; i++)
        {
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

    public void EquipWepon(Item item)
    {
        switch(item.itemType)
        {
            case (ItemType.wepon):
                foreach(Item weapon in Weapons)
                {
                    if(weapon.ID == item.ID)
                    {
                        weapon.gameObject.SetActive(true);
                    }
                    else
                    {
                        weapon.gameObject.SetActive(false);
                    }
                }
                break;
        }
    }

}
