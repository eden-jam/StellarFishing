using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
	[SerializeField] private InputActionReference _input = null;

	public bool WasPressedThisFrame { get { return _input.action.WasPerformedThisFrame(); } }

	private void Start()
	{
		DontDestroyOnLoad(this);
	}
}
