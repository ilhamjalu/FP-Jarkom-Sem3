using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak : MonoBehaviour
{

    public float speed;
    public GameObject game;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game.gameObject.CompareTag("square2"))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
