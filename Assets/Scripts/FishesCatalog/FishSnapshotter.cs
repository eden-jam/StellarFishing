using UnityEngine;

public sealed class FishSnapshotter : Singleton<FishSnapshotter>
{
	#region Fields
	[SerializeField] private Transform _fishAnchor = null;

	private GameObject _currentFish = null;
	private Quaternion _startRotation = Quaternion.identity;
	#endregion Fields

	#region Methods
	private void Start()
	{
		_startRotation = _fishAnchor.rotation;
	}

	public void RenderFish(FishDescription description)
	{
		if (_currentFish != null)
		{
			GameObject.Destroy(_currentFish);
		}

		_currentFish = FishSpawner.SpawnFish(description, _fishAnchor);
		_fishAnchor.parent.rotation = _startRotation;
	}
	#endregion Methods
}