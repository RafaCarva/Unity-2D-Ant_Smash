using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    private Animator myAnimator;

    [SerializeField] private GameObject[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        sprites[0] = this.transform.GetChild(0).gameObject; // Esse é o filho que tem o sprite da formiga viva.
        sprites[1] = this.transform.GetChild(1).gameObject;
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

    public void Dead()
    {
        speed = 0f;
        sprites[0].gameObject.SetActive(false);
        sprites[1].gameObject.SetActive(true);
        Destroy(this.gameObject, Random.Range(2.5f, 5f));
    }

}
