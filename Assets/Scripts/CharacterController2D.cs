using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	const float GROUNDED_RADIUS = 0.2f;
	
	[Range(0, 0.3f)] [SerializeField] private float _movementSmoothing = 0.05f;	
	[SerializeField] private bool _airControl;							
	[SerializeField] private LayerMask _whatIsGround;							
	[SerializeField] private Transform m_GroundCheck;
	
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
		
		var colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, GROUNDED_RADIUS, _whatIsGround);
		foreach (var col in colliders)
		{
			if (col.gameObject != gameObject) _isGrounded = true;
		}
	}


	public void Move(float move, bool jump)
	{
		if (_isGrounded || _airControl)
		{
			var velocity = _rb.velocity;
			Vector3 targetVelocity = new Vector2(move * 10f, velocity.y);
			_rb.velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref _velocity, _movementSmoothing);
		}
		
		if (!_isGrounded || !jump) return;
		_isGrounded = false;
		_rb.AddForce(new Vector2(0f, JumpForce));
	}
}
