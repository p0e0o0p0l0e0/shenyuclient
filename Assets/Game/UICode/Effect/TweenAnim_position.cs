using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TweenAnim_position : TweenPosition
{
    public float MaxDistance = 2f;
    public float MinDistance = 1f;
    public Vector3 Dir = Vector3.zero;


    [Header("随机偏移最大角度")]
    public int MaxOffsetAngle = 0;

    [HideInInspector]
    public bool OffsetFlag { get; set; } 
   
    public new void PlayForward()
    {
        if (MaxOffsetAngle != 0)
        {
            float angle = Vector3.Angle(Vector3.right, Dir);
            int offset = 0;
            if(OffsetFlag)
                offset = Random.Range(-MaxOffsetAngle, 0);
            else
                offset = Random.Range(0, MaxOffsetAngle);
            float newAngle = angle + offset;
            if (newAngle >= 0 && newAngle <= 180)
            {
                Dir = Quaternion.Euler(0f, 0f, offset) *Dir;
            }
            
        }
        Dir.Normalize();
        MaxDistance = (MaxDistance >= MinDistance? MaxDistance: MinDistance);
        this.to = this.from + Dir * Mathf.Lerp(MinDistance, MaxDistance, Random.Range(0, 10) * 0.1f);
        base.PlayForward();
    }
    [ContextMenu("Review")]
    void Review()
    {
        Vector3 oldDir = Dir;
        PlayForward();
        Dir = oldDir;
        OffsetFlag = !OffsetFlag;
    }
}
