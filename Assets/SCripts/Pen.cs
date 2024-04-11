using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pen : MonoBehaviour
{
    public List<GameObject> SplatOptions;
    [SerializeField] private TextMesh UsesLeftUI;
    public bool canPaint = false;

    public List<GameObject> overlapped;

    public int InkCounter = 10;

    private AudioSource audio;


 /*   public LineRenderer lineRenderer;
    public int linePointCounter;

    public LineRenderer CurrentLineRender;


    public int pointFrameDelay = 3;
    public int pointFrameCounter = 0;*/
    // Start is called before the first frame update
    void Start()
    {
        /*        lineRenderer.useWorldSpace = true;
                lineRenderer.enabled = false;
                lineRenderer.positionCount = 100;

                CurrentLineRender = lineRenderer;*/
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && canPaint)
        {
            SplashInk();

        }




  /*      if(lineRenderer != null && Input.GetKey(KeyCode.Mouse0))
        {
            if (pointFrameCounter < pointFrameDelay)
            {
                pointFrameCounter++;
            }
            else
            {
                AddPoint();
                pointFrameCounter = 0;
            }
        }else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CurrentLineRender = gameObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
            CurrentLineRender.material = lineRenderer.material;
            CurrentLineRender.useWorldSpace = true;
            CurrentLineRender.enabled = false;
            CurrentLineRender.positionCount = 100;
        }
       */



    }


    private void SplashInk()
    {
        GameObject temp=Instantiate(SplatOptions[Random.Range(0,SplatOptions.Count)], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0), Quaternion.identity);

        temp.transform.localScale *=  Random.Range(0.9f , 1.1f);
        audio.Play();
        float RandomRotation = Random.Range(0f, 360);
        temp.transform.GetChild(0).rotation = new Quaternion(temp.transform.rotation.x, temp.transform.rotation.y, RandomRotation, Random.Range(0f, 360));
        InkCounter--;
        UpdateUI();
        if (InkCounter == 0)
        {
            canPaint = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlapped.Add(collision.gameObject);

        canPaint = false;
        for (int i = 0; i < overlapped.Count; i++)
        {
            if (overlapped[i].tag == "Inkable" && InkCounter> 0)
            {
                canPaint = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        overlapped.Remove(collision.gameObject);

        canPaint = false;
        for (int i = 0; i < overlapped.Count; i++)
        {
            if (overlapped[i].tag == "Inkable" && InkCounter > 0)
            {
                canPaint = true;
            }
        }
    }

    /*
        void AddPoint()
        {
            if (linePointCounter < CurrentLineRender.positionCount)
            {
                CurrentLineRender.enabled = true;
                CurrentLineRender.SetPosition(linePointCounter, new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, 0));
                for (int i = linePointCounter; i < 100; i++)
                {
                    CurrentLineRender.SetPosition(i, new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, 0));
                }

                linePointCounter++;

            }
        }*/

  public  void UpdateUI()
    {

        UsesLeftUI.text = InkCounter.ToString();
    }
}
