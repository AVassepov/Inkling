using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InklingMovement : MonoBehaviour
{
    public float HP = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 CurrentDirection;

    private AudioSource audio;
    public Eyes SavedEyes;
    public List<GameObject> overlapped;
    public Vector3 RespawnPosition;
    private bool canJump = false;
    public Vector3 GlobalPositionOfContact;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Crouch();
        }else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) { 
            SavedEyes.OpenEyes();
            SavedEyes.crouching = false;
        }



        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (CurrentDirection.x < 1)
            {
                CurrentDirection.x += 0.01f;
            }

            move(CurrentDirection);

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (CurrentDirection.x > -1)
            {
                CurrentDirection.x -= 0.01f;
            }

            move(CurrentDirection);

        }
        else
        {
            CurrentDirection.x = 0;
            rb.velocity =new  Vector2(rb.velocity.x  +(- rb.velocity.x/100), rb.velocity.y);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump && GlobalPositionOfContact!= new Vector3(0,0,0))
        {
            Jump();
        }


        rb.AddForce(Vector2.down * 2);


        if(overlapped.Count != 0)
        {
            if (!CheckInkness())
            {
                HP -= 0.0001f;
            }
        }


        if (HP < 0)
        {

            print("Died");
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    private  void move(Vector2 Direction)
    {

        if(GlobalPositionOfContact != new Vector3(0, 0, 0))
        {
            rb.velocity = new Vector2(Direction.x *60, rb.velocity.y);

        }
        else
        {
            rb.velocity = new Vector2(Direction.x *100, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if(GlobalPositionOfContact.normalized.y > 0.9f)
        {

            rb.AddForce(-GlobalPositionOfContact.normalized * 35, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(-GlobalPositionOfContact.normalized *80, ForceMode2D.Impulse);
        }
        GlobalPositionOfContact = new Vector3(0,0,0);

        SavedEyes.Jumping();
        canJump = false;
    }

    private void Crouch()
    {
        rb.AddForce(Vector2.down * 25);
        SavedEyes.CloseEyes();

        SavedEyes.crouching = true;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlapped.Add(collision.gameObject);

        canJump = true;

        if (collision != null && collision.tag == "InkWell")
        {
            FindObjectOfType<Pen>().InkCounter++;
            FindObjectOfType<Pen>().UpdateUI();
            overlapped.Remove(collision.gameObject);
           Destroy(collision.gameObject);
            audio.Play();

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overlapped.Remove(collision.gameObject);

    }

    private bool CheckInkness()
    {
        for (int i = 0; i < overlapped.Count; i++)
        {
            if (overlapped[i].GetComponent<InkSplat>() != null)
            {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GlobalPositionOfContact = collision.contacts[0].point - (Vector2)transform.position;
        print(GlobalPositionOfContact.normalized);
    }


    private void OnApplicationQuit()
    {

        PlayerPrefs.SetFloat("X", 0);
        PlayerPrefs.SetFloat("Y", 0);
    }
}
