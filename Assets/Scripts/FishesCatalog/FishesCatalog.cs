using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishesCatalog", menuName = "Fish Data/Fishes Catalog", order = 1)]
public class FishesCatalog : ScriptableObject
{
	#region Fields
	[SerializeField] private List<FishDescription> _fishDescriptions = new List<FishDescription>();
	#endregion Fields

	#region Properties
	public List<FishDescription> FishDescriptions { get => _fishDescriptions; }
	#endregion Properties

	#region Methods
	public FishDescription GetRandomFish(EnvironmentType currentEnvironmentType)
	{
		List<FishDescription> fishDescriptionsInEnvironment = new List<FishDescription>();
		foreach (FishDescription description in _fishDescriptions)
		{
			if (description.EnvironmentType == currentEnvironmentType)
			{ 
				fishDescriptionsInEnvironment.Add(description); 
			}
		}

		return fishDescriptionsInEnvironment[Random.Range(0, fishDescriptionsInEnvironment.Count)];
	}
	#endregion Methods
}
