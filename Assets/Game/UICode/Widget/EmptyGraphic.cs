﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyGraphic : Graphic
{
    public override void SetMaterialDirty()
    {
    }

    public override void SetVerticesDirty()
    {
    }

    //protected override void OnFillVBO(List<UIVertex> vbo)
    //{
    //    vbo.Clear();
    //}
}