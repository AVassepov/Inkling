using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{

   [SerializeField] private GameObject Bar;

    private float Xscale;
    private InklingMovement player;
    private Vector3 InitialPosition;

    private void Awake()
    {
        player = FindObjectOfType<InklingMovement>();
        Xscale = Bar.transform.localScale.x;
        InitialPosition = Bar.transform.localPosition;
    }
    void Update()
    {

        Bar.transform.localScale = new Vector3(Xscale * player.HP, Bar.transform.localScale.y, 1);
        Bar.transform.localPosition = new Vector3(InitialPosition.x - (Xscale - Xscale * player.HP)/2, InitialPosition.y, 0); ;

    }
}
