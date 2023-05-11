using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

namespace ARMarker
{
    public class RotateObject : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {

        [SerializeField]
        private ARImageManager _arImageManager;
        [SerializeField]
        private float _rotateAngle;
        private bool _isRotating = false;
 
        private void Update()
        {
            if (_isRotating && _arImageManager.GetImageInstance() != null)
            {
                _arImageManager.GetImageInstance().transform.Rotate(new Vector3(0f, 0f, _rotateAngle));
            }
        }
       
     


        public void OnPointerUp(PointerEventData eventData)
        {
            _isRotating = false;
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isRotating = true;
        }
    }
}