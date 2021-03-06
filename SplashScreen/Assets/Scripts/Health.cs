﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    float health;
    Slider health_bar;
    public float speed;
    public Rigidbody2D bar;
    // Use this for initialization
    void Start()
    {
        health = 100;
        health_bar = GameObject.Find("HealthBar").GetComponent<Slider>();
        health_bar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        health_bar.value = health;
        //bar.MovePosition(bar.position + movement * Time.deltaTime);

        if(health <= 0)
        {
            Debug.Log("Game over");
            Application.LoadLevel("Scenes/game_over");
        }

    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float h)
    {
        health = h;
    }

    public void TakeDamage(float dam)
    {
        health -= dam;
    }
}
