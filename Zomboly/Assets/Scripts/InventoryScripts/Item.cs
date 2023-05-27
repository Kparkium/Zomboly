using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Scriptable object to store items
[CreateAssetMenu(menuName =  "item")]
public class Item : ScriptableObject
{
    //Stores the name image body which inventory slot its in and whether it is currently equipped
    public string name;
    public Sprite image;
    public GameObject body;
    public int inventoryNumber;
    public bool equip = false;
    public bool isRadio;
    //there is a bug where this keeps defaulting to true breaking the inventory untill you manually set to false
    public Item(){
        equip = false;
    }
    
}
