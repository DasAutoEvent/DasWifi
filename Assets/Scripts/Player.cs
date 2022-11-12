using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    public float CoefMove = 0.001f;
	float fCurrentAngle = 0.0f;
    SpriteRenderer spriteRenderer;
    Animator animator;
	internal void UpdateInner()
	{
	}




    public void setAngle(float fAng)
    {
		this.fCurrentAngle = fAng;
		Debug.Log(this.fCurrentAngle);
		this.animator.Play("Walk_" + this.getIndexFromAngle(this.fCurrentAngle).ToString(),-1);

		//if (fAng >= -90.0f &&		fAng <= 90.0f )
		//{
		//	this.spriteRenderer.flipX = true;
		//}
		//else
		//{
		//	this.spriteRenderer.flipX = false;
		//}


	}

    public void SetDirection(Vector2 dir)
    {
        this.transform.position += new Vector3( dir.x, dir.y) * CoefMove;

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
        
    }

    internal void TriggerFire()
    {
		this.animator.Play("Attack_" + this.getIndexFromAngle(this.fCurrentAngle).ToString());
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
			for (int i = 0; i <= 3; i++)
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
