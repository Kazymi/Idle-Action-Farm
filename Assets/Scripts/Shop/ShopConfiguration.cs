using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create ShopConfiguration", fileName = "ShopConfiguration", order = 0)]
public class ShopConfiguration : ScriptableObject
{
    [SerializeField] private float intervalRequest;

    public float IntervalRequest => intervalRequest;
}