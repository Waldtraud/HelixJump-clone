using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{    
        [SerializeField] Transform _level;
        [SerializeField] float _sensitivity;
        private Vector3 _previousMousePosition;

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - _previousMousePosition;
                _level.Rotate(0, -delta.x * _sensitivity, 0);
            }
            _previousMousePosition = Input.mousePosition;
    }  

}
