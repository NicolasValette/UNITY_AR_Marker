using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARMarker
{

    public class PostProcessController : MonoBehaviour
    {

        [SerializeField]
        private GameObject _postProcess;

        private void OnEnable()
        {
            ARImageManager.OnImageLoaded += TogglePostProcess;
            ARImageManager.OnImageUnloaded += TogglePostProcess;
        }
        private void OnDisable()
        {
            ARImageManager.OnImageLoaded -= TogglePostProcess;
            ARImageManager.OnImageUnloaded -= TogglePostProcess;
        }

        public void TogglePostProcess()
        {
            _postProcess.SetActive(!_postProcess.activeSelf);
        }
    }
}