using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Item thisItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Interacted()
    {
        Inventory.add(thisItem);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
