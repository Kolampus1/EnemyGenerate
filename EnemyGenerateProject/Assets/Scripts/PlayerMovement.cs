using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _jumpHeigh;
    [SerializeField] private float _moveSpeed;

    private Rigidbody _rigidbody;
    private bool _isGrounded = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.AddForce(Vector3.up * _jumpHeigh, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis(Horizontal);
        float vertical = Input.GetAxis(Vertical);

        Vector3 movedirection = new Vector3(horizontal, 0f, vertical);
        _rigidbody.AddForce(movedirection * _moveSpeed, ForceMode.Force);
    }
}
