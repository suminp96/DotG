using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirPad : EventTrigger
{
    //누구나 읽을 수 있지만 바꿀 수는 없다.
    public Vector2 startPosition { get; private set; }
    public bool dragging { get; private set; }
    private Vector2 currentPosition;
    public Vector2 dir { get { return currentPosition - startPosition; } }
    public override void OnBeginDrag(PointerEventData eventData)//dragging이 시작될때
    {
        base.OnBeginDrag(eventData);
        startPosition = eventData.position;//화면상의 위치라 2차원이면 충분하다
        dragging = true;
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        currentPosition = eventData.position;
        //어느 방향으로 이동하고 있는가.
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        dragging = false;
    }
}
