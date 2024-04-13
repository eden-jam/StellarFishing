using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingManager : Singleton<FishingManager>
{
	[SerializeField] private InputActionReference _input = null;

	[SerializeField] private PrecisionFishingPanel _precisionFishingPanel = null;
	[SerializeField] private SmashFishingPanel _smashFishingPanel = null;
	[SerializeField] private RythmFishingPanel _rythmFishingPanel = null;

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
		HideAll();
	}

	public void Update()
	{
		if (_isActive == false && _input.action.WasPerformedThisFrame())
		{
			_isActive = true;
			LaunchSmashFishingPanel();
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
		HideAll();
	}

	private void HideAll()
	{
		_precisionFishingPanel.Hide();
		_smashFishingPanel.Hide();
		_rythmFishingPanel.Hide();
	}
}
