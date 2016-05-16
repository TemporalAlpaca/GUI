using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

    public Rigidbody2D character;
    float strength = 5;
    float time;
    bool done;

    void Start()
    {
        time = 20;
        done = false;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0 && !done)
        {
            done = true;
            DestroyObject(GameObject.Find("Bubble(Clone)"));
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("hit with bubble");

        if (col.name == "Character")
        {
            Destroy(gameObject);

            Debug.Log("Damage!");
            //hit_sound.Play();

            character.GetComponent<Health>().TakeDamage(strength);

        }
    }
}
