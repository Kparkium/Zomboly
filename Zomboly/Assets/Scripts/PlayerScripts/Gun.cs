using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 5f;
    public float range = 100f;

    public Camera cam;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        RaycastHit target;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out target, range))
        {
            Debug.Log("Player hit: " + target.transform.name);
            Target hitTarget = target.transform.GetComponent<Target>();
            if(hitTarget != null)
            {
                hitTarget.TakeDamage(damage);
            }
        }
    }
}
