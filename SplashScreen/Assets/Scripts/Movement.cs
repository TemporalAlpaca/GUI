using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public Collider2D enemy;
    public float speed;
    public GameObject destroy;
                
    const double ATTACKTIME = .75;
    Rigidbody2D body;
    Animator animator;
    Vector2 last_direction;
    double time;
    BoxCollider2D temp;
    SpriteRenderer reallytemp;
    int hits;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        time = 0;
        hits = 0;

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
            else if (last_direction.y > 0)
            {
                HandleAttack("Up");
            }
            else if (last_direction.y < 0)
            {
                HandleAttack("Down");
            }

        }
        CancelHitboxes();

        if (hits >= 10)
            Debug.Log("You Win!");
    }

    void HandleAttack(string direction)
    {
        reallytemp = GameObject.Find(direction).GetComponent<SpriteRenderer>();
        temp = GameObject.Find(direction).GetComponent<BoxCollider2D>();
        temp.enabled = true;
        reallytemp.enabled = true;

        time = ATTACKTIME;
    }

    void CancelHitboxes()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            temp.enabled = false;
            reallytemp.enabled = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.Equals(enemy))
        {
            Debug.Log("Hit!");
            hits++;
            //play hit sound
            if(hits == 10)
                destroy.SetActive(false);

        }
    }

    public int getHits()
    {
        return hits;
    }

}
