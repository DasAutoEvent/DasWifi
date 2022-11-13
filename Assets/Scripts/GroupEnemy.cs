using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemy : MonoBehaviour
{
    public float fAmpX = 2.0f;
	public float fAmpY = 2.0f;

    public float fSpeed = 2.0f;
    float fRadValue = 0.0f;
    Vector3 Position;
	// Start is called before the first frame update
	void Start()
    {
        this.Position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.fRadValue += Time.deltaTime * this.fSpeed;

        Vector3 delta = new Vector3();
        delta.x = this.fAmpX * Mathf.Sin(this.fRadValue);
		delta.y = this.fAmpY * Mathf.Sin(2 *this.fRadValue);
		delta.z = 0;
        this.transform.position = this.Position + delta;

	}
}
