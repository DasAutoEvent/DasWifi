using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int Health = 15;

	Animator animator;


        // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {


	}

    public bool isDead()
    {
        return this.Health <= 0;
    }

    public void TakeDamage( int value )
    {
        this.Health -= value;

        // trigger TRASH here
        // trigger sound

        if (this.Health < 0)
        {
            // trigger death
        }

    }



}
