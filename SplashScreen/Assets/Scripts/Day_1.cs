using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Day_1 : MonoBehaviour {

    const int TEXTNUM = 2;
    public GameObject dialogue;
    public GameObject square;
    public GameObject text;
    public GameObject movement;
    public GameObject ai;
    int t;
    string find;
    // Use this for initialization
    void Start()
    {
        t = 0;
        find = t.ToString();
        text = GameObject.Find(find);
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

        if (t > TEXTNUM)
        {
            text.GetComponent<Text>().enabled = false;
            dialogue.GetComponent<SpriteRenderer>().enabled = false;
            square.GetComponent<SpriteRenderer>().enabled = false;
            movement.GetComponent<Movement>().enabled = true;
            ai.GetComponent<AIMovement>().enabled = true;
            //cover.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
