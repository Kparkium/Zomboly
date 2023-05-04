using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this file is to make sure at the start the equip is set to the right values and not carried over from previous instance
public class SetObjects : MonoBehaviour
{
    //all game Items 
    public Item item1;
    public Item item2;

    // awake is called as the game starts
    void Start()
    {
        //set the equip to the right value
        item1.equip = true;
        item2.equip = false;
    }

}
