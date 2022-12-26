using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetected : MonoBehaviour
{
    private bool tapControl;
    private Enemy enemy;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectTap();
    }

    private void DetectTap()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);

            if(hit.collider != null)
            {
                TapObject(hit);
                tapControl = false;
            }
        }
    }

    private void TapObject(RaycastHit2D hit)
    {
        if(hit.collider.gameObject.CompareTag("Enemy") && !tapControl)
        {
            tapControl = true;
            hit.collider.gameObject.GetComponent<Enemy>().Dead();
            hit.collider.gameObject.GetComponent<Enemy>().PlayAudio(tapControl);
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log(hit.transform.name);
        }
    }
}
