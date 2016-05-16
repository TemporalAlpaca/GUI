using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Soapy_AI : MonoBehaviour {

    const double ATTACKTIME = .75;
    double hitboxtime;

    Rigidbody2D body;
    public float speed;
    float movetime;
    float attacktime;
    Vector2 movement;
    GameObject hitbox;
    BoxCollider2D hitbox_collider;
    public Collider2D character;
    public Animator animator;
    public float strength;

    public GameObject bubble;
    GameObject clone;


    // Use this for initialization
    void Start()
    {
        hitboxtime = 0;
        hitbox = GameObject.Find("Bubble");
        //hitbox_sprite = hitbox.GetComponent<SpriteRenderer>();
        hitbox_collider = hitbox.GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        movetime = 60;
        attacktime = 180;
        movement = new Vector2(0, 0);

        animator.SetBool("Walking", true);

    }

    // Update is called once per frame
    void Update()
    {
        movetime--;
        attacktime--;

        if (movetime <= 0) //handles movement
        {
            movement = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * speed;
            movetime = 60;
        }

        if (attacktime <= 0) //handles attacks
        {
            
            clone = (Instantiate(bubble, transform.position, transform.rotation)) as GameObject;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), clone.GetComponent<Collider2D>(), true);

            Vector2 force = character.GetComponent<Movement>().getPos() - (Vector2)transform.position;
            clone.GetComponent<Rigidbody2D>().AddForce(force * 35);
            attacktime = 50;
            hitboxtime = 15;
        }
        body.MovePosition(body.position + movement * Time.deltaTime);

        //CancelHitboxes();
    }

    void CancelHitboxes()
    {
        hitboxtime -= Time.deltaTime;

        if (hitboxtime <= 0)
        {
           // Destroy(clone.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("hit with bubble");
        if (col.Equals(character))
        {
            Debug.Log("Damage!");
            //hit_sound.Play();

            character.GetComponent<Health>().TakeDamage(strength);

        }
    }
}
