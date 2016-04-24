using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuScript : MonoBehaviour {

    public GameObject dialogue, square, text;
    public Renderer rend1, rend2;

    void Start()
    {
        dialogue = GameObject.Find("Dialogue");
        square = GameObject.Find("Square");
    }

    public void beABigBaby()
    {
        if (text.GetComponent<Text>().enabled)
            text.GetComponent<Text>().enabled = false;

        //text = GameObject.Find("Message1");
        //rend1 = dialogue.GetComponent<SpriteRenderer>();
        //rend1.enabled = true;
        //rend2 = square.GetComponentInChildren<SpriteRenderer>();
        //rend2.enabled = true;

        //text.GetComponent<Text>().enabled = true;

       Application.LoadLevel("Scenes/Settings");
    }

    public void Freedom()
    {
        if (text.GetComponent<Text>().enabled)
            text.GetComponent<Text>().enabled = false;

        //text = GameObject.Find("Message2");
        //rend1 = dialogue.GetComponent<SpriteRenderer>();
        //rend1.enabled = true;
        //rend2 = square.GetComponentInChildren<SpriteRenderer>();
        //rend2.enabled = true;

        //text.GetComponent<Text>().enabled = true;

        Application.LoadLevel("Scenes/Opening");
    }

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;

     }
    void Update()
    {

    }
}
