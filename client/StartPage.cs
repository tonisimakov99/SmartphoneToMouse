using UnityEngine;
using System.Net;

public class StartPage : MonoBehaviour {

	private bool ipIsCorrect;
	private bool portIsCorrect;

	public void Start()
	{
		GameObject.Find("FailConnect").GetComponent<UnityEngine.UI.Text>().enabled = false;
	}

	public void IpTextBoxChangeEnded()
	{
		var value = GameObject.Find("InputIp").GetComponent<UnityEngine.UI.InputField>().text;
		if (IPAddress.TryParse(value, out Network.Ip))
			
			ipIsCorrect = true;
		else
		{
			ipIsCorrect = false;
			GameObject.Find("InputIp").GetComponent<UnityEngine.UI.InputField>().text = "";
		}	}

	public void StartApp()
	{
		GameObject.Find("FailConnect").GetComponent<UnityEngine.UI.Text>().enabled = false;
		if (ipIsCorrect)
		{
			if (Network.TryConnect())
				UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
			else
				GameObject.Find("FailConnect").GetComponent<UnityEngine.UI.Text>().enabled = true;
		}	}
}
