using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedInk : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InklingMovement>() != null)
        {
            collision.gameObject.GetComponent<InklingMovement>().HP -= 0.005f;
        }
    }
}
