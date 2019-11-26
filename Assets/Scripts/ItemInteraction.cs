using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public bool foundItem;
    // Start is called before the first frame update
    void Start()
    {
        foundItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pickup") && foundItem)
        {
            Destroy(this.gameObject);
            foundItem = false;
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            foundItem = true;
        }
    }

    void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            foundItem = false;
        }
    }
}
