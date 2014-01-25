using UnityEngine;
using System.Collections;

public class InteractByCollision : MonoBehaviour {

    private Item usableItem;

    void Start()
    {
        usableItem = GetComponent<Item>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UseObject();
        }
    }
    public void UseObject()
    {
        {
            usableItem.Use();
        }
    }
}
