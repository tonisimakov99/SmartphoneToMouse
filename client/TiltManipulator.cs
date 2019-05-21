using UnityEngine;
using ByteMessagesFormat;
public class TiltManipulator : MonoBehaviour
{
	private float speed;
	// Update is called once per frame
	void Update()
	{
		HandleEscapeButton();
		HandleMove();
		if (Input.touchCount > 0)
			HandleScroll();
	}

	private void HandleMove()
	{
		var k = 10;
		var move = Input.acceleration - Calibration.StableCondition;
		if (Parameters.TiltYAxisInverted)
			move.y *= -1;
		if (Mathf.Abs(move.x) > Move.treshold || Mathf.Abs(move.y) > Move.treshold)
		{
			Network.sender.Send(new Message((byte)Command.MoveCursor,
											(int)(move.x * Parameters.MoveSensitivity * k),
											(int)(move.y * Parameters.MoveSensitivity * k)).Build());
		}
	}

	public void MouseButtonLeft()
	{
		Network.sender.Send(new Message((byte)Command.LeftClick).Build());
	}

	public void MouseButtonRight()
	{
		Network.sender.Send(new Message((byte)Command.RightClick).Build());
	}

	public void HandleScroll()
	{
		var touch = Input.GetTouch(0);
		var ray = Camera.main.ScreenPointToRay(touch.position);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (hit.transform.name == "Scroll")
			{
				var k = 10;

				if (touch.deltaPosition.x > Move.treshold)
				{
					Network.sender.Send(new Message((byte)Command.Wheel, (int)(touch.deltaPosition.y * Parameters.ScrollSensitivity * k)).Build());
				}
			}
		}
	}

	private void HandleEscapeButton()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}
	}

}
