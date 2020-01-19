using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item = null;
    public bool empty = true;
    public Sprite icon;
    public Item.ItemType itemType;
    public int ID;
    public string description;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }
}
