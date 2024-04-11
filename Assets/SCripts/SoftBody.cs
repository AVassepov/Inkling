using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    // Start is called before the first frame update


    public SpriteShapeController SpriteController;
    public Transform[] Points;


    private void Awake()
    {
        UpdatePoints();
    }

    private void Update()
    {
        UpdatePoints();
    }


    private void UpdatePoints()
    {
        for(int i = 0; i < Points.Length-1; i++) {
        Vector2  vertex =  Points[i].localPosition;

            Vector2 towardsCenter = (Vector2.zero - vertex).normalized;

            float colliderRadius = Points[i].gameObject.GetComponent<CircleCollider2D>().radius;

            SpriteController.spline.SetPosition(i, (vertex - towardsCenter * colliderRadius));



            Vector2 lt = SpriteController.spline.GetLeftTangent(i);

            Vector2 newRt = Vector2.Perpendicular(towardsCenter) * lt.magnitude;
            Vector2 newLt = Vector2.zero - (newRt);

            SpriteController.spline.SetRightTangent(i, newRt);
            SpriteController.spline.SetLeftTangent(i, newLt);

        }



    }


}
