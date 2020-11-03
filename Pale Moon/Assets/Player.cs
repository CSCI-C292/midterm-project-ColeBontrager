using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _fallSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _pillowForce;
    [SerializeField] float _throwForce;
    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] LayerMask platformLayer;
    [SerializeField] GameObject pillow;

    [SerializeField] GameObject barrier;

    bool hasPillow = true;

    Rigidbody2D rb;

    BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector2(0, _jumpForce));
        }
        
        if(!isGrounded() && hasPillow && Input.GetKey(KeyCode.Space) && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, _fallSpeed);
        }
        
        if(Input.GetMouseButton(0))
        {
            ThrowPillow();
        }
        
        _runtimeData.playerMovements.Add(transform.position);
        
        
    }

    void FixedUpdate()
    {
        Movement();
    }

    void ThrowPillow()
    {
        if(hasPillow)
        {
            Physics2D.IgnoreLayerCollision(9, 10);
            Vector2 throwDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            GameObject thrownPilliow = Instantiate(pillow, transform.position, Quaternion.identity);
            thrownPilliow.GetComponent<Rigidbody2D>().AddForce(throwDir.normalized * _throwForce);
            hasPillow = false;
        }

        

    }
    void Movement()
    {
        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime, rb.velocity.y);
        
        if(Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        
        
    }

    bool isGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeight, platformLayer);
        return raycastHit.collider != null;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Trigger")
        {
            Physics2D.IgnoreLayerCollision(9, 10, false);
            
        }

        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        bool spikes = false;
        string col = collider.gameObject.name;
        if(col.Length >= 6)
        {
            spikes = col.Substring(0, 6) == "Spikes";
        }
        if(col == "Shadow(Clone)" || spikes)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            _runtimeData.ClocksRemaining = 0;
            _runtimeData.playerMovements = new List<Vector3>();
            _runtimeData.spawnShadows = false;
        }
    }

    void OnDeath()
    {

    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.name == "Pillow(Clone)")
        {
            Vector2 dir = collider.gameObject.transform.position - transform.position;
            dir = dir.normalized;
            
            if(dir.y < 0 && Mathf.Abs(dir.x) <= .7)
            {
                rb.AddForce(new Vector2(0, _pillowForce));
                
            }
            else
            {
                Destroy(collider.gameObject);
                hasPillow = true;
            }
        }
        
        
        
    }
}
