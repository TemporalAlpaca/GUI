using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 1.0f;
    //public Animator WalkRight;
    //public Animation WalkUp;

    void Update()
    {
        var initial = transform.position;
        var end = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            end = transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            end = transform.position += Vector3.right * speed * Time.deltaTime;
            //WalkRight.enabled = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            end = transform.position += Vector3.up * speed * Time.deltaTime;
           // WalkUp.enabled = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            end = transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if(initial == end)
        {
            //WalkRight.enabled = false;
        }
    }
}
