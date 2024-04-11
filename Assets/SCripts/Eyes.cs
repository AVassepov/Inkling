using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private GameObject FollowTarget;


    [SerializeField] private GameObject[] EyeInstances;

    private AudioSource audio;

    [SerializeField] private Sprite RegularEyes;
    [SerializeField] private Sprite JumpEyes;
    [SerializeField] private Sprite Blinking;


    public bool queingBlink;
    public bool crouching;

    // Start is called before the first frame update
    void Start()
    {
        FollowTarget.GetComponent<InklingMovement>().SavedEyes = this;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FollowTarget.transform.position;

        if(!queingBlink )
        {
            queingBlink = true;
            Invoke("Blink", 10f);
        }
    }


    public void Jumping()
    {
        for (int i = 0; i < EyeInstances.Length; i++)
        {
            EyeInstances[i].GetComponent<SpriteRenderer>().sprite = JumpEyes;
        }
        audio.Play();
       Invoke("OpenEyes", 1f);
    }



    public void OpenEyes()
    {
        for (int i = 0; i < EyeInstances.Length; i++)
        {
            EyeInstances[i].GetComponent<SpriteRenderer>().sprite = RegularEyes;
        }

    }
    public void CloseEyes()
    {
        for (int i = 0; i < EyeInstances.Length; i++)
        {
            EyeInstances[i].GetComponent<SpriteRenderer>().sprite = Blinking;
        }

    }

    private void Blink()
    {
        for (int i = 0; i < EyeInstances.Length; i++)
        {
            EyeInstances[i].GetComponent<SpriteRenderer>().sprite = Blinking;
        }

        if(!crouching) {
            Invoke("OpenEyes", 0.3f);
        }
        queingBlink = false;
    }
}
