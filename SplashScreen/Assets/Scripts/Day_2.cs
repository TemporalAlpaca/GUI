using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Day_2 : MonoBehaviour {

    const int TEXTNUM = 2;
    public GameObject dialogue;
    public GameObject square;
    public GameObject text;
    public GameObject movement;
    public GameObject ai;
    bool displayed = false;

    public Movement script;
    int t;
    string find;
    // Use this for initialization
    void Start()
    {
        t = 0;
        find = t.ToString();
        text = GameObject.Find(find);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && t <= TEXTNUM)
        {
            text.GetComponent<Text>().enabled = false;
            t++;
            if (t <= TEXTNUM)
            {
                find = t.ToString();
                text = GameObject.Find(find);
                text.GetComponent<Text>().enabled = true;
            }

        }

        if (t > TEXTNUM && displayed == false)
        {
            text.GetComponent<Text>().enabled = false;
            dialogue.GetComponent<SpriteRenderer>().enabled = false;
            square.GetComponent<SpriteRenderer>().enabled = false;
            movement.GetComponent<Movement>().enabled = true;
            ai.GetComponent<Soapy_AI>().enabled = true;
            //cover.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (script.getHits() >= 10 && displayed == false)
        {
            Debug.Log("You win!");
            dialogue = GameObject.Find("WinningDialogue");
            square = GameObject.Find("WinningSquare");
            text = GameObject.Find("WinningText");


            dialogue.GetComponent<SpriteRenderer>().enabled = true;
            square.GetComponent<SpriteRenderer>().enabled = true;
            text.GetComponent<Text>().enabled = true;

            GameObject.Find("WinningDialogue").GetComponent<SpriteRenderer>().enabled = true;
            displayed = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && displayed)
        {
            Debug.Log("next scene");
            Application.LoadLevel("Scenes/Day3_Opening");
        }

    }
}
