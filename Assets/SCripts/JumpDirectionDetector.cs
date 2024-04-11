using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDirectionDetector : MonoBehaviour
{
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<InklingMovement>().GlobalPositionOfContact = collision.contacts[0].point - (Vector2)transform.position;
    }
}
           