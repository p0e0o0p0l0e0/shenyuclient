using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ExGraphicRaycaster: GraphicRaycaster
{
    private Canvas m_Canvas;
    private Canvas canvas
    {
        get
        {
            if (m_Canvas != null)
                return m_Canvas;

            m_Canvas = GetComponent<Canvas>();
            return m_Canvas;
        }
    }
    public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
    {
        base.Raycast(eventData, resultAppendList);
        if (eventCamera != null)
        {
            int displayIndex;
            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay || !eventCamera)
                displayIndex = canvas.targetDisplay;
            else
                displayIndex = eventCamera.targetDisplay;
            var eventPosition = Display.RelativeMouseAt(eventData.position);
            if (eventPosition != Vector3.zero)
            {
                // We support multiple display and display identification based on event position.

                int eventDisplayIndex = (int)eventPosition.z;

                // Discard events that are not part of this display so the user does not interact with multiple displays at once.
                if (eventDisplayIndex != displayIndex)
                    return;
            }
            else
            {
                // The multiple display system is not supported on all platforms, when it is not supported the returned position
                // will be all zeros so when the returned index is 0 we will default to the event data to be safe.
                eventPosition = eventData.position;

                // We dont really know in which display the event occured. We will process the event assuming it occured in our display.
            }
            RaycastHit lastHit;
            Vector2 pos = eventCamera.ScreenToViewportPoint(eventPosition);
            if (pos.x < 0f || pos.x > 1f || pos.y < 0f || pos.y > 1f)
                return;
            Ray ray = eventCamera.ScreenPointToRay(eventPosition);
            int mask = eventCamera.cullingMask;
            float dist = eventCamera.farClipPlane - eventCamera.nearClipPlane;
            if (Physics.Raycast(ray, out lastHit, dist, mask))
            {
                //ViDebuger.Warning("----hit gameobject "+ lastHit.transform.name +", pos="+ eventPosition);
                CanvasRenderer cr = lastHit.transform.gameObject.GetComponent<CanvasRenderer>();
                var castResult = new RaycastResult
                {
                    gameObject = lastHit.transform.gameObject,
                    module = this,
                    distance = lastHit.distance,
                    screenPosition = eventPosition,
                    index = resultAppendList.Count,
                    depth = (cr==null? 0: cr.absoluteDepth),
                    sortingLayer = canvas.sortingLayerID,
                    sortingOrder = canvas.sortingOrder
                };
                resultAppendList.Add(castResult);
            }
        }

    }

}
