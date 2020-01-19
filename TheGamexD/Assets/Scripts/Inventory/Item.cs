using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        wepon,
        armor
    }
    public ItemType itemType;
    public int ID;
    public string description;
    public Sprite icon;
    public bool pickedUp;
}
