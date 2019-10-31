using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float dash;
    public Transform ground;
    float key = 0.5f;
    public LayerMask grLayer;
    BoxCollider2D kotak;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        kotak = transform.GetComponent<BoxCollider2D>();
    }

    private bool Grounded()
    {
        RaycastHit2D rc = Physics2D.BoxCast(kotak.bounds.center, kotak.bounds.size, 0f, Vector2.down, .1f, grLayer);
        Debug.Log(rc.collider);
        return rc.collider != null;
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            float cepet = Input.GetAxisRaw("Horizontal") * dash;
            Vector2 mboh = new Vector2(cepet, 0);
            rb.AddForce(mboh * dash);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal") * speed;
        Vector2 obah = new Vector2(move, 0);
        rb.AddForce(obah * speed);
        if(Grounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * speed;
        }
        Dash();
    }
}
