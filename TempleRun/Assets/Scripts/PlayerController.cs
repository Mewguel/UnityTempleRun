using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;
    public float runSpeed;
    public float horizontalSpeed;
    public Rigidbody rb;
    float horizontalInput;

    [SerializeField] private float jumpForce = 450;
    [SerializeField] private LayerMask GroundMask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 forwardmovements = transform.forward * runSpeed * Time.fixedDeltaTime;
            Vector3 horizontalmovements = transform.right * horizontalInput * horizontalSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardmovements + horizontalmovements);

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float playerHeight = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, GroundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isAlive && isGrounded)
        {
            Jump();
        }

    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // TODO: change name to tag
        if (collision.gameObject.name == "PillarGraphic" || collision.gameObject.name == "Graphic" )
        {
            Die();
        }
    }

    public void Die()
    { 
        isAlive = false;
        GameManager.GameInstance.GameOverPanel.SetActive(true);
    
    }


}

