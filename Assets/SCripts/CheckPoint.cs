using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] private GameObject Flag;

    private int FlagRaiseCounter = 0;
    private AudioSource audio;
    private bool unlockSound = false;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        Invoke("UnlockSound", 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InklingMovement>() != null)
        {
                PlayerPrefs.SetFloat("X", transform.position.x);
                PlayerPrefs.SetFloat("Y", transform.position.y);
            if (FlagRaiseCounter < 65)
            {
                InvokeRepeating("RaiseFlag", 0.0f, 0.01f);
                if(unlockSound)
                {
                    audio.Play();
                }
            }
        }
    }


    private void RaiseFlag()
    {
        Flag.transform.position = new Vector2(Flag.transform.position.x, Flag.transform.position.y +0.5f);
        FlagRaiseCounter++;

            if(FlagRaiseCounter > 65)
            {
                CancelInvoke();
            }
    }

    private void UnlockSound()
    {
        unlockSound = true;
    }
}

