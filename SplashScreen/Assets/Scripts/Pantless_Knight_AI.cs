using UnityEngine;
using System.Collections;

public class Pantless_Knight_AI : MonoBehaviour {

    const double ATTACKTIME = .75;
    double hitboxtime;

    Rigidbody2D body;
    public float speed;
    float movetime;
    float attacktime;
    Vector2 movement;
    GameObject hitbox;
    SpriteRenderer hitbox_sprite;
    BoxCollider2D hitbox_collider;
    public Collider2D character;
    public Animator animator;
    public float strength;

    // Use this for initialization
    void Start () {
        hitboxtime = 0;
        hitbox = GameObject.Find("PantslessHitbox");
        hitbox_sprite = hitbox.GetComponent<SpriteRenderer>();
        hitbox_collider = hitbox.GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        movetime = 60;
        attacktime = 180;
        movement = new Vector2(0, 0);

        animator.SetBool("Walking", true);
    }

    // Update is called once per frame
    void Update () {
        movetime--;
        attacktime--;
        
        if (movetime <= 0) //handles movement
        {
            movement = new Vector2(Random.Range(-1, 2), Random.Range(-1,2)) * speed;
            movetime = 60;
        }

        if(attacktime <= 0) //handles attacks
        {
            animator.SetTrigger("Attack");

            //attack animation
            hitbox_collider.enabled = true;
            hitbox_sprite.enabled = true;
            hitboxtime = ATTACKTIME;
            attacktime = 180;
        }
        body.MovePosition(body.position + movement * Time.deltaTime);

        CancelHitboxes();
    }

    void CancelHitboxes()
    {
        hitboxtime -= Time.deltaTime;

        if (hitboxtime <= 0)
        {
            hitbox_collider.enabled = false;
            hitbox_sprite.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.Equals(character))
        {
            Debug.Log("Damage!");
            //hit_sound.Play();

            character.GetComponent<Health>().TakeDamage(strength);

        }
    }
}
