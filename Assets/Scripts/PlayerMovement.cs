using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D _controller;
    
    [SerializeField] private float _runSpeed = 40f;
    [SerializeField] private float _horizontalMove;

    private bool _jump;

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;

        if (Input.GetButtonDown("Jump")) _jump = true;
    }

    private void FixedUpdate()
    {
        _controller.Move(_horizontalMove * Time.fixedDeltaTime, _jump);
        _jump = false;
    }
}
