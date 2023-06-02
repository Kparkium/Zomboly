using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public GameObject itemSlot;
    public GameObject currentEquip;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void EquipItem(GameObject newItem)
    {
        Destroy(currentEquip);
        currentEquip = Instantiate(newItem, itemSlot.transform.position, newItem.transform.rotation, this.transform);
    }
}
