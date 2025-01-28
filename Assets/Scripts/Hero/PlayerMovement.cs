using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D _controller;
    [SerializeField] private DoubleClickManager _clickManager;
    
    private static float Speed => EntryPoint.Instance.Config.Speed;
    
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
        _controller.Move(1 * Speed * Time.fixedDeltaTime, _jump);
        _jump = false;
    }
    
    private void OnDoubleClick(float secondTime)
    {
        float jumpForce;
        if (secondTime <= EntryPoint.Instance.Config.JumpLong.RangeClick.Max)
            jumpForce = EntryPoint.Instance.Config.JumpLong.Force;
        else if (secondTime > EntryPoint.Instance.Config.JumpMedium.RangeClick.Min && secondTime <= EntryPoint.Instance.Config.JumpMedium.RangeClick.Max)
            jumpForce = EntryPoint.Instance.Config.JumpMedium.Force;
        else if (secondTime > EntryPoint.Instance.Config.JumpHigh.RangeClick.Min && secondTime <= EntryPoint.Instance.Config.JumpHigh.RangeClick.Max)
            jumpForce = EntryPoint.Instance.Config.JumpHigh.Force;
        else
            jumpForce = 0f;
        
        _controller.JumpForce = jumpForce;
        _jump = true;
    }
}
