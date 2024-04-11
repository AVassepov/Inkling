using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInkling : MonoBehaviour
{


    private Rigidbody2D rb;
    private Eyes eyes;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        eyes = FindObjectOfType<Eyes>();
        Invoke("Jump", 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.down * 10);
    }



    void Jump()
    {
        rb.AddForce(Vector2.up * 120 , ForceMode2D.Impulse);
;   eyes.Jumping();

        Invoke("Jump", 2);

        
    }
}
