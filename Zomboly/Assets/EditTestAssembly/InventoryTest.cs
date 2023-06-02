using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Assertions;
using Assert = UnityEngine.Assertions.Assert;

// Jakob

public class InventoryTest
{
    
    private Inventory testInventory;
    private Item testItem;

    [SetUp]
    public void SetUp()
    {
        testInventory = new Inventory();
        testItem = ScriptableObject.CreateInstance<Item>();
        testItem.name = "TestItem";
    }

    [TearDown]
    public void TearDown()
    {
        
    }

    [UnityTest]
    public IEnumerator CheckInventorySetup()
    {
        yield return null;
        Assert.IsTrue(testInventory.count == 0);
    }

    [UnityTest]
    public IEnumerator DropItem_ItemRemovedFromInventory()
    {
        yield return null;
        testInventory.add(testItem);

        Item removedItem = testInventory.dropItem(0);

        yield return null;

        Assert.AreEqual(testItem, removedItem);
        Assert.IsFalse(testInventory.inventoryList.Contains(testItem));
    }

    [UnityTest]
    public IEnumerator Equip_ItemEquippedSuccessfully()
    {
        yield return null;
        testInventory.add(testItem);

        testInventory.equip(0);

        yield return null;

        Assert.IsTrue(testItem.equip);
        Assert.AreEqual(testItem, testInventory.equipped);
    }

    [UnityTest]
    public IEnumerator GetEquipped_ReturnsEquippedGameObject()
    {
        yield return null;
        GameObject equippedGameObject = new GameObject();
        testItem.body = equippedGameObject;
        testInventory.equipped = testItem;

        GameObject result = testInventory.getEquipped();

        yield return null;

        Assert.AreEqual(equippedGameObject, result);
    }

}
