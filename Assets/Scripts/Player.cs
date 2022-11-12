using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float CoefMove = 0.001f;
    SpriteRenderer spriteRenderer;
	internal void UpdateInner()
	{
	}

    public void setAngle(float fAng)
    {
		if (fAng >= -90.0f && fAng <= 90.0f )
		{
			this.spriteRenderer.flipX = true;
		}
		else
		{
			this.spriteRenderer.flipX = false;
		}
	}

    public void SetDirection(Vector2 dir)
    {
        this.transform.position += new Vector3( dir.x, dir.y) * CoefMove;

    }

        // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();   

	}

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void TriggerFire()
    {
        Debug.Log("HEART FIRE!!");
    }
}
