using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public static class Calibration
{
	public static Vector3 StableCondition;
}

public static class Move
{
	public static float treshold = 0.1f;
}

public static class Parameters
{
	public static float MoveSensitivity = 1;
	public static float ScrollSensitivity = 1;
	public static bool TouchScrollInverted = false;
	public static bool TiltYAxisInverted = false;
	public static float TimeMotion = 1;
	public static float timeTreshold = 0.1f;
}

public enum Command
{
	MoveCursor = 1,
	HoldLeftButton,
	UnholdLeftButton,
	HoldRightButton,
	UnholdRightButton,
	Wheel,
	HorizontalWheel,
	LeftClick,
	RightClick,
	KB_PushLeftButton,
	KB_PushRightButton
}
