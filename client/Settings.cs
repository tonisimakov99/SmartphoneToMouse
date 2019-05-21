using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		GameObject.Find("MoveSensitivity").GetComponent<UnityEngine.UI.Slider>().value = Parameters.MoveSensitivity;
		GameObject.Find("ScrollSensitivity").GetComponent<UnityEngine.UI.Slider>().value = Parameters.ScrollSensitivity;
		GameObject.Find("InvertTouchScroll").GetComponent<UnityEngine.UI.Toggle>().isOn = Parameters.TouchScrollInverted;
		GameObject.Find("InvertTiltYAxis").GetComponent<UnityEngine.UI.Toggle>().isOn = Parameters.TiltYAxisInverted;
	}

	// Update is called once per frame
	void Update()
	{
		HandleEscapeButton();
	}

	public void MoveSensitivitySliderChanged()
	{
		var value = GameObject.Find("MoveSensitivity").GetComponent<UnityEngine.UI.Slider>().value;
		Parameters.MoveSensitivity = value;	}

	public void ScrollSensitivitySliderChanged()
	{
		var value = GameObject.Find("ScrollSensitivity").GetComponent<UnityEngine.UI.Slider>().value;
		Parameters.ScrollSensitivity = value;	}

	public void InvertTouchScrollChanged()
	{
		var inverted = GameObject.Find("InvertTouchScroll").GetComponent<UnityEngine.UI.Toggle>().isOn;
		Parameters.TouchScrollInverted = inverted;	}

	public void InvertTiltYAxisChanged()
	{
		var inverted = GameObject.Find("InvertTiltXAxis").GetComponent<UnityEngine.UI.Toggle>().isOn;
		Parameters.TiltYAxisInverted = inverted;	}

	private void HandleEscapeButton()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}	}
}
