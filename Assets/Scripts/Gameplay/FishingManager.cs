using System;
using Unity.VisualScripting;
using UnityEngine;

public class FishingManager : Singleton<FishingManager>
{
	#region Fields
	[SerializeField] private PrecisionFishingPanel _precisionFishingPanel = null;
	[SerializeField] private SmashFishingPanel _smashFishingPanel = null;
	[SerializeField] private RythmFishingPanel _rythmFishingPanel = null;
	[SerializeField] private WinPanel _winPanel = null;
	[SerializeField] private LoosePanel _loosePanel = null;

	private bool _hasSucceed = false;
	private FishDescription _currentFish = null;
	#endregion Fields

	#region Properties
	public FishDescription CurrentFish { get => _currentFish;}
	#endregion Properties

	#region Events
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
	#endregion Events

	#region Methods
	private void OnDestroy()
	{
		_currentFish = null;
		_onFishEndedEvent = null;
	}

	private void Start()
	{
		HideGame();
	}

	public void LaunchFishing()
	{
		GatherFish();
		_hasSucceed = false;
		switch (_currentFish.FishingMiniGameType)
		{
			case FishingMiniGameType.Smash:
				{
					LaunchSmashFishingPanel();
				break;
				}

			case FishingMiniGameType.Precision:
				{
					LaunchPrecisionFishingPanel();
				break;
				}

			case FishingMiniGameType.Rythm:
				{
					LaunchRythmFishingPanel();
				break;
				}

			default:
			case FishingMiniGameType.None:
				{
					throw new NotImplementedException();
				}
		}
	}

	private void LaunchPrecisionFishingPanel()
	{
		_precisionFishingPanel.Show();
		_precisionFishingPanel.FishingEndedEvent += OnFishingEnded;
	}

	private void LaunchSmashFishingPanel()
	{
		_smashFishingPanel.Show();
		_smashFishingPanel.FishingEndedEvent += OnFishingEnded;
	}

	private void LaunchRythmFishingPanel()
	{
		_rythmFishingPanel.Show();
		_rythmFishingPanel.FishingEndedEvent += OnFishingEnded;
	}

	private void OnFishingEnded(bool succeed)
	{
		_hasSucceed = succeed;
		HideGame();
		if (succeed)
		{
			_winPanel.gameObject.SetActive(true);
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
		_winPanel.PanelHiddedEvent -= HideEnd;
		_loosePanel.PanelHiddedEvent -= HideEnd;
		_onFishEndedEvent?.Invoke(_hasSucceed);
	}

	private void HideGame()
	{
		_precisionFishingPanel.Hide();
		_smashFishingPanel.Hide();
		_rythmFishingPanel.Hide();
	}

	private void GatherFish()
	{
		_currentFish = GameManager.Instance.FishesCatalog.GetRandomFish(EnvironmentManager.Instance.CurrentEnvironmentType);
	}
	#endregion Methods
}
