using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void LoadTouchScreen()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("TouchScreen");
	}

	public void LoadMouseCalibration()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MouseCalibration");
	}

	public void LoadMotionCapture()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MotionCapture");	}

	public void LoadSettings()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");	}
	public void LoadPresentation()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Presentation");	}
}
