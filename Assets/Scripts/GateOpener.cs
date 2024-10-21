using UnityEngine;

public class GateOpener : MonoBehaviour
{
	[SerializeField] private Transform _movingPart;

	private Vector3 _positionInClosedState;
	private Vector3 _positionInOpenedState;

	private void Start()
	{
		_positionInClosedState = transform.position;
		_positionInClosedState.y += 2.0f;

		_positionInOpenedState = _positionInClosedState;
		_positionInOpenedState.y += 4.0f;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.IsPlayer())
		{
			Open();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.IsPlayer())
		{
			Close();
		}
	}

	public void Close()
	{
		_movingPart.transform.position = _positionInClosedState;
	}

	public void Open()
	{
		_movingPart.transform.position = _positionInOpenedState;
	}
}
