using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UnityEngine;

public class Truck : MonoBehaviour
{
	private readonly ObservableCollection<PickableItem> _items = new();

	public Truck()
	{
		_items.CollectionChanged += OnItemPlaced;
	}

	public bool IsPlayerOnRange { get; private set; }

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<Player>(out _))
		{
			IsPlayerOnRange = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<Player>(out _))
		{
			IsPlayerOnRange = false;
		}
	}

	private void OnItemPlaced(object sender, NotifyCollectionChangedEventArgs e)
	{
		Debug.Log($"New item placed. Count = {_items.Count}");
	}

	public void Place(PickableItem item)
	{
		_items.Add(item);
	}
}
