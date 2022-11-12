using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class LeftZone : MonoBehaviour
{

	public GameObject ControllerPrefab;
	public GameObject PlayerPrefab;


	Controller Contoller = null;
	Player Player = null;


	bool isCapture = false;
	BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
		//Instantiate(this.ControllerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		//Instantiate(this.PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

		this.boxCollider = GetComponent<BoxCollider2D>();

		this.Contoller = this.ControllerPrefab.GetComponent<Controller>();
		this.Player = this.PlayerPrefab.GetComponent<Player>();

	}

    // Update is called once per frame
    void Update()
    {

		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null && hit.collider == boxCollider)
			{
				this.isCapture = true;

				// placing controller under the click
				this.Contoller.SetPosition(mousePos2D);

				//
				this.Contoller.SetVisible(true);

				this.Contoller.BeginTouch(mousePos2D);
			}
		}

		if (Input.GetMouseButton(0) && this.isCapture)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null)
			{
				this.Contoller.MoveTouch(mousePos2D);
				this.Player.setAngle(this.Contoller.getAngle());
				this.Player.SetDirection(this.Contoller.getDirection());
			}
			else
			{
				this.Contoller.EndTouch();
				this.Contoller.SetVisible(false);
				this.isCapture = false;
			}

		}
		if (Input.GetMouseButtonUp(0) && this.isCapture)
		{
			this.Contoller.EndTouch();
			this.Contoller.SetVisible(false);
			this.isCapture = false;
			//this.Contoller.GetComponent<Renderer>().enabled = false;
		}

		// constant update by dir
		this.Player.SetDirection(this.Contoller.getDirection());
	}
}
