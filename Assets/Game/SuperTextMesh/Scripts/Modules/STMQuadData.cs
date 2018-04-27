//Copyright (c) 2016 Kai Clavier [kaiclavier.com] Do Not Distribute
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class STMQuadData//: ScriptableObject
{
    [Tooltip("If a quad is a silhouette, it won't use the color from its texture, just the alpha. If it's a silhouette, it can be effected by text color.")]
    public bool silhouette = false;
	public Vector2 size = Vector2.one; //1,1 means full width & height of a normal letter. determines spacing.
	public Vector3 offset = Vector3.zero;
	public float advance; //spacing afterwards...?
    public string SpriteName;
    public UIAtlas Atlas;
    public Vector3 TopLeftVert{ //shorthand for the corners
		get{
			return new Vector3(0f, size.y, 0f) + offset; 
		}
	}
	public Vector3 TopRightVert{ //shorthand for the corners
		get{
			return new Vector3(size.x, size.y, 0f) + offset;
		}
	}
	public Vector3 BottomRightVert{ //shorthand for the corners
		get{
			return new Vector3(size.x, 0f, 0f) + offset;
		}
	}
	public Vector3 BottomLeftVert{ //shorthand for the corners
		get{
			return new Vector3(0f, 0f, 0f) + offset;
		}
	}

	public Vector2 UvTopLeft(float myTime){ 
		return new Vector2(0f, uvSize.y) + UvOffset(myTime); 
	}
	public Vector2 UvTopRight(float myTime){ 
		return uvSize + UvOffset(myTime);
	}
	public Vector2 UvBottomRight(float myTime){ 
		return new Vector2(uvSize.x, 0f) + UvOffset(myTime);
	}
	public Vector2 UvBottomLeft(float myTime){ 
		return UvOffset(myTime);
	}
	private Vector2 uvSize {
        get {
            UISpriteData spriteData = Atlas.GetSprite(this.SpriteName);

            if (spriteData != null)
            {
                Vector2 size = new Vector2( spriteData.width * 1.0f / TextureSize.x, spriteData.height * 1.0f / TextureSize.y);
                return size;
            }
            return Vector2.zero ;
        }
	}
    private Vector2 TextureSize
    {
        get
        {
            Texture texture = null;
            texture = Atlas.texture;
            
            if (texture != null)
                return new Vector2(texture.width, texture.height);
            return Vector2.zero;
        }
    }
	private Vector2 UvOffset(float myTime){
        //convert UV from spriteData
        if (!string.IsNullOrEmpty(SpriteName))
        {

            UISpriteData spriteData = Atlas.GetSprite(SpriteName);
            Texture texture = Atlas.texture;

            if (spriteData != null)
            {
                int width = spriteData.width;
                int height = spriteData.height;
                float x = spriteData.x;
                float y = spriteData.y;
                Vector2 uv = new Vector2(spriteData.x * 1.0f / texture.width, (texture.height - spriteData.height - spriteData.y) * 1.0f / texture.height);
                return uv;
            }
        }
        return Vector2.zero;
	}
}