using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winscript : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigidbody2D;    
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.y = position.y - Time.deltaTime * speed;
        
        rigidbody2D.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {

                controller.ChangeWin(-1);
                Destroy(gameObject);

        }
    }
}