using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create MoneyControllerConfiguration", fileName = "MoneyControllerConfiguration", order = 0)]
public class MoneyControllerConfiguration : ScriptableObject
{
    [SerializeField] private float addMoneyInterval;

    public float AddMoneyInterval => addMoneyInterval;
}