using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =  "item")]
public class Item : ScriptableObject
{
    public string name;
    public Sprite image;
    public Object body;
    public int inventoryNumber;
    public bool equip = false;
    
}
