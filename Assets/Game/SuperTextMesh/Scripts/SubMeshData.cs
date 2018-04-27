using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubMeshData
{ 
    public List<int> tris = new List<int>();
    public Font refFont; //maybe make these FontData, TextureData, ShaderData?
    public Texture refTex; //for quads/inline images

    public SubMeshData(SuperTextMesh stm)
    { //create default
        this.refFont = stm.font;
    }
}
