using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IDamagable
{
    [SerializeField] private Vector2 moveDelta;
    [SerializeField] private Vector2 maxForce;
    [SerializeField] private Rigidbody2D rb2;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;


    private PlayerAnimation _playerAnimation;

    private Inputs inputs;


    private SpriteRenderer _spriteR;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        _spriteR = GetComponentInChildren<SpriteRenderer>();

        _playerAnimation = GetComponentInChildren<PlayerAnimation>();

        // GameData.instance.StartPos = transform;// Simdilik yaptik bunu; sonradan silicez
        
        transform.position = SaveHelper.LoadPlayerPos();
    }


    private void OnEnable()
    {
        inputs = new Inputs();
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void Update()
    {
        // moveDelta.x = Input.GetAxisRaw("Horizontal");
        // moveDelta.y = Input.GetAxisRaw("Vertical");


        moveDelta = inputs.Penguin.Move.ReadValue<Vector2>();

        if (moveDelta != Vector2.zero)
        {
            _playerAnimation._animator.SetBool("isWalking", true);
            
            
            if (moveDelta.x > 0)
                _spriteR.flipX = false;
            else
                _spriteR.flipX = true;
        }
        else
        {
            _playerAnimation._animator.SetBool("isWalking", false);
        }

        if (inputs.Penguin.Zipla.triggered && !IsGrounded()) rb2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (transform.position.y <= -35) TakeDamage();
    }

    private void FixedUpdate()
    {
        if (Math.Abs(rb2.velocity.x) < maxForce.x) rb2.AddForce(moveDelta * moveForce, ForceMode2D.Impulse);
        // Debug.Log(rb2.velocity.y);
        var velocity = rb2.velocity;
        velocity.x = Math.Clamp(velocity.x, -maxForce.x, maxForce.x);
        velocity.y = Math.Clamp(velocity.y, -maxForce.y, maxForce.y);

        rb2.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Platform platform)) transform.parent = platform.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Platform platform)) transform.parent = null;
    }

    public void TakeDamage()
    {
        GameData.instance.RestartScene();
    }

    private bool IsGrounded()
    {
        return false;
    }

    public void LeftButton()
    {
        moveDelta = Vector2.left;
        Debug.Log("test");
    }
    public void RightButton()
    {
        moveDelta = Vector2.right;
    }

    public void ZeroPoint()
    {
        moveDelta = Vector2.zero;
    } 
    public void Jumping()
    {
        rb2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}