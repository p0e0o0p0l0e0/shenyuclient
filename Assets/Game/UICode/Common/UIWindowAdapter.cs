using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowAdapter : MonoBehaviour {
    public float HORIZONTAL_SIZE = 71;
    public float VERTICAL_SIZE = 17;
    [System.Serializable]
    public struct MoveObject
    {
        public RectTransform rect;
        public MoveDir direction;
    }
    public enum MoveDir
    {
        MoveLeft = 1,
        MoveRight = 2,
        MoveUp = 4,
        MoveDown = 8,
        MoveDownLeft = 9,
        MoveDownRight = 10,
        MoveUpLeft = 5,
        MoveUpRight = 6 
    }
    public MoveObject[] ToMoveObject;

    public void AdjustPostion()
    {
        {
            if(ToMoveObject!= null)
                foreach (MoveObject m in ToMoveObject)
                {
                    switch (m.direction)
                    {
                        case MoveDir.MoveRight:
                            m.rect.localPosition += new Vector3(HORIZONTAL_SIZE, 0, 0);
                            break;
                        case MoveDir.MoveLeft:
                            m.rect.localPosition += new Vector3(-HORIZONTAL_SIZE, 0, 0);
                            break;
                        case MoveDir.MoveUp:
                            m.rect.localPosition += new Vector3(0, VERTICAL_SIZE, 0);
                            break;
                        case MoveDir.MoveDown:
                            m.rect.localPosition += new Vector3(0, -VERTICAL_SIZE, 0);
                            break;
                        case MoveDir.MoveDownLeft:
                            m.rect.localPosition += new Vector3(-HORIZONTAL_SIZE, -VERTICAL_SIZE, 0);
                            break;
                        case MoveDir.MoveDownRight:
                            m.rect.localPosition += new Vector3(HORIZONTAL_SIZE, -VERTICAL_SIZE, 0);
                            break;
                        case MoveDir.MoveUpLeft:
                            m.rect.localPosition += new Vector3(-HORIZONTAL_SIZE, VERTICAL_SIZE, 0);
                            break;
                        case MoveDir.MoveUpRight:
                            m.rect.localPosition += new Vector3(HORIZONTAL_SIZE, -VERTICAL_SIZE, 0);
                            break;
                    }
                }
        }

    }

}
