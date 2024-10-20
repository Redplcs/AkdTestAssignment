using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Player : MonoBehaviour
{
	[SerializeField] private Transform _pickedItemOrigin;
	[SerializeField] private float _pickingRange;

	private PickableItem _pickedItem;

	public bool IsHolding => _pickedItem != null;

	private void FixedUpdate()
	{
		if (IsHolding)
		{
			_pickedItem.transform.position = _pickedItemOrigin.position;
		}
	}

	public bool TryTakeClosestItem()
	{
		foreach (var item in FindObjectsByType<PickableItem>(FindObjectsSortMode.None))
		{
			var distance = (item.transform.position - transform.position).magnitude;

			if (distance < _pickingRange)
			{
				item.Take();
				_pickedItem = item;
				return true;
			}
		}

		return false;
	}

	public bool TryPutItem()
	{
		_pickedItem = null;
		return true;
	}
}
