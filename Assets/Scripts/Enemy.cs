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


	public List<AudioClip> TakeDamageSounds;
	public List<AudioClip> DeathSounds;

	public string DisapAnim;

	AudioSource audioSource;
	Animator animator;

	public GameObject Trash;
	public List<GameObject> Ugar;

        // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
		this.audioSource = GetComponent<AudioSource>();
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

		int valueDam = Random.Range(0, this.DeathSounds.Count);
		this.audioSource.clip = this.DeathSounds[valueDam];


		// trigger TRASH here
		// trigger sound

		if (this.Health < 0)
		{
			// trigger death

			valueDam = Random.Range(0, this.TakeDamageSounds.Count);
			this.audioSource.clip = this.TakeDamageSounds[valueDam];
			this.animator.Play(DisapAnim);
		}
		else
		{
			if (this.Ugar.Count != 0)
			{

				// UGAR here
				int randCount = Random.Range(5, 10);
				for (int l = 0; l < randCount; ++l)
				{

					Vector3 curPos = this.transform.position;
					curPos.x += Random.Range(-0.8f, 0.8f);
					curPos.y += Random.Range(-0.8f, 0.8f);

					int randValue = Random.Range(0, this.Ugar.Count);
					GameObject go = Instantiate(this.Ugar[randValue], this.Trash.transform);
					go.transform.position = curPos;

				}
			}



			this.audioSource.Play();
		}
	}



}
