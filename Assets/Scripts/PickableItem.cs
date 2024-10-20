using UnityEngine;

public class PickableItem : MonoBehaviour
{
	private void FixedUpdate()
	{
		// Let it rotate slowly
		transform.Translate(0.0f, Mathf.Sin(Time.timeSinceLevelLoad) * 0.01f, 0.0f);
		transform.Rotate(Vector3.up, 1);
	}
}
