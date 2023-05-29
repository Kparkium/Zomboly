using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Scriptable object to store items
[CreateAssetMenu(menuName =  "item")]
public class Item : ScriptableObject
{
    //Stores the name image body which inventory slot its in and whether it is currently equipped
    public string itemName;
    public Sprite image;
    public GameObject body;
    public bool equip = false;
    public bool isRadioComponent;
    //there is a bug where this keeps defaulting to true breaking the inventory untill you manually set to false
    public ParticleSystem particleSystem;

    public Item(){
        equip = false;
    }
}
