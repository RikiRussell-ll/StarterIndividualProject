using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidBalloonsScript : MonoBehaviour
{
    //timer code
    public float changeTime = 3.0f;
    float timer;

    //motion
    public float speed;
    public float speedup;
    public float speedup2;
    Rigidbody2D rigidbody2D;

    //ranges for spawn
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float balloonamount;


    public GameObject balloon;
    public GameObject winborder;
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
                    position.y = position.y + Time.deltaTime * speedup;
                    rigidbody2D.MovePosition(position);
                }
            if (timer < 1.05f)
                {
                    Vector2 position = rigidbody2D.position;
                    position.y = position.y - Time.deltaTime * speedup2;
                    rigidbody2D.MovePosition(position);
                }
            if (timer < 1.0f)
                {
                    Vector2 position = rigidbody2D.position;
                    position.y = position.y - Time.deltaTime * speed;
                    rigidbody2D.MovePosition(position);
                }
            if (timer < 0)
                {
                    Destroy(gameObject);
                }

                
        }

    void OnDestroy()
        {
            for (int i = 0; i < balloonamount; i++)
            {
                float spawnY = Random.Range
                    (yMin,yMax);
                float spawnX = Random.Range
                    (xMin,xMax);
     
                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                Instantiate(balloon, spawnPosition, Quaternion.identity);
                Instantiate(winborder, new Vector3(0 * 2.0F, 105, 0), Quaternion.identity);
            }
        }
}
