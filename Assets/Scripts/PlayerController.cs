using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private CharacterController _characterController;
	[SerializeField] private Transform _view;
	[SerializeField] private float _speed = 1.0f;
	[SerializeField] private float _sensitivity = 1.0f;

	private Vector2 _wishDir;
	private Vector2 _deltaMouse;
	private bool _interactPressed;
	private bool _interactHolding;

	private void FixedUpdate()
	{
		ProcessMovement();
		ProcessPicking();
	}

	private void Update()
	{
		UpdateUserInput();
		ProcessViewing();
	}

	private void ProcessPicking()
	{
		if (_interactPressed && !_interactHolding)
		{
			if (_player.IsHolding)
			{
				_player.TryPutItem();
			}
			else
			{
				_player.TryTakeClosestItem();
			}
		}

		_interactHolding = _interactPressed;
	}

	private void ProcessMovement()
	{
		var worldWishDir = new Vector3(_wishDir.x, 0, _wishDir.y);
		worldWishDir.Normalize();

		var deltaRot = worldWishDir * _speed;
		var moveDir = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * deltaRot;

		_characterController.SimpleMove(moveDir);
	}

	private void ProcessViewing()
	{
		var deltaRot = _deltaMouse * _sensitivity;
		deltaRot.y = -deltaRot.y;

		transform.Rotate(Vector3.up, deltaRot.x);
		_view.Rotate(Vector3.right, deltaRot.y);
	}

	private void UpdateUserInput()
	{
		_wishDir = new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical"));

		_deltaMouse = new Vector2(
			Input.GetAxis("Mouse X"),
			Input.GetAxis("Mouse Y"));

		_interactPressed = Input.GetAxis("Jump") > 0;
	}
}
