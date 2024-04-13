using UnityEngine;

[CreateAssetMenu(fileName = "FishesDescription", menuName = "Fish Data/Fish", order = 1)]
public sealed class FishDescription : ScriptableObject
{
	#region Fields
	[SerializeField] private string _label = "Fish";
	[SerializeField] private FishingMiniGameType _fishingMiniGameType = FishingMiniGameType.None;
	[SerializeField] private EnvironmentType _environmentType = EnvironmentType.None;
	[SerializeField] private Sprite _sprite = null;
	[SerializeField] private GameObject _modelPrefab = null;
	#endregion Fields

	#region Properties
	public string Label { get => _label; }
	public FishingMiniGameType FishingMiniGameType { get => _fishingMiniGameType; }
	public EnvironmentType EnvironmentType { get => _environmentType; }
	public Sprite Sprite { get => _sprite; }
	public GameObject ModelPrefab { get => _modelPrefab; }
	#endregion Properties
}
