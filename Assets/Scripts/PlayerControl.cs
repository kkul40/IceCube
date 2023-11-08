using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerControl : MonoBehaviour, IDamagable
{
    [SerializeField] private Vector2 moveDelta;
    [SerializeField] private Vector2 maxForce;
    [SerializeField] private Rigidbody2D rb2;
    [SerializeField] private float moveForce;
    [SerializeField] private float jumpForce;

    [SerializeField] private Transform OlumEffectPrefab;

    public PostProcessVolume ppVolum;


    public int CandyCount;

    private PlayerAnimation _playerAnimation;

    private Inputs inputs;


    private SpriteRenderer _spriteR;
    private bool MovementLock;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        _spriteR = GetComponentInChildren<SpriteRenderer>();

        _playerAnimation = GetComponentInChildren<PlayerAnimation>();

        // GameData.instance.StartPos = transform;// Simdilik yaptik bunu; sonradan silicez
        MovementLock = false;
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
        # if UNITY_EDITOR
         moveDelta.x = Input.GetAxisRaw("Horizontal");
         moveDelta.y = Input.GetAxisRaw("Vertical");


        moveDelta = inputs.Penguin.Move.ReadValue<Vector2>();
        # endif

        if (moveDelta != Vector2.zero && !MovementLock)
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

        if (inputs.Penguin.Zipla.triggered && IsGrounded()) rb2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (transform.position.y <= -35) TakeDamage();
    }

    private void FixedUpdate()
    {
        if (MovementLock)
        {
            rb2.velocity = Vector3.zero;
            return;
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.TryGetComponent(out IInteractable interact)) interact.Collect();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Platform platform)) transform.parent = null;
    }

    public void TakeDamage()
    {
        StartCoroutine(OlumEffecti());
    }

    IEnumerator OlumEffecti()
    {
        var temp = Instantiate(OlumEffectPrefab, transform);
        Destroy(temp.gameObject, 1);
        MovementLock = true;
        rb2.gravityScale = 0f;

        float velocity = 0f;
        while (ppVolum.weight <= 0.01f)
        {
            Mathf.SmoothDamp(ppVolum.weight, 0, ref velocity, Time.deltaTime);
        }
            

        yield return new WaitForSeconds(1f);
        GameData.instance.RestartScene();
    }

    private void OnDrawGizmos()
    {
        // Gizmos.DrawCube(transform.position, Vector2.one);
    }

    private bool IsGrounded()
    {
        var overlaps = Physics2D.OverlapBoxAll(transform.position, Vector2.one, 0f);
        
        foreach (var overlap in overlaps)
        {
            if (!overlap.CompareTag("Player") && !overlap.CompareTag("CheckPoint")) return true;
        }

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