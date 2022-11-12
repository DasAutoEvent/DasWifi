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
	// Start is called before the first frame update

	void Start()
    {
        
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
		}

		if (fTimeToShowPart2 <= 0)
		{
			// TO DO TWO
			fTimeToShowPart2 = 9999999.0f;
		}

		if (fTimeToShowPart3 <= 0)
		{
			// TO DO THREE
			fTimeToShowPart3 = 9999999.0f;
		}

		if (fTimeToShowLoading <= 0)
		{
			SceneManager.LoadScene("SampleScene");
		}

	}
}
