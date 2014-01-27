using UnityEngine;
using System.Collections;

public class InteractByProximity : MonoBehaviour {

    public bool PlayerCanInteract;
    private Item _usableItem;

    void Start()
    {
        _usableItem = GetComponent<Item>();
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
            print("Player using by proximity");
            _usableItem.Use();
            PlayerCanInteract = false;
        }
    }
}
