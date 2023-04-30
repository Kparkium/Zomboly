using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject itemSlot;
    public GameObject currentEquip;

    public GameObject item1;


    // Start is called before the first frame update
    void Start()
    {
        EquipItem(item1);

    }

    public void EquipItem(GameObject newItem)
    {
        Destroy(currentEquip);
        currentEquip = Instantiate(newItem, itemSlot.transform);
    }
}
