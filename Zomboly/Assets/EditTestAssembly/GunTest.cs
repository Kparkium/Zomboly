using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GunTest
{
    private Gun gun;
    private Camera camera;
    private GameObject targetObject;
    private UnitHealth targetHealth;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject for the gun
        GameObject gunObject = new GameObject("Gun");
        gun = gunObject.AddComponent<Gun>();

        // Set up variables and references
        gun.damage = 10;
        gun.range = 50f;
        gun.cooldownDuration = 0.5f;

        gun.muzzleFlash = new GameObject("MuzzleFlash").AddComponent<ParticleSystem>();
        gun.gunAudioSource = gunObject.AddComponent<AudioSource>();
        gun.gunAudioClip = AudioClip.Create("GunSound", 44100, 1, 44100, false);
        gun.recoil = gunObject.AddComponent<WeaponRecoil>();

        camera = new GameObject("Camera").AddComponent<Camera>();
        gun.cam = camera;

        targetObject = new GameObject("Target");
        targetHealth = targetObject.AddComponent<UnitHealth>();
        targetHealth.init(100, 100);
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the gun and target GameObjects
        Object.DestroyImmediate(gun.gameObject);
        Object.DestroyImmediate(targetObject);
        Object.DestroyImmediate(camera.gameObject);
    }

    [UnityTest]
    public IEnumerator Gun_Fires_And_Damages_Target()
    {
        // Arrange
        gun.cooldownOver = true;

        // Act
        gun.Fire(targetObject);
        yield return null;

        // Assert
        Assert.IsFalse(gun.cooldownOver);
        Assert.AreEqual(targetHealth._currentHealth, targetHealth._currentMaxHealth - gun.damage);
    }

    [UnityTest]
    public IEnumerator Gun_Does_Not_Fire_When_Cooldown_Not_Over()
    {
        // Arrange
        gun.cooldownOver = false;

        // Act
        gun.Fire();
        yield return null;

        // Assert
        Assert.IsFalse(gun.cooldownOver);
    }
}
