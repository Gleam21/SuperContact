using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PagingManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    ScrollRect cachedScrollRect;
    Coroutine moveCoroutine;

    public ScrollRect CachedScrollRect
    {
        get
        {
            if (cachedScrollRect == null)
            {
                cachedScrollRect = GetComponent<ScrollRect>();
            }
            return cachedScrollRect;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GridLayoutGroup gridLayoutGroup
            = CachedScrollRect.content.GetComponent<GridLayoutGroup>();

        CachedScrollRect.StopMovement();
        
        float pageWidth = -(gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x);
        int pageIndex 
            = Mathf.RoundToInt(CachedScrollRect.content.anchoredPosition.x / pageWidth);
        Debug.Log(pageIndex);

        float targetX = pageIndex * pageWidth;

    }

    public void OnTest(Vector2 value)
    {

    }
}
