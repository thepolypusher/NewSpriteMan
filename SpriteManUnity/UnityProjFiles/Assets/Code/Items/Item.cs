using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public int ItemID;
    public string ItemType;

    //public abstract void Init();

    public abstract void Use();

    public void TransferItem(Item item, Container container)
    {
        container.AddItem(item);
    }

}
