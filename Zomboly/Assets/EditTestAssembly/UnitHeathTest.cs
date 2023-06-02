using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Assertions;
using Assert = UnityEngine.Assertions.Assert;

// Kisoon

public class UnitHealthTest
{
    private UnitHealth testHealth;

    [SetUp]
    public void SetUp()
    {
        testHealth = new UnitHealth();
        testHealth.init(100, 100);
    }

    [TearDown]
    public void TearDown()
    {

    }

    [UnityTest]
    public IEnumerator CheckHealthSetup()
    {
        yield return null;
        Assert.IsTrue(testHealth._currentHealth == testHealth._currentMaxHealth);
    }

    [Test]
    public void DamageUnit_DecreasesHealth()
    {
        // Arrange
        var unit = new GameObject().AddComponent<UnitHealth>();
        unit.init(10, 10);

        // Act
        unit.DamageUnit(5);

        // Assert
        Assert.AreEqual(5, unit.Health);
    }

    [Test]
    public void DamageUnit_DestroyGameObjectWhenHealthZero()
    {
        // Arrange
        var unit = new GameObject().AddComponent<UnitHealth>();
        unit.init(5, 5);

        // Act
        unit.DamageUnit(100);

        // Assert
        Assert.IsTrue(unit == null);
    }

    [Test]
    public void HealUnit_IncreasesHealth()
    {
        // Arrange
        var unit = new GameObject().AddComponent<UnitHealth>();
        unit.init(5, 10);

        // Act
        unit.HealUnit(3);

        // Assert
        Assert.AreEqual(8, unit.Health);
    }

    [Test]
    public void HealUnit_DoesNotExceedMaxHealth()
    {
        // Arrange
        var unit = new GameObject().AddComponent<UnitHealth>();
        unit.init(8, 10);

        // Act
        unit.HealUnit(5);

        // Assert
        Assert.AreEqual(10, unit.Health);
    }

}