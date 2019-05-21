using ByteMessagesFormat;
using UnityEngine;

public class Presentation : MonoBehaviour
{

	void Update()
	{
		HandleEscapeButton();
	}
	public void Next()
	{
		Network.sender.Send(new Message((byte)Command.KB_PushRightButton).Build());
	}

	public void Previous()
	{
		Network.sender.Send(new Message((byte)Command.KB_PushLeftButton).Build());	}

	private void HandleEscapeButton()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}	}
}
