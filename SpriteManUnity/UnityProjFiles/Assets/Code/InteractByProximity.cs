using UnityEngine;
using System.Collections;

public class InteractByProximity : MonoBehaviour {

    public bool PlayerCanInteract;
    private Item usableItem;

    void Start()
    {
        usableItem = GetComponent<Item>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerCanInteract = true;

            GameObject player = other.gameObject;
            Player myPlayer = player.GetComponent<Player>();

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            PlayerCanInteract = false;
    }

    public void UseObject()
    {
        if (PlayerCanInteract)
        {
            usableItem.Use();
            PlayerCanInteract = false;
        }
    }
}
