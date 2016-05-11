using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {

    public GameObject character;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (character.transform.position.y < -7)
        {
            Debug.Log("Entered area");
            Application.LoadLevel("Scenes/Day1");
        }
    }
}
