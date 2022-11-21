using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimationSpeed();
    }

    private void Movement()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }

    private void AnimationSpeed()
    {
        myAnimator.SetFloat("Speed", speed);
    }

}
