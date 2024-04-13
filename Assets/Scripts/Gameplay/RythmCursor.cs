using System;
using UnityEngine;

public sealed class RythmCursor : MonoBehaviour
{
	#region Enum
	public enum State
	{
		Neutral,
		Succeed,
		Failed,
	}
	#endregion Enum

	#region Fields
	[SerializeField] private GameObject _cursorNeutral = null;
	[SerializeField] private GameObject _cursorSucceed = null;
	[SerializeField] private GameObject _cursorFailed = null;
	#endregion Fields

	#region Events
	private Action<RythmMarker> _onMarkerOverlapedEvent = null;
	public event Action<RythmMarker> MarkerOverlaped
	{
		add
		{
			_onMarkerOverlapedEvent -= value;
			_onMarkerOverlapedEvent += value;
		}
		remove
		{
			_onMarkerOverlapedEvent -= value;
		}
	}

	private Action<RythmMarker> _onMarkerUnoverlapedEvent = null;
	public event Action<RythmMarker> MarkerUnoverlaped
	{
		add
		{
			_onMarkerUnoverlapedEvent -= value;
			_onMarkerUnoverlapedEvent += value;
		}
		remove
		{
			_onMarkerUnoverlapedEvent -= value;
		}
	}
	#endregion Events

	#region Methods
	public void SetState(State state)
	{
		_cursorNeutral.SetActive(state == State.Neutral);

		_cursorSucceed.SetActive(state == State.Succeed);
		_cursorFailed.SetActive(state == State.Failed);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out RythmMarker marker))
		{
			_onMarkerOverlapedEvent.Invoke(marker);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out RythmMarker marker))
		{
			_onMarkerUnoverlapedEvent.Invoke(marker);
		}
	}
	#endregion Methods
}
