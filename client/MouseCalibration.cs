using UnityEngine;

public class MouseCalibration : MonoBehaviour
{

	private Vector3 sumAcceleration;

	private float count = 1;
	private bool isStarted = false;

	// Update is called once per frame
	void Update()
	{
		HandleEscapeButton();
		if (isStarted)
			CalculateAcceleration();
		ShowAcceleration();
	}

	private void CalculateAcceleration()
	{
		sumAcceleration += Input.acceleration;
		count++;	}

	private void ShowAcceleration()
	{
		GameObject.Find("X").GetComponent<UnityEngine.UI.Text>().text = "X = " + ((sumAcceleration.x / count)).ToString();
		GameObject.Find("Y").GetComponent<UnityEngine.UI.Text>().text = "Y = " + ((sumAcceleration.y / count)).ToString();
		GameObject.Find("Z").GetComponent<UnityEngine.UI.Text>().text = "Z = " + ((sumAcceleration.z / count)).ToString();	}

	public void StartCalibration()
	{
		isStarted = true;
	}

	public void SetCalibration()
	{
		Calibration.StableCondition = sumAcceleration / count;
		UnityEngine.SceneManagement.SceneManager.LoadScene("TiltManipulator");
	}

	private void HandleEscapeButton()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}	}
}
