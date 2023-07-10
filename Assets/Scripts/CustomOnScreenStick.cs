//using System;
//using System.Collections.Generic;
//using UnityEngine.EventSystems;
//using UnityEngine.Serialization;
//using UnityEngine.InputSystem.Layouts;
//using UnityEngine.InputSystem.Utilities;
//using UnityEngine.UI;


//namespace UnityEngine.InputSystem.OnScreen 
//{ 

//    public class CustomOnScreenStick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
//    {



//        public void OnPointerDown(PointerEventData eventData)
//        {
//            if (eventData == null)
//                throw new System.ArgumentNullException(nameof(eventData));

//            BeginInteraction(eventData.position, eventData.pressEventCamera);
//        }

//        public void OnDrag(PointerEventData eventData)
//        {
//            if (eventData == null)
//                throw new System.ArgumentNullException(nameof(eventData));

//            MoveStick(eventData.position, eventData.pressEventCamera);
//        }

//        public void OnPointerUp(PointerEventData eventData)
//        {
//            EndInteraction();
//        }
//        private void Start()
//        {
//            m_StartPos = ((RectTransform)transform).anchoredPosition;
//        }


//        private void BeginInteraction(Vector2 pointerPosition, Camera uiCamera)
//        {
//            var canvasRect = transform.parent?.GetComponentInParent<RectTransform>();
//            if (canvasRect == null)
//            {
//                Debug.LogError("OnScreenStick needs to be attached as a child to a UI Canvas to function properly.");
//                return;
//            }
//            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, pointerPosition, uiCamera, out m_PointerDownPos);
//            MoveStick(pointerPosition, uiCamera);

//        }

//        private void MoveStick(Vector2 pointerPosition, Camera uiCamera)
//        {
//            var canvasRect = transform.parent?.GetComponentInParent<RectTransform>();
//            if (canvasRect == null)
//            {
//                Debug.LogError("OnScreenStick needs to be attached as a child to a UI Canvas to function properly.");
//                return;
//            }
//            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, pointerPosition, uiCamera, out var position);
//            var delta = position - m_PointerDownPos;

//            delta = position - (Vector2)m_StartPos;
//            delta = Vector2.ClampMagnitude(delta, movementRange);
//            ((RectTransform)transform).anchoredPosition = (Vector2)m_StartPos + delta;
 

//            var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
//            SendValueToControl(newPos);
//        }

//        private void EndInteraction()
//        {
//            ((RectTransform)transform).anchoredPosition = m_PointerDownPos = m_StartPos;
//            SendValueToControl(Vector2.zero);
//        }

//    }
//}
