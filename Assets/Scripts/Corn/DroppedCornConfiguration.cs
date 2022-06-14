using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create DroppedCornConfiguration", fileName = "DroppedCornConfiguration", order = 0)]
public class DroppedCornConfiguration : ScriptableObject
{
    [SerializeField] private PriceConfiguration priceConfiguration;
    [SerializeField] private float duration;

    public PriceConfiguration PriceConfiguration => priceConfiguration;

    public float Duration => duration;
}