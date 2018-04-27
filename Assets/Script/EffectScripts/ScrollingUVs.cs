using UnityEngine;
using System.Collections;

public class ScrollingUVs : MonoBehaviour 
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
    public string textureName = "_MainTex";
    public string textureName1 = "";
    Vector2 uvOffset = Vector2.zero;

    Material[] mats = null;

    void Awake()
    {
        mats = GetComponent<Renderer>().materials;
    }


    void LateUpdate() 
    {
        uvOffset += ( uvAnimationRate * Time.deltaTime );
        if( GetComponent<Renderer>().enabled )
        {
            mats[materialIndex].SetTextureOffset(textureName, uvOffset);
            if (textureName1.CompareTo("") != 0)
            {
                mats[materialIndex].SetTextureOffset(textureName1, uvOffset);
            }
        }
    }
}
