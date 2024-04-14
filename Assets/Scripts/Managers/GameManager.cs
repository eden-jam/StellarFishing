using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	private int _lastMapSelected = -1;
	private EnvironmentType _lastEnvironmentType = EnvironmentType.None;

	[SerializeField] private FishesCatalog _fishesCatalog = null;
	[SerializeField] private NarrationCatalog _narrationCatalog = null;

	[SerializeField] private string _sceneStart = null;
	[SerializeField] private string _sceneMap = null;
	[SerializeField] private string _sceneNarration = null;
	[SerializeField] private string _sceneEnd = null;

	[SerializeField] private string _scenePurple = null;
	[SerializeField] private string _sceneGreen = null;
	[SerializeField] private string _scenePink = null;

	[SerializeField] private int _lastMapIndex = 8;

	[SerializeField] private List<FishDescription> _fishesFished = new List<FishDescription>();

	public int LastMapSelected { get => _lastMapSelected; }

	public FishesCatalog FishesCatalog { get => _fishesCatalog; }
	public NarrationCatalog NarrationCatalog { get => _narrationCatalog; }
	public List<FishDescription> FishesFished { get => _fishesFished; }

	private void Start()
	{
		DontDestroyOnLoad(this);
	}

	private void LoadMap()
	{
		SceneManager.LoadScene(_sceneMap);
	}

	private void LoadNarration()
	{
		SceneManager.LoadScene(_sceneNarration);
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
		_lastEnvironmentType = environnementType;
		LoadScene(_lastEnvironmentType);
	}

	public void OnSceneEnd()
	{
		//if (_narrationCatalog.FindNarration(LastMapSelected) != null)
		//{
		//	LoadNarration();
		//}
		//else
		{
			OnNarrationEnded();
		}
	}

	public void OnNarrationEnded()
	{
		if (_lastMapSelected < _lastMapIndex) // TODO
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
