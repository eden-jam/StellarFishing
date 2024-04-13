using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] private FishesCatalog _fishesCatalog = null;

	public FishesCatalog FishesCatalog { get => _fishesCatalog; }

	[SerializeField] private string _sceneStart = null;
	[SerializeField] private string _sceneMap = null;
	[SerializeField] private string _sceneEnd = null;

	[SerializeField] private string _scenePurple = null;
	[SerializeField] private string _sceneGreen = null;
	[SerializeField] private string _scenePink = null;

	private void Start()
	{
		DontDestroyOnLoad(this);
	}

	private void LoadMap()
	{
		SceneManager.LoadScene(_sceneMap);
	}

	private void LoadScene(int environnementType)
	{
		switch (environnementType)
		{
			case 0:
				{
					SceneManager.LoadScene(_scenePurple);
				}
				break;
			case 1:
				{
					SceneManager.LoadScene(_sceneGreen);
				}
				break;
			case 2:
				{
					SceneManager.LoadScene(_scenePink);
				}
				break;
		}
	}

	public void OnSceneSelected(int environnementType)
	{
		LoadScene(environnementType);
	}

	public void OnSceneEnd()
	{
		if (true) // TODO
		{
			LoadMap();
		}
		else
		{
			SceneManager.LoadScene(_sceneMap);
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(_sceneStart);
	}
}
