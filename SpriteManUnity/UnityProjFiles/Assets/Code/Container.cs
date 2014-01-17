using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Container : Item
{
    public List<Item> contents = new List<Item>();

    public override void Use()
    {

    }

    public void AddItem(Item item)
    {
        contents.Add(item);
    }

}
