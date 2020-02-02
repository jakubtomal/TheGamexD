using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemType itemType;
    public int ID;
    public string description;
    public Sprite icon;
    public bool pickedUp;


    [HideInInspector]
    public bool equipped;
    [HideInInspector]
    private Inventory playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<Inventory>();
    }

    public void ItemUsage()
    {
        switch(itemType)
        {
            case (ItemType.wepon):
                playerInventory.EquipWepon(this);
                break;
        }
    }
}
