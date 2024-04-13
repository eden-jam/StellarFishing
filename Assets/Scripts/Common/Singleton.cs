using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	#region
	protected static T _instance;
	public static T Instance => _instance;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
		}

		_instance = (T)this;
	}
	#endregion
}