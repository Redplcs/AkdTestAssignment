using UnityEngine;

public class TextureTiler : MonoBehaviour
{
	[SerializeField] private float _multiplier;

	private void Awake()
	{
		var objectScale = new Vector2(transform.localScale.x, transform.localScale.y);

		var renderer = GetComponent<Renderer>();
		renderer.material.SetTextureScale("_MainTex", objectScale * _multiplier);
	}
}
