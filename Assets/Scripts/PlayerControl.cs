using System;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IDamagable
{
    [SerializeField] private Vector2 moveDelta;
    [SerializeField] private Vector2 maxForce;
    [SerializeField] private Rigidbody2D rb2;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;


    private SpriteRenderer _spriteR;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        _spriteR = GetComponent<SpriteRenderer>();

        // GameData.instance.StartPos = transform;// Simdilik yaptik bunu; sonradan silicez
        
        transform.position = SaveHelper.LoadPlayerPos();
    }

    private void Update()
    {
        moveDelta.x = Input.GetAxisRaw("Horizontal");
        moveDelta.y = Input.GetAxisRaw("Vertical");

        if (moveDelta != Vector2.zero)
        {
            if (moveDelta.x > 0)
                _spriteR.flipX = true;
            else
                _spriteR.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded()) rb2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

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
}