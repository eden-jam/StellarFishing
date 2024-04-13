using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : Singleton<SceneStateManager>
{
	public enum SceneState
	{
		IntroState,
		ReadyState,
		GameState,
		OutroState
	}

	private Dictionary<SceneState, ISceneState> _sceneStates = null;

	private SceneState _currentSceneState = SceneState.IntroState;

	[SerializeField] private int _fishNeeded = 0;

	private int _fishCatched = 0;

	private void Start()
	{
		_sceneStates.Add(SceneState.IntroState, new IntroSceneState());
		_sceneStates.Add(SceneState.ReadyState, new ReadySceneState());
		_sceneStates.Add(SceneState.GameState, new GameSceneState());
		_sceneStates.Add(SceneState.OutroState, new OutroSceneState());

		FishingManager.Instance.OnFishEnded += OnFishingEnded;
	}

	public void OnFishingEnded(bool succeed)
	{
		if (succeed)
		{
			_fishCatched++;
		}
	}

	public void RequestNextState()
	{
		switch (_currentSceneState)
		{
			case SceneState.IntroState:
				{
					RequestState(SceneState.ReadyState);
				}
				break;
			case SceneState.ReadyState:
				{
					RequestState(SceneState.GameState);
				}
				break;
			case SceneState.GameState:
				{
					if (_fishCatched >= _fishNeeded)
					{
						RequestState(SceneState.OutroState);
					}
					else
					{
						RequestState(SceneState.ReadyState);
					}
				}
				break;
			case SceneState.OutroState:
				{
					GameManager.Instance.OnSceneEnd();
				}
				break;
		}
	}

	public void RequestState(SceneState sceneState)
	{
		_sceneStates[_currentSceneState].OnExitState();
		_currentSceneState = sceneState;
		_sceneStates[_currentSceneState].OnEnterState();
	}

}
