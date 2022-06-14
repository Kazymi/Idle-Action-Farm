using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create ShakeUIConfiguration", fileName = "ShakeUIConfiguration", order = 0)]
public class ShakeUIConfiguration : ScriptableObject
{
    [SerializeField] private float panelShakeDuration;
    [SerializeField] private float panelShakeStrange;
    [SerializeField] private float imageShakeDuration;
    [SerializeField] private float imageShakeStrange;

    public float ImageShakeDuration => imageShakeDuration;
    public float ImageShakeStrange => imageShakeStrange;

    public float PanelShakeDuration => panelShakeDuration;

    public float PanelShakeStrange => panelShakeStrange;
}