using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuScript : MonoBehaviour {

    public GameObject dialogue, square, text;
    public Renderer rend1, rend2;

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

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

#pragma warning disable CS0618 // Type or member is obsolete
       Application.LoadLevel("Scenes/Settings");
#pragma warning restore CS0618 // Type or member is obsolete
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

#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("Scenes/Opening");
#pragma warning restore CS0618 // Type or member is obsolete
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
