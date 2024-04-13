using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingManager : Singleton<FishingManager>
{
	[SerializeField] private PrecisionFishingPanel _precisionFishingPanel = null;
	[SerializeField] private SmashFishingPanel _smashFishingPanel = null;
	[SerializeField] private RythmFishingPanel _rythmFishingPanel = null;
	[SerializeField] private WinPanel _winPanel = null;
	[SerializeField] private LoosePanel _loosePanel = null;

	private bool _isActive = false;

	/// <summary>
	/// Event triggered when 
	/// </summary>
	private Action<bool> _onFishEndedEvent = null;

	/// <summary>
	/// <inheritdoc cref="_onFishEndedEvent"/>
	/// </summary>
	public event Action<bool> OnFishEnded
	{
		add { _onFishEndedEvent -= value; _onFishEndedEvent += value; }
		remove { _onFishEndedEvent -= value; }
	}

	public void Start()
	{
		HideGame();
	}

	public void Update()
	{
		if (_isActive == false && InputManager.Instance.WasPressedThisFrame)
		{
			_isActive = true;
			LaunchPrecisionFishing();
		}
	}

	public void LaunchPrecisionFishing()
	{
		_precisionFishingPanel.Show();
		_precisionFishingPanel.FishingEndedEvent += OnFishingEnded;
	}

	public void LaunchSmashFishingPanel()
	{
		_smashFishingPanel.Show();
		_smashFishingPanel.FishingEndedEvent += OnFishingEnded;
	}

	public void LaunchRythmFishingPanel()
	{
		_rythmFishingPanel.Show();
		_rythmFishingPanel.FishingEndedEvent += OnFishingEnded;
	}

	private void OnFishingEnded(bool succeed)
	{
		_onFishEndedEvent?.Invoke(succeed);
		HideGame();
		if (succeed)
		{
			_winPanel.gameObject.SetActive(true);
			_winPanel.Display(null);
			_winPanel.PanelHiddedEvent += HideEnd;
		}
		else
		{
			_loosePanel.gameObject.SetActive(true);
			_loosePanel.PanelHiddedEvent += HideEnd;
		}
	}

	private void HideEnd()
	{
		_winPanel.PanelHiddedEvent += HideEnd;
		_loosePanel.PanelHiddedEvent += HideEnd;
		HideGame();
	}

	private void HideGame()
	{
		_precisionFishingPanel.Hide();
		_smashFishingPanel.Hide();
		_rythmFishingPanel.Hide();
	}
}
