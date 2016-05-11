using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

    Rigidbody2D body;
    public float speed;
    float movetime;
    Vector2 movement;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        movetime = 60;
        movement = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update () {
        movetime--;

        
        if (movetime <= 0)
        {
            movement = new Vector2(Random.Range(-1, 2), Random.Range(-1,2)) * speed;
            movetime = 60;
        }
        body.MovePosition(body.position + movement * Time.deltaTime);


    }
}
