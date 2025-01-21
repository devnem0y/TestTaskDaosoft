using System;
using UnityEngine;

public class DoubleClickManager : MonoBehaviour
{
    private float _firstClickTime;
    private float _secondClickTime;
    
    private int _clickCount;
    private bool _isMouse;
    
    public event Action<float> onDoubleClick;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!_isMouse && _clickCount == 1) _clickCount = 0;
            
            _clickCount++;
            
            switch (_clickCount)
            {
                case 1:
                    _isMouse = true;
                    _firstClickTime = Time.time;
                    break;
                case 2:
                    if (_isMouse)
                    {
                        OnDoubleClicked();
                        _isMouse = false;
                    }
                    _clickCount = 0;
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_isMouse && _clickCount == 1) _clickCount = 0;
            
            _isMouse = false;
            _clickCount++;

            switch (_clickCount)
            {
                case 1:
                    _firstClickTime = Time.time;
                    break;
                case 2:
                    if (!_isMouse) OnDoubleClicked();
                    _clickCount = 0;
                    break;
            }
        }
    }

    private void OnDoubleClicked()
    {
        _secondClickTime = Time.time;
        onDoubleClick?.Invoke(_secondClickTime - _firstClickTime);
    }
}
