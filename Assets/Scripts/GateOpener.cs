using System;
using UnityEngine;

public class GateOpener : MonoBehaviour
{
	[SerializeField] private Transform _movingPart;
	[SerializeField] private AnimationCurve _animation;

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<Player>(out _))
		{
			Open();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<Player>(out _))
		{
			Close();
		}
	}

	public void Close()
	{
		throw new NotImplementedException();
	}

	public void Open()
	{
		throw new NotImplementedException();
	}
}
