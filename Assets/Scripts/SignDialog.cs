using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignDialog : MonoBehaviour
{
    public bool hitSign;
    public GameObject text;
    public GameObject diaBox;
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        hitSign = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pickup") && hitSign)
        {
            diaBox.GetComponent<Image>().enabled = true;
            message.GetComponent<Text>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            text.GetComponent<Text>().enabled = true;
            hitSign = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        text.GetComponent<Text>().enabled = false;
        diaBox.GetComponent<Image>().enabled = false;
        message.GetComponent<Text>().enabled = false;
        hitSign = false;
    }
}
