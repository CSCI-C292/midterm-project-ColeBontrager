using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    BoxCollider2D bc;
    [SerializeField] LayerMask platformLayer;
    bool collision;
    // Start is called before the first frame update
    void Start()
    {
        collision = false;
        bc = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isGrounded()
    {
        float extraHeight = .05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeight, platformLayer);
        return raycastHit.collider != null;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name != "Player")
        {
            collision = true;
        }

        if(collider.gameObject.name == "Shadow(Clone)")
        {
            if(!isGrounded() || GetComponent<Rigidbody2D>().velocity.x != 0)
            {
                Destroy(collider.gameObject);
            }
            
        }
        
        
    }
}
