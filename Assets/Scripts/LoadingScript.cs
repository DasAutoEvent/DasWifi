using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

    public float fTimeToShowLoading = 30.0f;
	public float fTimeToShowPart1 = 5.0f;
	public float fTimeToShowPart2 = 15.0f;
	public float fTimeToShowPart3 = 25.0f;

	public GameObject ObjPart1;
	public GameObject ObjPart2;
	public GameObject ObjPart3;
	// Start is called before the first frame update

	void Start()
    {
		this.ObjPart1.GetComponent<Renderer>().enabled = false;
		this.ObjPart2.GetComponent<Renderer>().enabled = false;
		this.ObjPart3.GetComponent<Renderer>().enabled = false;

	}

    // Update is called once per frame
    void Update()
    {
        float fDelta = Time.deltaTime;
        this.fTimeToShowLoading -= fDelta;
		this.fTimeToShowPart1 -= fDelta;
		this.fTimeToShowPart2 -= fDelta;
		this.fTimeToShowPart3 -= fDelta;

		if (fTimeToShowPart1 <= 0)
		{
			// TO DO ONE
			fTimeToShowPart1 = 9999999.0f;
			this.ObjPart1.GetComponent<Animator>().Play("part1", -1);
			this.ObjPart1.GetComponent<Renderer>().enabled = true;
		}

		if (fTimeToShowPart2 <= 0)
		{
			// TO DO TWO
			fTimeToShowPart2 = 9999999.0f;
			this.ObjPart2.GetComponent<Animator>().Play("part2", -1);
			this.ObjPart2.GetComponent<Renderer>().enabled = true;
		}

		if (fTimeToShowPart3 <= 0)
		{
			// TO DO THREE
			fTimeToShowPart3 = 9999999.0f;
			this.ObjPart3.GetComponent<Animator>().Play("part3", -1);
			this.ObjPart3.GetComponent<Renderer>().enabled = true;
		}

		if (fTimeToShowLoading <= 0)
		{
			SceneManager.LoadScene("SampleScene");

		}

	}
}
