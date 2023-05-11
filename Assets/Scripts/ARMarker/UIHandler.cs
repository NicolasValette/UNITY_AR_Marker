using ARMarker;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace ARMarker
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField]
        private ARImageManager _arImageManager;
        [SerializeField]
        private GameObject _buttons;

        [SerializeField]
        private TMP_Text _audioText;

        private void Start()
        {
            _buttons.SetActive(false);
        }
        private void OnEnable()
        {
            ARImageManager.OnImageLoaded += ToggleButton;
            ARImageManager.OnImageUnloaded += ToggleButton;
        }
        private void OnDisable()
        {
            ARImageManager.OnImageLoaded -= ToggleButton;
            ARImageManager.OnImageUnloaded -= ToggleButton;
        }
        public void TogglePanelInfo()
        {
            Canvas c = _arImageManager.GetImageInstance().GetComponentInChildren<Canvas>(true);
            GameObject go = c.gameObject;
            if (go != null)
            {
                go.SetActive(!go.activeSelf);
            }
        }

        public void PlayStopAudio()
        {
            AudioSource c = _arImageManager.GetImageInstance().GetComponentInChildren<AudioSource>(true);

            if (c != null)
            {
                if (c.isPlaying)
                {
                    Debug.Log("Stop");
                    c.Stop();
                    _audioText.text = "Play Audio";
                }
                else
                {
                    Debug.Log("Play");
                    c.Play();
                    _audioText.text = "Stop Audio";
                }
            }

        }
        public void ToggleButton()
        {
            _buttons.SetActive(!_buttons.activeSelf);
        }
    }
}