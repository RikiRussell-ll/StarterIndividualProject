using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear1 : MonoBehaviour
{
    //timer code
    public float changeTime = 3.0f;
    float timer;

    //motion
    public float speed;
    public float speedup;
    public float speedup2;
    Rigidbody2D rigidbody2D;
        
    // Start is called before the first frame update
void Start()
        {
            timer = changeTime;
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

    void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 1.1f)
                {
                    Vector2 position = rigidbody2D.position;
                    position.x = position.x - Time.deltaTime * speedup;
                    rigidbody2D.MovePosition(position);
                }
            if (timer < 1.05f)
                {
                    Vector2 position = rigidbody2D.position;
                    position.x = position.x + Time.deltaTime * speedup2;
                    rigidbody2D.MovePosition(position);
                }
            if (timer < 1.0f)
                {
                    Vector2 position = rigidbody2D.position;
                    position.x = position.x + Time.deltaTime * speed;
                    rigidbody2D.MovePosition(position);
                }
            if (timer < 0)
                {
                    Destroy(gameObject);
                }
        }
}

