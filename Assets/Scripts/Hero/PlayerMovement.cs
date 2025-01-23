using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D _controller;
    [SerializeField] private DoubleClickManager _clickManager;
    [SerializeField] private float _runSpeed = 30f;

    private bool _running;
    private bool _jump;

    private void Awake()
    {
        _clickManager.onDoubleClick += OnDoubleClick;
    }

    private void OnDestroy()
    {
        _clickManager.onDoubleClick -= OnDoubleClick;
    }

    private void FixedUpdate()
    {
        _controller.Move(1 * _runSpeed * Time.fixedDeltaTime, _jump);
        _jump = false;
    }
    
    private void OnDoubleClick(float secondTime)
    {
        //TODO: Сделать настройку фаз прыжка через юайку (конфиг)
        var jumpForce = secondTime switch
        {
            <= 0.2f => 10f,
            > 0.2f and <= 0.7f => 12.5f,
            > 0.7f and <= 1.2f => 16f,
            _ => 0f
        };

        Debug.Log(secondTime);

        //TODO: Сделать настраеваемую силу прыжка через юайку (конфиг)
        _controller.JumpForce = jumpForce;
        _jump = true;
    }
}
