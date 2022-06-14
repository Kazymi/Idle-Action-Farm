using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GatherController : MonoBehaviour
{
    [SerializeField] private TextController cornTextController;
    [SerializeField] private GatherConfiguration gatherConfiguration;
    [SerializeField] private LayerMask droppedCornMask;
    [SerializeField] private Transform center;
    [SerializeField] private Transform fistBlock;

    private float _cooldown;
    private bool _isLookingUnlock => _droppedCorns.Count < gatherConfiguration.MAXCorns;
    private readonly List<DroppedCorn> _droppedCorns = new List<DroppedCorn>();

    private void Start()
    {
        cornTextController.UpdateText($"{_droppedCorns.Count} / {gatherConfiguration.MAXCorns}");
    }

    private void Update()
    {
        RecalculateCooldown();
    }

    private void RecalculateCooldown()
    {
        if (_cooldown < 0)
        {
            _cooldown = gatherConfiguration.LookingTime;
            LookingCorn();
        }
        else
        {
            _cooldown -= Time.deltaTime;
        }
    }

    private void LookingCorn()
    {
        if (_isLookingUnlock == false)
        {
            return;
        }

        var foundCorns = Physics.OverlapSphere(center.position, gatherConfiguration.Radius, droppedCornMask).Where(
            t =>
            {
                var corn = t.GetComponent<DroppedCorn>();
                if (corn == false || corn.IsAttached)
                {
                    return false;
                }

                return corn;
            });
        var nearestCorn = GetNearestCorn(foundCorns);
        if (nearestCorn == null)
        {
            return;
        }

        AddNewDroppedCorn(nearestCorn);
    }

    private void AddNewDroppedCorn(DroppedCorn droppedCorn)
    {
        droppedCorn.MoveAndAttach(fistBlock, _droppedCorns.Count * gatherConfiguration.IntervalBetweenCorn);
        _droppedCorns.Add(droppedCorn);
        cornTextController.UpdateText($"{_droppedCorns.Count} / {gatherConfiguration.MAXCorns}");
    }

    private DroppedCorn GetNearestCorn(IEnumerable<Collider> colliders)
    {
        var enumerable = colliders as Collider[] ?? colliders.ToArray();
        if (enumerable.Any() == false)
        {
            return null;
        }

        var nearest = enumerable.OrderBy(x => Vector3.Distance(center.position, x.transform.position))
            .FirstOrDefault();
        return nearest.GetComponent<DroppedCorn>();
    }
}