using UnityEngine;

public class PickableItem : MonoBehaviour
{
	private bool _enableAnimation = true;

	private void FixedUpdate()
	{
		if (_enableAnimation)
		{
			transform.Translate(0.0f, Mathf.Sin(Time.timeSinceLevelLoad) * 0.01f, 0.0f);
			transform.Rotate(Vector3.up, 1);
		}
	}

	public void Take()
	{
		_enableAnimation = false;
	}

	public void Drop()
	{
		_enableAnimation = true;
	}
}
