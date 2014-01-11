using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public string itemName;

    public void Init(string name)
    {
        itemName = name;
    }

}
