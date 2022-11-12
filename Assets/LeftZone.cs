using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftZone : MonoBehaviour
{



	BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        this.boxCollider = GetComponent<BoxCollider2D>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{

			// getting 

			//	Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//	mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
			//	transform.position = mousePosition;

			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null)
			{
				int dd = 23;
			}
		}
	}
}
