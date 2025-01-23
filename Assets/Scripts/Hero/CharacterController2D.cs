using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	[Range(0, 0.3f)] [SerializeField] private float _movementSmoothing = 0.01f;	
	[SerializeField] private LayerMask _whatIsGround;							
	[SerializeField] private Transform _groundCheck;
	
	public float JumpForce { get; set; }

	private bool _isGrounded;
	private Rigidbody2D _rb;
	private Vector3 _velocity = Vector3.zero;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		_isGrounded = false;
		
		var colliders = Physics2D.OverlapCapsuleAll(_groundCheck.position, 
			GetComponent<CapsuleCollider2D>().bounds.size, CapsuleDirection2D.Horizontal, _whatIsGround);
		
		foreach (var col in colliders)
		{
			if (col.gameObject != gameObject) _isGrounded = true;
		}
	}


	public void Move(float move, bool jump)
	{
		if (_isGrounded)
		{
			var velocity = _rb.velocity;
			Vector3 targetVelocity = new Vector2(move * 10f, velocity.y);
			_rb.velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref _velocity, _movementSmoothing);
		}
		
		if (!_isGrounded || !jump) return;
		_isGrounded = false;
		_rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
	}
}
