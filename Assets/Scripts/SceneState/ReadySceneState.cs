public class ReadySceneState : ISceneState
{
	public override void Update()
	{
		if (InputManager.Instance.WasPressedThisFrame())
		{
			SceneStateManager.Instance.RequestNextState();
		}
	}

	public override void OnEnterState()
	{
		base.OnEnterState();
		FishingManager.Instance.PressToFishPanel.gameObject.SetActive(true);
	}

	public override void OnExitState()
	{
		base.OnExitState();
		FishingManager.Instance.PressToFishPanel.gameObject.SetActive(false);
		PlayerBoatAnimation.Instance.PlayLaunch();
	}
}