using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private CharacterController _characterController;
	[SerializeField] private float _speed = 1.0f;

	private Vector3 _velocity;

	private Vector3 _wishDir;

	private void FixedUpdate()
	{
		_velocity = _wishDir * _speed;

		// Process movement
		_characterController.SimpleMove(_velocity);
	}

	// Update wish move direction and rotation each tick
	private void Update()
	{
		_wishDir = new Vector3(
			Input.GetAxis("Horizontal"),
			0,
			Input.GetAxis("Vertical"));
	}
}
