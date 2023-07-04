using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ARPlane
{


    public class Debug : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _debugText;

        void Start()
        {
            _debugText.text = "Application started";
        }

        private void Update()
        {
            Input.GetTouch();
        }
    }
}