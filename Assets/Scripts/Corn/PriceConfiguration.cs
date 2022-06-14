using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create PriceConfiguration", fileName = "PriceConfiguration", order = 0)]
public class PriceConfiguration : ScriptableObject
{
    [SerializeField] private int price;

    public int Price => price;
}