using System.Collections.Generic;
using UnityEngine;

public class SceneStateManager : Singleton<SceneStateManager>
{
	public enum SceneState
	{
		IntroState,
		ReadyState,
		GameState,
		OutroState
	}

	[SerializeField] private int _fishNeeded = 0;

	private Dictionary<SceneState, ISceneState> _sceneStates = null;

	private SceneState _currentSceneState = SceneState.ReadyState;

	private int _fishCatched = 0;

	private void Start()
	{
		InputManager.Instance.SetCursorState(true);
		_sceneStates = new Dictionary<SceneState, ISceneState>
		{
			{ SceneState.ReadyState, new ReadySceneState() },
			{ SceneState.GameState, new GameSceneState() },
			{ SceneState.OutroState, new OutroSceneState() }
		};

		FishingManager.Instance.OnFishEnded += OnFishingEnded;
	}

	private void OnDestroy()
	{
		InputManager.Instance.SetCursorState(false);
	}

	public void OnFishingEnded(bool succeed)
	{
		if (succeed)
		{
			_fishCatched++;
		}
		RequestNextState();
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

	private void Update()
	{
		_sceneStates[_currentSceneState].Update();
	}
}
