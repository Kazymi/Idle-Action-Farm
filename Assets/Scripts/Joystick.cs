using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler,IMovementDirection
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private float handleRange = 1;
    [SerializeField] private float deadZone;

    [SerializeField] protected RectTransform background;
    [SerializeField] private RectTransform handle;
    private Camera _camera;

    public Vector2 Direction { get; private set; }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<IMovementDirection>(this);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<IMovementDirection>();
    }

    protected virtual void Start()
    {
        Vector2 center = new Vector2(0.5f, 0.5f);
        background.pivot = center;
        handle.anchorMin = center;
        handle.anchorMax = center;
        handle.pivot = center;
        handle.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _camera = null;
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            _camera = canvas.worldCamera;
        }

        var position = RectTransformUtility.WorldToScreenPoint(_camera, background.position);
        var radius = background.sizeDelta / 2;
        Direction = (eventData.position - position) / (radius * canvas.scaleFactor);
        HandleInput(Direction.magnitude, Direction.normalized);
        handle.anchoredPosition = Direction * radius * handleRange;
    }

    protected virtual void HandleInput(float magnitude, Vector2 normalised)
    {
        if (magnitude > deadZone)
        {
            if (magnitude > 1)
            {
                Direction = normalised;
            }
        }
        else
        {
            Direction = Vector2.zero;
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        canvas.enabled = true;
        background.position = eventData.position;
        OnDrag(eventData);
    }
    
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        canvas.enabled = false;
        Direction = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}