using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //-----------------------------------------------------------------[VARIABLES]-----------------------------------------------------------------
    [Header("MODIFIERS")]
    public int damage;
    public float range;
    public float cooldownDuration;

    [Header("EFFECTS")]
    public ParticleSystem muzzleFlash;
    public AudioSource gunAudioSource;
    public AudioClip gunAudioClip;
    public WeaponRecoil recoil;

    [Header("OTHER")]
    public Camera cam;
    public bool cooldownOver = true;

    //-----------------------------------------------------------------[START]-----------------------------------------------------------------
    // Start is called before the first frame update
    public void Start()
    {
        cam = GetComponentInParent<Camera>();
        gunAudioSource = GetComponentInParent<AudioSource>();
        recoil = GetComponent<WeaponRecoil>();


        gunAudioSource.clip = gunAudioClip; // Set sound of weapon
        cooldownDuration = gunAudioClip.length; // Set cooldown to match audio clip
    }

    //-----------------------------------------------------------------[UPDATE]-----------------------------------------------------------------
    // Called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Fire();
        }
    }

    //-----------------------------------------------------------------[FIRE]-----------------------------------------------------------------
    private void Fire()
    {
        // if not available to use (still cooling down) just exit
        if (cooldownOver == false)
        {
            return;
        }

        // Plays effects
        ShootEffects();

        // Stores target information
        RaycastHit target;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out target, range)) // Checks for valid hit
        {
            Debug.Log("Player hit: " + target.transform.name);
            Target hitTarget = target.transform.GetComponent<Target>();

            if (hitTarget != null)
            { // If target is valid and has a target script
                hitTarget.TakeDamage(damage);
            }
        }

        StartCoroutine(StartCooldown());

    }

    //-----------------------------------------------------------------[OTHER METHODS]-----------------------------------------------------------------
    // Start cooldown timer on weapon
    private IEnumerator StartCooldown()
    {
        cooldownOver = false;
        yield return new WaitForSeconds(cooldownDuration);
        cooldownOver = true;
    }

    // Self destruct object after 0.1 seconds
    IEnumerator SelfDestruct(GameObject toDestroy)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(toDestroy);
    }


    private void ShootEffects()
    {
        // Muzzle Flash effect from gun tip
        MuzzleFlash();
        // Sound Effect of each gun
        PlayShootSound();
        // Recoil
        DoRecoil();
    }

    private void MuzzleFlash()
    {
        GameObject temp = Instantiate(muzzleFlash, this.transform).gameObject;
        muzzleFlash.Play();
        StartCoroutine(SelfDestruct(temp));
    }

    private void PlayShootSound()
    {
        gunAudioSource.Play();
    }

    private void DoRecoil()
    {
        recoil.DoRecoil();
    }
}
