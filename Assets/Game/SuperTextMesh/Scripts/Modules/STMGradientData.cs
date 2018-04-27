using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class STMGradientData : object {

    public Gradient gradient;
    public GradientDirection direction = GradientDirection.Horizontal;
    public enum GradientDirection
    {
        Horizontal,
        Vertical
    }
    public bool smoothGradient = true;
}
