using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightZone : MonoBehaviour
{
	public GameObject PlayerPrefab;
	Player Player;

	// Start is called before the first frame update
	BoxCollider2D boxCollider;
	void Start()
    {
		this.boxCollider = GetComponent<BoxCollider2D>();
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
				Player.TriggerFire();
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Player.TriggerFire();
		}
    }
}
