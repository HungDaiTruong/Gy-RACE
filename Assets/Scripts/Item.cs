using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Bomb,
    Laser,
    Shield
}

public class Item : MonoBehaviour
{
    public ItemType itemType;
}