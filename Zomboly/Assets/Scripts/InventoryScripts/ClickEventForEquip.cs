using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventForEquip : MonoBehaviour
{

    public int itemIndex;

    public void OnButtonClick()
    {
        
        Inventory.equip(itemIndex);
    }

}
