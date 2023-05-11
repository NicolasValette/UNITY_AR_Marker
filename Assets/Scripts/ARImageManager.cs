using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace ARMarker
{
    public class ARImageManager : MonoBehaviour
    {


        [SerializeField]
        private ARTrackedImageManager _trackedImageManager;

        public static event Action OnImageLoaded;
        public static event Action OnImageUnloaded;
        private GameObject _lastGOInstantiate;
        private void OnEnable()
        {
            _trackedImageManager.trackedImagesChanged += OnChanged;
        }
        private void OnDisable()
        {
            _trackedImageManager.trackedImagesChanged -= OnChanged;
        }
        public void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (ARTrackedImage trackedImage in eventArgs.added)
            {
                _lastGOInstantiate = trackedImage.gameObject;
                OnImageLoaded?.Invoke();
            }
            foreach (ARTrackedImage trackedImage in eventArgs.removed)
            {
                _lastGOInstantiate = null;
                OnImageUnloaded?.Invoke();
            }
        }
        public GameObject GetImageInstance() 
        {
            return _lastGOInstantiate;
        }
    }
}