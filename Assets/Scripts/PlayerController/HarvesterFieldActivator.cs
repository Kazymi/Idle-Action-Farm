using UnityEngine;

public class HarvesterFieldActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var harvester = other.GetComponent<Harvester>();
        if (harvester)
        {
            harvester.SetHarvesterInField(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var harvester = other.GetComponent<Harvester>();
        if (harvester)
        {
            harvester.SetHarvesterInField(false);
        }
    }
}