using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    //timer code
    public float changeTime = 3.0f;
    float timer;

    //motion
    public float speed;
    bool motion = true;

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
            if (timer < 0)
                {
                    motion = false;
                    rigidbody2D.simulated = false;
                }
            if (timer < 0.5f)
                {
                    if (motion = true)
                    {
                    Vector2 position = rigidbody2D.position;
                    position.x = position.x + Time.deltaTime * speed;
                    rigidbody2D.MovePosition(position);
                    }
                }
            //reset code 
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }

        }
}

