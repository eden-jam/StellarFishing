using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject PausePanel;

	public static bool GameIsPaused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
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
		InputManager.Instance.Input.action.Disable();
		GameIsPaused = true;
	}
	public void Resume()
	{
		PausePanel.SetActive(false);
		InputManager.Instance.SetCursorState(true);
		InputManager.Instance.Input.action.Enable();
		GameIsPaused = false;
	}

	public void Restart()
	{
		InputManager.Instance.SetCursorState(true);
		InputManager.Instance.Input.action.Enable();
		GameIsPaused = false;

		GameManager.Instance.Restart();
	}
}

