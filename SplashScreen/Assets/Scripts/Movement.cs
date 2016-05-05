using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Rigidbody2D body;
    Animator animator;
    public float speed;
    Vector2 last_direction;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        
        if (movement != Vector2.zero)
        {
            last_direction = Vector2.zero;
            animator.SetBool("walking", true);
            animator.SetFloat("input_x", movement.x);
            animator.SetFloat("input_y", movement.y);
            last_direction = movement;
        }
        else
        {
            animator.SetBool("walking", false);
        }

        body.MovePosition(body.position + movement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");

            //Debug.Log("x");
            //Debug.Log(last_direction.x);
            //Debug.Log("y");
            //Debug.Log(last_direction.y);

            if (last_direction.x < 0)
            {
                HandleAttack("Left");
            }
            else if(last_direction.x > 0)
            {
                HandleAttack("Right");
            }
            if (last_direction.y > 0)
            {
                HandleAttack("Up");
            }
            else if (last_direction.y < 0)
            {
                HandleAttack("Down");
            }

        }
    }

    void HandleAttack(string direction)
    {
        GameObject.Find(direction).GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find(direction).GetComponent<BoxCollider2D>().enabled = true;


        //GameObject.Find(direction).GetComponent<SpriteRenderer>().enabled = false;
        //GameObject.Find(direction).GetComponent<BoxCollider2D>().enabled = false;
    }
}
