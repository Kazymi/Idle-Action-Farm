public interface IKeeperOfSalableItems
{
    bool IsItemCanBeSold { get; }
    ISalableItem GetSalableItem();
}