using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [Header("ROTATION")]
    // Rotation 
    public Vector3 currentRotation;
    public Vector3 targetRotation;

    [Header("RECOIL DISTANCE")]
    // Recoil
    public float recoilX;
    public float recoilY;
    public float recoilZ;

    [Header("MODIFIERS")]
    // Modifiers
    public float force;
    public float returnSpeed;


    //-----------------------------------------------------------------[UPDATE]-----------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime); // Slowly lerp back to start pos
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, force * Time.deltaTime); // Update current rotation towards target

        transform.localRotation = Quaternion.Euler(currentRotation); // Set rotaiton
    }

    //-----------------------------------------------------------------[RECOIL]-----------------------------------------------------------------
    public void DoRecoil()
    {
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ)); // Update target position
    }
}
