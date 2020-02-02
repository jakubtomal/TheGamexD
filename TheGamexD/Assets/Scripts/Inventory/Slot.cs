using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item item = null;
    public bool empty = true;
    public Sprite icon = null;
    public ItemType itemType;
    public GameObject slotItemGo;
    public int ID;
    public string description;

    private Color iconColor = Color.white;
    private Color emptyColor = new Color(1, 1, 1, 0);

    private void Start()
    {
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        slotItemGo.GetComponent<Image>().sprite = icon;
        if(icon == null)
        {
            slotItemGo.GetComponent<Image>().color = emptyColor;
        }
        else
        {
            slotItemGo.GetComponent<Image>().color = iconColor;
        }
        
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }

}
