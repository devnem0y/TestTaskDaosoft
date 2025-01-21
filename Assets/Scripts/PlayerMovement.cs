using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D _controller;
    [SerializeField] private DoubleClickManager _clickManager;
    
    [SerializeField] private float _runSpeed = 40f;
    [SerializeField] private float _horizontalMove;

    private bool _jump;

    private void Awake()
    {
        _clickManager.onDoubleClick += OnDoubleClick;
    }

    private void OnDestroy()
    {
        _clickManager.onDoubleClick -= OnDoubleClick;
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
    }

    private void FixedUpdate()
    {
        _controller.Move(_horizontalMove * Time.fixedDeltaTime, _jump);
        _jump = false;
    }
    
    private void OnDoubleClick(float secondTime)
    {
        //TODO: Сделать настройку фаз прыжка через юайку (конфиг)
        var jumpForce = secondTime switch
        {
            <= 0.2f => 500f,
            > 0.2f and <= 0.7f => 720f,
            > 0.7f and <= 1.2f => 850f,
            _ => 0f
        };

        Debug.Log(secondTime);

        //TODO: Сделать настраеваемую силу прыжка через юайку (конфиг)
        _controller.JumpForce = jumpForce;
        _jump = true;
    }
}
