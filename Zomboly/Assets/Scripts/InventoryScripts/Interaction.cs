using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float raycastDistance = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
            {
                Debug.Log(hit.collider.gameObject.name);
                var script = hit.collider.gameObject.GetComponent<Interactable>();
                if(script != null)
                {
                    script.gameObject.GetComponent<Interactable>().Interacted();
                }
            }
            else
            {
                Debug.Log("no object");
            }
        }
    }
}
