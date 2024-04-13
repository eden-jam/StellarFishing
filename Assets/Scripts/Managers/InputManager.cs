using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
	[SerializeField] private InputActionReference _input = null;

	public bool _readThisFrame = false;

	private void Start()
	{
		DontDestroyOnLoad(this);
	}

	private void Update()
	{
		_readThisFrame = false;
	}

	public bool WasPressedThisFrame()
	{
		if (_readThisFrame == false)
		{
			_readThisFrame = true;
			return _input.action.WasPerformedThisFrame();
		}
		return false;
	}

}
