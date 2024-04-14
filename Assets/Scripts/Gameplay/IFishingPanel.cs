using System;
using System.Collections;
using UnityEngine;

public abstract class IFishingPanel : MonoBehaviour
{
	[SerializeField] private GameObject _root = null;

	[SerializeField] private float _hideDelay = 1.0f;
	[SerializeField] private float _maxTime = 30.0f;

	[SerializeField] private AudioClip _fisherManWinSound = null;
	[SerializeField] private AudioClip _fisherManLoseSound = null;

	[SerializeField] private AudioClip _dogWinSound = null;
	[SerializeField] private AudioClip _dogLoseSound = null;

	private bool _isActive = false;

	/// <summary>
	/// Event triggered when fishing ended.
	/// </summary>
	private Action<bool> _fishingEndedEvent = null;

	/// <summary>
	/// <inheritdoc cref="_fishingEndedEvent"/>
	/// </summary>
	public event Action<bool> FishingEndedEvent
	{
		add { _fishingEndedEvent -= value; _fishingEndedEvent += value; }
		remove { _fishingEndedEvent -= value; }
	}

	private float _timer = 0.0f;

	public virtual void Show()
	{
		_timer = _maxTime;
		_isActive = true;
		_root.SetActive(_isActive);
	}

	public virtual void Hide()
	{
		_isActive = false;
		_root.SetActive(false);
	}

	protected void Succeed()
	{
		_isActive = false;
		StartCoroutine(DelayHide(true, _hideDelay));
		FishDescription currentFish = FishingManager.Instance.CurrentFish;
		FishSnapshotter.Instance.RenderFish(currentFish);
		GameManager.Instance.FishesFished.Add(currentFish);
	}

	protected void Failed()
	{
		_isActive = false;
		StartCoroutine(DelayHide(false, _hideDelay));
	}

	protected IEnumerator DelayHide(bool succeed, float delay)
	{
		yield return new WaitForSeconds(delay);
		Hide();
		_fishingEndedEvent?.Invoke(succeed);

		if (succeed)
		{
			AudioManager.Instance.PlaySound(_fisherManWinSound);
			AudioManager.Instance.PlaySound(_dogWinSound);
		}
		else
		{
			AudioManager.Instance.PlaySound(_fisherManLoseSound);
			AudioManager.Instance.PlaySound(_dogLoseSound);
		}
	}

	public void Update()
	{
		if (_isActive == false)
		{
			return;
		}

		_timer -= Time.deltaTime;
		if (_timer <= 0.0f)
		{
			Failed();
			return;
		}

		UpdateGame();

		if (InputManager.Instance.WasPressedThisFrame())
		{
			OnPressed();
		}
	}

	protected abstract void UpdateGame();

	protected abstract void OnPressed();

	public void Reset()
	{

	}
}
