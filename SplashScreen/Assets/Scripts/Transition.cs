using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {
    public string scene;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Character")
        {
            Debug.Log("Entered area");
            Application.LoadLevel(scene);
        }
    }
}
