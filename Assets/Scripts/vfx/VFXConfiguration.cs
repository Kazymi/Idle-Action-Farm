using UnityEngine;

[CreateAssetMenu(menuName = "Configurations/Create VFXConfiguration", fileName = "VFXConfiguration", order = 0)]
public class VFXConfiguration : ScriptableObject
{
    [SerializeField] private VFXType vfxType;
    [SerializeField] private TemporaryMonoPooled prefab;

    public VFXType VFXType => vfxType;

    public TemporaryMonoPooled Prefab => prefab;
}