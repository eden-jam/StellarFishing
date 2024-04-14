using System.Collections;
using UnityEngine;

public sealed class RythmFishingPanel : IFishingPanel
{
	#region Fields
	[Header("Rythm Game")]
	[SerializeField] private float _rythmDuration = 10.0f;
	[SerializeField] private RectTransform _startTransform = null;
	[SerializeField] private RectTransform _endTransform = null;
	[SerializeField] private RythmCursor _rythmCursor = null;
	[SerializeField] private float _minScore = 0.75f;

	[Header("Audio")]
	[SerializeField] private MultiAudioClip _fishingRodBad = null;
	[SerializeField] private MultiAudioClip _fishingRodGood = null;

	private float _currentDuration = 0.0f;
	private Coroutine _currentCoroutine = null;
	private RythmMarker _currentMarker = null;
	private int _markerCount = 0;
	private float _markerSucceded = 0.0f;
	#endregion Fields

	#region Methods
	public override void Hide()
	{
		base.Hide();
		_rythmCursor.MarkerOverlaped -= OnMarkerOverlaped;
		_rythmCursor.MarkerUnoverlaped -= OnMarkerUnoverlaped;

		if (_currentCoroutine != null)
		{
			StopCoroutine(_currentCoroutine);
			_currentCoroutine = null;
		}
	}

	public override void Show()
	{
		base.Show();
		_currentDuration = 0.0f;
		_rythmCursor.MarkerOverlaped += OnMarkerOverlaped;
		_rythmCursor.MarkerUnoverlaped += OnMarkerUnoverlaped;

		_markerCount = GetComponentsInChildren<RythmMarker>(true).Length;
		_markerSucceded = 0.0f;
	}

	protected override void UpdateGame()
	{
		_currentDuration += Time.deltaTime;

		float t = _currentDuration / _rythmDuration;
		_rythmCursor.gameObject.transform.position = Vector3.Lerp(_startTransform.position, _endTransform.position, t);

		if (_currentDuration >= _rythmDuration)
		{
			float score = _markerSucceded / _markerCount;
			if (score >= _minScore)
			{
				Succeed();
			}
			else
			{
				Failed();
			}
		}
	}

	protected override void OnPressed()
	{
		if (_currentMarker != null)
		{
			_markerSucceded++;
			_currentMarker.SetState(true);
			_rythmCursor.SetState(RythmCursor.State.Succeed);
			AudioManager.Instance.PlaySoundFishingRodSound(_fishingRodGood.GetRandomClip());

			_currentMarker = null;							 
		}
		else
		{
			_rythmCursor.SetState(RythmCursor.State.Failed);
			AudioManager.Instance.PlaySoundFishingRodSound(_fishingRodBad.GetRandomClip());
		}

		if (_currentCoroutine != null)
		{
			StopCoroutine(_currentCoroutine);
			_currentCoroutine = null;
		}
		_currentCoroutine = StartCoroutine(OnPressFeedbackDisplayed());
	}

	private IEnumerator OnPressFeedbackDisplayed()
	{
		yield return new WaitForSeconds(0.5f);

		_rythmCursor.SetState(RythmCursor.State.Neutral);
		_currentCoroutine = null;
		yield return null;
	}

	private void OnMarkerOverlaped(RythmMarker marker)
	{
		if (marker.IsSucceed == false)
		{
			_currentMarker = marker;
		}
	}

	private void OnMarkerUnoverlaped(RythmMarker marker)
	{
		if (marker.IsSucceed == false && _currentMarker == marker)
		{
			_currentMarker.SetState(false);
			_currentMarker = null;
		}
	}
	#endregion Methods
}
