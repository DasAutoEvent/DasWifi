using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	class FireLife
	{
		public GameObject Go { get; set; }
		public float LifreTrime { get; set; }
		public float PauseTime { get; set; } = 0.3f;

		public int State { get; set; } = 0;

		public void Update(float dt)
		{
			if (State == 0)
			{
				PauseTime -= dt;

			}
			if (State == 1)
			{
				this.LifreTrime -= dt;
			}
		}
	}



	public GameObject FireVFX;
	public int EnemiesToKill = 30;
	public float LoveRadius = 5.0f;




	List<FireLife> fireLives = new List<FireLife>();
	uint WalkAnimId = 1;
	public float CoefMove = 0.001f;
	float fCurrentAngle = 0.0f;
	SpriteRenderer spriteRenderer;
	Animator animator;

	public void setAngle(float fAng)
    {
		this.fCurrentAngle = fAng;

		uint value = this.getIndexFromAngle(this.fCurrentAngle);
		if (value != this.WalkAnimId)
		{
			this.animator.Play("Walk_" + this.getIndexFromAngle(this.fCurrentAngle).ToString(),-1);
			this.WalkAnimId = value;
		}
	}

    public void SetDirection(Vector2 dir)
    {
        this.transform.position += new Vector3( dir.x, dir.y) * CoefMove;

		Vector3 camPos = Camera.main.transform.position;
		camPos.x = this.transform.position.x;
		camPos.y = this.transform.position.y;
		Camera.main.transform.position = camPos;


	}

        // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		foreach( FireLife fireLife in fireLives)
		{
			fireLife.Update(Time.deltaTime);
			if (fireLife.State ==0 && fireLife.PauseTime < 0.0f)
			{
				fireLife.State = 1;
				GameObject go = Instantiate(this.FireVFX, this.transform.position, Quaternion.identity);
				fireLife.Go = go;
				this.BoundEnemies();
			}

			if (fireLife.LifreTrime < 0.0f)
			{
				Destroy(fireLife.Go);
			}
		}
    }

	private void BoundEnemies()
	{
		
	}

    internal void TriggerFire()
    {
		this.animator.Play("Attack_" + this.WalkAnimId.ToString());

		FireLife fl = new FireLife();
		fl.LifreTrime = 1.0f;
		fireLives.Add(fl);
	}


	private uint getIndexFromAngle(float fAngle)
	{
		if (fAngle > 0.0f)
		{
			// top
			// [  0 - 22.5 ] = 7
			// [ 22.5 - 67.5 ] = 6
			// [ 67.5 - 112.5 ] = 5
			// [ 112.5 - 157.5 ] = 4
			// [ 157.5 - 180 ] = 3

			float fStart = 0.0f;
			float fTop = 22.5f;
			for (uint i = 7; i >= 3; i--)
			{
				if (fAngle >= fStart && fAngle <= fTop)
				{
					return i;
				}
				fStart = fTop;
				fTop += 45.0f;
			}
		}
		else
		{
			fAngle = -fAngle;
			uint[] inds = { 7, 8, 1, 2, 3 };
			// bottom
			// [  0 - 22.5 ] = 7
			// [ 22.5 - 67.5 ] = 8
			// [ 67.5 - 112.5 ] = 1
			// [ 112.5 - 157.5 ] = 2
			// [ 157.5 - 180 ] = 3

			float fStart = 0.0f;
			float fTop = 22.5f;
			for (int i = 0; i < 5; i++)
			{
				if (fAngle >= fStart && fAngle <= fTop)
				{
					return inds[i];
				}
				fStart = fTop;
				fTop += 45.0f;
			}
		}
		return 1;
	}
}
