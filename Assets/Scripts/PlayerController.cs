using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    //speed value
    public float speed_sprint;
    public float speed_default;

    //health value
    public int maxHealth = 3;
    public static int currentHealth;
    public int health { get { return currentHealth; }}

    public int maxwincon = 1;
    public static int wincon;
    public int winner { get { return wincon; }}

    //game over and win screens
    public GameObject youlose;
    public GameObject youwin;

    //audio
    AudioSource audioSource;
    public AudioSource music1;
    public AudioSource music2;
    public AudioClip hitsound;
    //particles
    public ParticleSystem waterEffect;

    //timer
    public float changeTime = 3.0f;
    float timer;

    void Start()
    {
        
        rigidbody2d = GetComponent<Rigidbody2D>();

        //time
        timer = changeTime;
        
        audioSource = GetComponent<AudioSource>();

        music1.Play();

        //health default set
        currentHealth = maxHealth;
        wincon = maxwincon;

        speed_sprint = 24f;
        speed_default = 8f;
    }
 
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        timer -= Time.deltaTime;

       //dash code
       if(Input.GetKey(KeyCode.LeftShift))
       {
           speed_default = speed_sprint;
       }
 
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed_default = 8f;
        }
        if (timer < 0.1f)
            {
                if (music1.isPlaying)
                {
                    music1.Stop();
                    music2.Play();
                }
            }
       
    }
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed_default * horizontal * Time.deltaTime;
 
        rigidbody2d.MovePosition(position);
    }

    //health
    public void ChangeHealth(int amount)
    {
        PlaySound(hitsound);
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        Instantiate(waterEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        if (currentHealth == 0)
            {
                Instantiate(youlose, new Vector3(0 * 2.0F, 0, -5), Quaternion.identity);
                Destroy(gameObject);
                music2.Stop();
            }
    }
    public void ChangeWin(int amount)
    {
        wincon = Mathf.Clamp(wincon + amount, 0, maxwincon);
        Debug.Log(wincon + "/" + maxwincon);
        if (wincon == 0)
        {
            Instantiate(youwin, new Vector3(0 * 2.0F, 0, -5), Quaternion.identity);
            Destroy(gameObject);
            music2.Stop();
        }
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
 
 
