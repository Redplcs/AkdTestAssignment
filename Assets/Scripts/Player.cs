using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Player : MonoBehaviour
{
	[SerializeField] private Transform _pickedItemOrigin;
	[SerializeField] private float _rangeToPick;

	private PickableItem[] _items;

	public bool IsHolding { get; private set; }

	private void Start()
	{
		_items = FindObjectsByType<PickableItem>(FindObjectsSortMode.None);
	}

	private void FixedUpdate()
	{
		foreach (var item in _items)
		{
			var distance = (item.transform.position - transform.position).magnitude;

			if (distance < _rangeToPick)
			{
				Take(item);
			}
		}
	}

	public void Take(PickableItem item)
	{
		item.Take();
		item.transform.position = _pickedItemOrigin.position;
	}

	public bool TryTakeClosestItem()
	{
		Debug.Log("Item took!");
		IsHolding = true;
		return true;
	}

	public bool TryPutItem()
	{
		Debug.Log("Item placed!");
		IsHolding = false;
		return true;
	}
}
