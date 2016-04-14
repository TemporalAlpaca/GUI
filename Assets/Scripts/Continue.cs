using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Continue : MonoBehaviour {

    public GameObject button, box, border, text;
    public GameObject Freedom, Baby;
    public Text freedom, baby;
    public Image button1, button2;

    void Start()
    {
        button = GameObject.Find("Intro button");
        box = GameObject.Find("Intro square");
        border = GameObject.Find("Intro Dialogue");
        text = GameObject.Find("Intro message");
    }

    public void onClick()
    {
        button.SetActive(false);
        box.SetActive(false);
        border.SetActive(false);
        text.SetActive(false);
        freedom.enabled = true;
        baby.enabled = true;
        button1.enabled = true;
        button2.enabled = true;
    }
}
