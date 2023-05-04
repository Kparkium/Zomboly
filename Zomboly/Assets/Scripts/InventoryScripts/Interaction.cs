using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class controls the players abillity to pick up items
public class Interaction : MonoBehaviour
{
    //determines the distance that a user can pick up a item is set to 2 in the unity menu
    public float raycastDistance = 10f;

    // Update is called once per frame
    void Update()
    {
        //if the input is E
        if (Input.GetKeyDown(KeyCode.E))
        {
            //creates a ray cast
            RaycastHit hit;
            //casts a ray cast and if it hits
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                //if the ray cast hits checks the object has the interactable script 
                var script = hit.collider.gameObject.GetComponent<Interactable>();
                if(script != null)
                {
                    //if it does call interacted function
                    script.gameObject.GetComponent<Interactable>().Interacted();
                }
            }
            
        }
    }
}
