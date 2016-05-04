using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Rigidbody2D body;
    Animator animator;
    public float speed;
    string direction;

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
            animator.SetBool("walking", true);
            animator.SetFloat("input_x", movement.x);
            animator.SetFloat("input_y", movement.y);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        body.MovePosition(body.position + movement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }

    void HandleAttack()
    {
        
    }
}
