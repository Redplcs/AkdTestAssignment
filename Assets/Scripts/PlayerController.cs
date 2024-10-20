using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;
	[SerializeField] private float _speed = 1.0f;

	private void FixedUpdate()
	{
		var wishDir = new Vector3(
			Input.GetAxis("Horizontal"),
			0,
			Input.GetAxis("Vertical"));

		_characterController.SimpleMove(_speed * wishDir);
	}
}
