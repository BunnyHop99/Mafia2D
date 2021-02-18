using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.1f, 50f)]
    float moveSpeed = 2f;

    Animator anim;
    SpriteRenderer spr;
    [SerializeField, Range(0.1f, 100f)]

    float jumpForce;
    Rigidbody2D rb2D;
    int healPoints = 30;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 15f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;
    GameObject bullet;
    GameObject bulletRun;
    PlayerControls playerControls;
    
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public GameObject deathEffect;


    void Awake()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        bullet = GameObject.Find("FirePoint");
        bulletRun = GameObject.Find("FirePointRun");
        playerControls = new PlayerControls ();
    }

    void Start()
    {
        playerControls.Gameplay.Jump.performed += ctx => Jump();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);


        if(Keyboard.current.dKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            if(Flip)
            {
                bullet.transform.localPosition = new Vector3(-3.34f,0.749f,0f);
                bullet.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            else
            {
                
                bullet.transform.localPosition = new Vector3(3.34f,0.749f,0f);
                bullet.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
        else
        {
            if(Flip)
            {
                bullet.transform.localPosition = new Vector3(-3.39f,2.05f,0f);
                bullet.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            else
            {
                bullet.transform.localPosition = new Vector3(3.39f,2.05f,0f);
                bullet.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        } 
    }

    void Jump(){
        if(IsGrounding)
        {
            anim.SetTrigger("jump");
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void LateUpdate()
    {
        spr.flipX = Flip;
        anim.SetFloat("moveX", Mathf.Abs(Axis.x));
    }

    void FixedUpdate()
    {
        anim.SetFloat("velocityY", Mathf.Abs(rb2D.velocity.y));
        anim.SetBool("ground", IsGrounding);
    }

    Vector2 Axis => playerControls.Gameplay.Movement.ReadValue<Vector2>();

    public bool Flip
    {
        get => Axis.x > 0f ? false : Axis.x < 0f ? true : spr.flipX;
    }

    bool IsGrounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("whiskey"))
        {
            Whiskey whiskey = other.GetComponent<Whiskey>();
            GameManager.instance.Task.AddPoints(whiskey.Points);
            Destroy(other.gameObject);
        }

        if(other.CompareTag("medkit"))
        {
            Botiquin medkit = other.GetComponent<Botiquin>();
            currentHealth += healPoints;
            healthBar.SetHealth(currentHealth);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
        else{
            anim.SetTrigger("damage");
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
