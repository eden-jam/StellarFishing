using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	private int _lastMapSelected = -1;

	[SerializeField] private FishesCatalog _fishesCatalog = null;

	public FishesCatalog FishesCatalog { get => _fishesCatalog; }

	[SerializeField] private string _sceneStart = null;
	[SerializeField] private string _sceneMap = null;
	[SerializeField] private string _sceneEnd = null;

	[SerializeField] private string _scenePurple = null;
	[SerializeField] private string _sceneGreen = null;
	[SerializeField] private string _scenePink = null;

    public int LastMapSelected { get => _lastMapSelected; }

	[SerializeField] private int LastMapIndex = 8;

	private void Start()
	{
		DontDestroyOnLoad(this);
	}

	private void LoadMap()
	{
		SceneManager.LoadScene(_sceneMap);
	}

	private void LoadScene(EnvironmentType environnementType)
	{
		switch (environnementType)
		{
			case EnvironmentType.Purlple:
				{
					SceneManager.LoadScene(_scenePurple);
				}
				break;
			case EnvironmentType.Green:
				{
					SceneManager.LoadScene(_sceneGreen);
				}
				break;
			case EnvironmentType.Pink:
				{
					SceneManager.LoadScene(_scenePink);
				}
				break;
		}
	}

	public void OnSceneSelected(EnvironmentType environnementType, int index)
	{
		_lastMapSelected = index;
		LoadScene(environnementType);
	}

	public void OnSceneEnd()
	{
		if (_lastMapSelected < LastMapIndex) // TODO
		{
			LoadMap();
		}
		else
		{
			SceneManager.LoadScene(_sceneEnd);
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(_sceneStart);
	}
}
