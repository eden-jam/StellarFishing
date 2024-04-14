using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
	[SerializeField] private InputActionReference _interactInput = null;
	[SerializeField] private InputActionReference _menuInput = null;

	public bool _readThisFrame = false;

	public InputActionReference InteractInput { get => _interactInput; }
	public InputActionReference MenuInput { get => _menuInput; }

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
			return _interactInput.action.WasPerformedThisFrame();
		}
		return false;
	}

	public void SetCursorState(bool locked)
	{
		Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
		Cursor.visible = locked == false;
	}
}
