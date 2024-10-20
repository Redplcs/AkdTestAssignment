using UnityEngine;

public static class ColliderExtensions
{
	public static bool IsPlayer(this Collider collider)
	{
		return collider.TryGetComponent<Player>(out _);
	}
}