using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered area");
        //Application.LoadLevel("Scenes/Coliseum");
    }
}
