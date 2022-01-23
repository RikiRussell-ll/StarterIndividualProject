using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    Animator animator;
    public float heartnumber;
    bool hearted = false;
    public ParticleSystem waterEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.currentHealth < heartnumber)
        {    
        if (hearted == false)
            {
                
                animator.SetBool("hearts", true);
                Debug.Log("sup");
                hearted = true;
            }
        }
    }

}