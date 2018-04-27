//Copyright (c) 2016 Kai Clavier [kaiclavier.com] Do Not Distribute
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq; //converting arrays to dictionaries
using System.IO; //for getting folders
///NOTE: only re-create STMTextInfo if RAW TEXT changes
#if UNITY_EDITOR
using UnityEditor; //for loading default stuff and menu thing
#endif
[System.Serializable]
public class STMTextInfo{
	public CharacterInfo ch; //contains uv data, point size (quality), style, etc
	public Vector3 pos; //where the bottom-left corner is
	public float readTime = -1f; //at what time it will start to get read.
	public float unreadTime = -1f;
	public int line = 0; //what line this text is on
	public float indent = 0f; //distance from left-oriented margin that a new row will start from
	public float size; //localspace size
	public SuperTextMesh.Alignment alignment; //how this text will be aligned
	public SuperTextMesh.DrawOrder drawOrder;
	public List<string> ev = new List<string>(); //event strings.
	public List<string> ev2 = new List<string>(); //repeating event strings.
	public STMColorData colorData; //reference or store...
	public STMWaveData waveData;
	public float readDelay = 0f; //delay between lettes, for setting up timing
	public bool stopPreviousSound;
	public float overridePitch;
	public float minPitch;
	public float maxPitch;
	public float speedReadPitch;
	public STMFontData fontData;
	public STMQuadData quadData;
    public STMGradientData gradientData; //reference stuff??

    public Vector3 TopLeftVert{ //return position in local space
		get{
			return RelativePos( new Vector3(ch.minX, ch.maxY, 0f) ); 
		}
	}
	public Vector3 TopRightVert{ //return position in local space
		get{
			return RelativePos( new Vector3(ch.maxX, ch.maxY, 0f) );
		}
	}
	public Vector3 BottomRightVert{ //return position in local space
		get{
			return RelativePos( new Vector3(ch.maxX, ch.minY, 0f) );
		}
	}
	public Vector3 BottomLeftVert{ //return position in local space
		get{
			return RelativePos( new Vector3(ch.minX, ch.minY, 0f) );
		}
	}
	public Vector3 Middle{
		get{
			return RelativePos( new Vector3((ch.minX + ch.maxX) * 0.5f, (ch.minY + ch.maxY) * 0.5f, 0f) );
		}
	}
	public Vector3 RelativePos(Vector3 yeah){
		return pos + yeah * (size / ch.size); //ch.size is quality
	}
	public Vector3 RelativePos2(Vector3 yeah){ //for quads
		return pos + yeah * size; //ch.size is quality
	}
	public Vector3 Advance(float extraSpacing, float myQuality){ //for getting letter position and autowrap data
		if(quadData != null){
			return new Vector3((quadData.size.x + quadData.advance) + (extraSpacing * size), 0,0) * (size);
		}else{
			return new Vector3(ch.advance + (extraSpacing * size), 0,0) * (size / myQuality);
		}
	}
	public STMTextInfo(SuperTextMesh stm){ //for setting "defaults"
		this.ch.style = stm.style;
		this.indent = 0;
		this.size = stm.size;
		this.alignment = stm.alignment;
		this.drawOrder = stm.drawOrder;
	}

	public STMTextInfo(STMTextInfo clone, CharacterInfo ch) : this(clone){ //clone everything but character. used for auto hyphens
		this.ch = ch;
		this.quadData = null; //yeah or else it gets weird. it's gonna be a hyphen/space so whatever!!
	}
	
	public STMTextInfo(STMTextInfo clone){
		this.ch = clone.ch;
		this.pos = clone.pos;
		this.line = clone.line;
		this.indent = clone.indent;
		this.ev = new List<string>(clone.ev);
		this.ev2 = new List<string>(clone.ev2);
		this.colorData = clone.colorData;
		this.size = clone.size;
		this.waveData = clone.waveData;
		this.alignment = clone.alignment;
		this.readTime = clone.readTime;
		this.unreadTime = clone.unreadTime;
		this.stopPreviousSound = clone.stopPreviousSound;
		this.overridePitch = clone.overridePitch;
		this.minPitch = clone.minPitch;
		this.maxPitch = clone.maxPitch;
		this.speedReadPitch = clone.speedReadPitch;
		this.readDelay = clone.readDelay;
		this.drawOrder = clone.drawOrder;
		this.fontData = clone.fontData;
		this.quadData = clone.quadData;
        this.gradientData = clone.gradientData;
	}
}

