using UnityEngine;
using ByteMessagesFormat;

public class TouchScreen : MonoBehaviour
{
	private float touchPathLength;
	private float startDelayTime;
	private float stopDelayTime = 100;
	private float moveLengthTreshold = 1;
	private bool isLeftButtonHolded = false;
	private bool isDoubleTouch = false;
	// Update is called once per frame
	void Update()
	{
		HandleEscapeButton();

		if (Input.touchCount == 2)
		{
			HandleDoubleTouch();
		}
		else if (Input.touchCount == 1)
		{
			HandleTouch();
		}
		else if (Input.touchCount == 0)
		{
			
		}
	}

	private void HandleTouch()
	{
		var touch = Input.GetTouch(0);

		if (touch.phase == TouchPhase.Began)
			stopDelayTime = Time.timeSinceLevelLoad;

		if (!isLeftButtonHolded && (touchPathLength > moveLengthTreshold) && (stopDelayTime - startDelayTime < Parameters.timeTreshold))
		{
			Network.sender.Send(new Message((byte)Command.HoldLeftButton).Build());
			isLeftButtonHolded = true;
		}

		if (touch.phase == TouchPhase.Moved)
		{
			var deltaPosition = touch.deltaPosition;

			touchPathLength += Mathf.Sqrt(Mathf.Pow(deltaPosition.x, 2) + Mathf.Pow(deltaPosition.y, 2));

			Network.sender.Send(new Message((byte)Command.MoveCursor,
																(int)(deltaPosition.x * Parameters.MoveSensitivity),
			                                (int)(-1 * deltaPosition.y * Parameters.MoveSensitivity)).Build());
		}

		if (touch.phase == TouchPhase.Ended)
		{
			if ((!isDoubleTouch) && (touchPathLength < moveLengthTreshold))
				Network.sender.Send(new Message((byte)Command.LeftClick).Build());

			touchPathLength = 0;
			startDelayTime = Time.timeSinceLevelLoad;
			isDoubleTouch = false;

			if (isLeftButtonHolded)
			{
				Network.sender.Send(new Message((byte)Command.UnholdLeftButton).Build());
				isLeftButtonHolded = false;
			}
		}
	}

	private void HandleDoubleTouch()
	{
		isDoubleTouch = true;
		var touch1 = Input.GetTouch(0);
		var touch2 = Input.GetTouch(1);

		if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
		{
			var deltaPosition1 = touch1.deltaPosition;
			var deltaPosition2 = touch2.deltaPosition;
			var deltaY = (deltaPosition1.y + deltaPosition2.y) / 2;
			var deltaX = (deltaPosition1.x + deltaPosition2.x) / 2;

			touchPathLength += Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));

			if (Parameters.TouchScrollInverted)
			{
				deltaX = -1 * deltaX;
				deltaY = -1 * deltaY;
			}

			if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
				Network.sender.Send(new Message((byte)Command.HorizontalWheel, (int)(deltaX * Parameters.ScrollSensitivity)).Build());
			if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX))
				Network.sender.Send(new Message((byte)Command.Wheel, (int)(deltaY * Parameters.ScrollSensitivity)).Build());
		}

		if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
		{
			var movePorog = 10;
			if (touchPathLength < movePorog)
				Network.sender.Send(new Message((byte)Command.RightClick).Build());
			touchPathLength = 0;
		}	}

	private void HandleEscapeButton()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}	}
}
