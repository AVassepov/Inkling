using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class InkSplat : MonoBehaviour
{


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InklingMovement>() != null) {
            collision.gameObject.GetComponent<InklingMovement>().HP += 0.0003f;
                
                }
    }


}
