using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using FashionM.Core;

public class FloatingJoystick : Joystick
{
    private GameManager gm;
    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
        gm = FindObjectOfType<GameManager>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
        gm.InfintyUI.SetActive(false);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }
}