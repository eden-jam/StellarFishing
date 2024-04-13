using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] private FishesCatalog _fishesCatalog = null;

	public FishesCatalog FishesCatalog { get => _fishesCatalog; }

	private void Start()
	{
		DontDestroyOnLoad(this);
	}
}
