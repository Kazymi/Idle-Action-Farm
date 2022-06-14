using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create MoneyControllerConfiguration", fileName = "MoneyControllerConfiguration", order = 0)]
public class MoneyControllerConfiguration : ScriptableObject
{
    [SerializeField] private float addMoneyInterval;
    [SerializeField] private float panelShakeDuration;
    [SerializeField] private float panelShakeStrange;

    public float PanelShakeDuration => panelShakeDuration;

    public float PanelShakeStrange => panelShakeStrange;

    public float AddMoneyInterval => addMoneyInterval;
}