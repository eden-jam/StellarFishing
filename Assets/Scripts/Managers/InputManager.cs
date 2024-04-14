using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
	[SerializeField] private InputActionReference _input = null;

	public bool _readThisFrame = false;

	public InputActionReference Input { get => _input; }

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

	public void SetCursorState(bool locked)
	{
		Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
		Cursor.visible = locked == false;
	}
}
