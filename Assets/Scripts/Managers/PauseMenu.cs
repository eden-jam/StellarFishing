using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject PausePanel;

	public static bool GameIsPaused = false;

	void Update()
	{
		if (InputManager.Instance.MenuInput.action.WasPerformedThisFrame())
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Pause()
	{
		PausePanel.SetActive(true);
		InputManager.Instance.SetCursorState(false);
		InputManager.Instance.InteractInput.action.Disable();
		GameIsPaused = true;
	}
	public void Resume()
	{
		PausePanel.SetActive(false);
		InputManager.Instance.SetCursorState(true);
		InputManager.Instance.InteractInput.action.Enable();
		GameIsPaused = false;
	}

	public void Restart()
	{
		InputManager.Instance.SetCursorState(true);
		InputManager.Instance.InteractInput.action.Enable();
		GameIsPaused = false;

		GameManager.Instance.Restart();
	}
}

