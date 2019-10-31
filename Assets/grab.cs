using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public bool angkat;
    RaycastHit2D hit;
    public float jarak = 2f;
    public Transform hold;
    public LayerMask abot;
    public float deleh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if (!angkat)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, jarak);

                if (hit.collider != null && hit.collider.tag=="objek")
                {
                    angkat = true;

                }
            }
            else if(!Physics2D.OverlapPoint(hold.position, abot))
            {
                angkat = false;

                if(hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * deleh;
                }
            }
        }

        if (angkat)
        {
            hit.collider.gameObject.transform.position = hold.position;

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * jarak);
    }
}
