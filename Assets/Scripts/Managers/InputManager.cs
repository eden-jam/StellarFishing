using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
	[SerializeField] private InputActionReference _input = null;

	public bool WasPressedThisFrame { get { return _input.action.WasPerformedThisFrame(); } }

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		DontDestroyOnLoad(this);
	}
}
