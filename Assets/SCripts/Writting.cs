using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Writting : MonoBehaviour
{
   private  AudioSource audio;

    private bool AlreadyWritten;
    private Color saved;
    private TextMesh textmesh;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        textmesh = GetComponent<TextMesh>();
        saved = textmesh.color;
        textmesh.color = new Color(0, 0, 60, 0);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!AlreadyWritten && collision.GetComponent<InklingMovement>() != null)
        {

            textmesh.color = saved;
            audio.Play();
            AlreadyWritten = true;
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
