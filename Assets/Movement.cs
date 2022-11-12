using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
	CircleCollider2D CircleCollider2D;
	GameObject Inner;

	bool isCaptured = false;
	Vector2 CapturePos;
	// Start is called before the first frame update
	void Start()
    {
        this.CircleCollider2D = GetComponent<CircleCollider2D>();
		this.Inner = this.transform.Find("Inner").gameObject;
	}

	private void UpdateInner()
	{
		// start of event
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
				this.isCaptured = true;
				this.CapturePos = mousePos2D;
				this.Inner.transform.localPosition = new Vector3(0.0f, 0.0f);
			}
		}
		if (Input.GetMouseButton(0) && this.isCaptured)
		{
			// update trasform for inner
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider == null)
			{
				this.isCaptured = false;
				this.Inner.transform.localPosition = new Vector3(0.0f, 0.0f);
				return;
			}

			Vector2 Diff = (mousePos2D - this.CapturePos) / this.transform.localScale.x;
			this.Inner.transform.localPosition += new Vector3(Diff.x, Diff.y);
			this.CapturePos = mousePos2D;
		}

		if (Input.GetMouseButtonUp(0) && this.isCaptured)
		{
			//return back inner
			// release capture
			this.isCaptured = false;
			this.Inner.transform.localPosition = new Vector3(0.0f, 0.0f);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.touchCount != 0)
		{
			Touch touch = Input.GetTouch(0);
			Debug.Log(touch.azimuthAngle);
		}

		this.UpdateInner();

	}
}
