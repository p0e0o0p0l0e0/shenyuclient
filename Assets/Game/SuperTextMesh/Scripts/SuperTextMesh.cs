using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; //for loading default stuff and menu thing
#endif
using System.Linq; //for sorting inspector stuff by creation date, and removing doubles from lists
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;

[AddComponentMenu("Mesh/Super Text Mesh", 3)] //allow it to be added as a component
[ExecuteInEditMode]
[DisallowMultipleComponent]
public class SuperTextMesh : MonoBehaviour , IMaskable
{ //MaskableGraphic... rip
	//foldout bools for editor. not on the GUI script, cause they get forgotten
	private Transform _t;
	public Transform t{
		get{
			if(_t == null) _t = this.transform;
			return _t;
		}
	}
	private MeshFilter _f;
	public MeshFilter f{
		get{
			if(_f == null) _f = t.GetComponent<MeshFilter>();
			if(_f == null) _f = t.gameObject.AddComponent<MeshFilter>();
			return _f;
		}
	}
    public bool isUIMode = false;
    public bool _isMask = false;
    private MeshRenderer _r;
	public MeshRenderer r{
		get{
			if(_r == null)
                _r = t.GetComponent<MeshRenderer>();
			if(_r == null)
                _r = t.gameObject.AddComponent<MeshRenderer>();
			return _r;
		}
	}
	private CanvasRenderer _c;
	public CanvasRenderer c{
		get{
			if(_c == null) _c = t.GetComponent<CanvasRenderer>();
			if(_c == null) _c = t.gameObject.AddComponent<CanvasRenderer>();
			return _c;
		}
	}
	private List<STMTextInfo> info = new List<STMTextInfo>(); //switching this out for an array & using temp lists makes less appear in the deep profiler, but has no effect on GC
	private List<int> lineBreaks = new List<int>(); //what characters are line breaks
	[TextArea(3,10)] //[Multiline] also works, but i like this better
	[UnityEngine.Serialization.FormerlySerializedAs("text")]
	public string _text = "";
	public string text{
		get{
			return this._text;
		}
		set{
			this._text = value;
            //this.RequestAllCharacters();
			//Rebuild(); //auto-rebuild//rebuild给上层管理调用
		}
	}
	public string Text{ //legacy fix since v1.6
		get{ //just do the same as text
			return text;
		}
		set{
			text = value;
		}
	}
	[HideInInspector] public string drawText; //text, after removing junk
	[HideInInspector] public string hyphenedText; //text, with junk added to it
	public Font font;
	public Color32 color = Color.white;
	public bool richText = true; //care about formatting like <b>?
	public DrawOrder undrawOrder = DrawOrder.AllAtOnce;
	public float size = 1f; //size of letter in local space! not percentage of quality. letters can have diff sizes individually
	[Range(1,500)]
	public int quality = 64; //actual text size. point size
	public FilterMode filterMode = FilterMode.Bilinear;
	public FontStyle style = FontStyle.Normal;
	public Vector3 baseOffset = Vector3.zero; //for offsetting z, mainly
	public float lineSpacing = 1.0f;
	public float characterSpacing = 0.0f;
	public float tabSize = 4.0f;
    public float autoWrap = 2f; //if text on one row exceeds this, insert line break at previously available space
    public UIAtlas Atlas = null;
	private float AutoWrap{ //get autowrap limit OR ui bounds
		get{
			return autoWrap;
		}
	}

	public bool wrapText = true; 
	public bool breakText = true;
	public bool insertHyphens = true;
	public TextAnchor anchor = TextAnchor.UpperLeft;
	public Alignment alignment = Alignment.Left;
	public enum Alignment{
		Left,
		Center,
		Right,
		Justified,
		ForceJustified
	}
	public int lineCountLimit = 0;
	public Mesh textMesh; //keep track of mesh

	[HideInInspector] public Vector3 rawTopLeftBounds;
	[HideInInspector] public Vector3 rawBottomRightBounds;

	[HideInInspector] public Vector3 topLeftBounds;
	[HideInInspector] public Vector3 topRightBounds;
	[HideInInspector] public Vector3 bottomLeftBounds;
	[HideInInspector] public Vector3 bottomRightBounds;
	[HideInInspector] public Vector3 centerBounds;
	public bool modifyVertices = false;
	public bool debugMode = false; //pretty much just here to un-hide inspector stuff

	[HideInInspector] public float totalReadTime = 0f;
	[HideInInspector] public float totalUnreadTime = 0f;
	[HideInInspector] public float currentReadTime = 0f; //what position in the mesh it's currently at. Right now, this is just so jitters don't animate more than they should when you speed past em.

	//generate these with ur vert calls or w/e!!!
	private Vector3[] endVerts = new Vector3[0];
	private Color32[] endCol32 = new Color32[0];
	//private int[] endTriangles = new int[0];
	private Vector2[] endUv = new Vector2[0];
	private Vector2[] endUv2 = new Vector2[0]; //overlay images
    private Vector2[] endUv3 = new Vector2[0];
	private Vector3[] startVerts = new Vector3[0];
	private Color32[] startCol32 = new Color32[0];
    private float _alpha = 1f;

    public float Alpha
    {
        get
        {
            return _alpha;
        }
        set
        {
            if (!(_alpha >= value + float.MinValue && _alpha <= value + float.MinValue))
            {
                _alpha = value;
                _UpdateVertexAlpha();
            }
                
        }
    }

	private List<SubMeshData> subMeshes = new List<SubMeshData>();

	public enum DrawOrder{
		LeftToRight,
		AllAtOnce,
		OneWordAtATime,
		Random,
		RightToLeft,
		ReverseLTR
	}
	public DrawOrder drawOrder = DrawOrder.LeftToRight;
	private int pauseCount = 0; //for <pause>. total amount of <pause>s that were reached while reading multiple times
	private int currentPauseCount = 0; //amount of pauses found this rebuild cycle
    //是否使用自带的整体渐变,否则解析字符串里面的渐变
    public Gradient GradientColor = new Gradient();
    public bool IsUseGradientColor = false;
    public STMGradientData.GradientDirection CurGradientDirection = STMGradientData.GradientDirection.Vertical;

    public bool IsUseOutLine = false;
    public Color OutLineColor = Color.white;
    public Vector2 OutLineWidth = Vector2.zero;
    public float shaderOutLineWidth = 0;
    private bool _isDirty = false;
#if UNITY_EDITOR
    public Material editorMat;
#endif
    public enum OutLineType
    {
        MESH_CREATE,//采用4方向定点处理边框
        SHADER_CREATE, //使用shader8方向处理边框
    }
    public OutLineType outLineType = OutLineType.MESH_CREATE;

#if UNITY_EDITOR
    public static SuperTextManager stm = null;
#endif
	void OnDrawGizmosSelected(){ //draw boundsssss
		//if(autoWrap > 0f){ //bother to draw bounds?
			Gizmos.color = Color.blue;
			RecalculateBounds();
			Gizmos.DrawLine(topLeftBounds, topRightBounds); //top
			Gizmos.DrawLine(topLeftBounds, bottomLeftBounds); //left
			Gizmos.DrawLine(topRightBounds, bottomRightBounds); //right
			Gizmos.DrawLine(bottomLeftBounds, bottomRightBounds); //bottom
			//Gizmos.DrawSphere(centerBounds, 0.1f);
		//}
	}
	
	/// <summary>
	/// build 后，获取text的总高度值
	/// </summary>
	/// <returns></returns>
	public float GetSuperTextHeight()
	{
		return Vector3.Distance(topLeftBounds, bottomLeftBounds);
		
	}
	
	void OnFontTextureRebuilt(Font changedFont){
        if(font != null && changedFont.name == this.font.name)
            Rebuild();
    }

    void OnEnable()
    {
        Init();
    }
	void OnDisable(){
		UnInit();
	}
	void OnDestroy(){
		UnInit();
	}
	void Init(){
		Font.textureRebuilt += OnFontTextureRebuilt;
	}
	void UnInit(){
		Font.textureRebuilt -= OnFontTextureRebuilt;
	}

    [ContextMenu("Rebuild")]
	public void Rebuild(){
		Rebuild(0f, true);
	}
	public void Rebuild(float startTime){
		Rebuild(startTime, true);
	}
	public void Rebuild(float startTime, bool readAutomatically){
        if (string.IsNullOrEmpty(_text)) return;
		if(startTime < totalReadTime) pauseCount = 0; //only reset if reeading from the very start, not appending
		currentPauseCount = 0;
		currentReadTime = 0f;
		totalReadTime = 0f;
		RebuildTextInfo();
        SetMesh(-1f); //show nothing
        ApplyMaterials();
	}

	public int latestNumber = -1; //declare here as a public variable, so the current character drawn can be reached at any time
	public int lowestLine = 0; //lowest line being shown currently (number counts up)
	bool ValidHexcode (string hex){ //check if a hex code contains the right amount of characters, and allowed characters
		if(hex.Length != 3 && hex.Length != 4 && hex.Length != 6 && hex.Length != 8){ //hex code, alpha hex
			return false;
		}
		string allowedLetters = "0123456789ABCDEFabcdef";
		for(int i=0; i<hex.Length; i++){
			if(!allowedLetters.Contains(hex[i].ToString())){
				return false; //invalid string!!!
			}
		}
		return true;
	}
	Color32 HexToColor(string hex){ //convert a hex code string to a color
		if(hex.Length == 8){ //RGBA (FF00FF00)
			byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
			byte a = byte.Parse(hex.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r,g,b,a);
		}
		if(hex.Length == 4){ //single-byte for RGBA (F0F0)
			byte r = byte.Parse(hex.Substring(0,1) + hex.Substring(0,1), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(1,1) + hex.Substring(1,1), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(2,1) + hex.Substring(2,1), System.Globalization.NumberStyles.HexNumber);
			byte a = byte.Parse(hex.Substring(3,1) + hex.Substring(3,1), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r,g,b,a);
		}
		if(hex.Length == 3){ //single-byte for RGB (F0F)
			byte r = byte.Parse(hex.Substring(0,1) + hex.Substring(0,1), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(1,1) + hex.Substring(1,1), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(2,1) + hex.Substring(2,1), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r,g,b,255);
		}
		else{ //RGB (FF00FF)
			byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r,g,b,255);
		}
	}
	STMColorData GetColor(string myCol){
        if (ValidHexcode(myCol))
        { //might be a hexcode?
            STMColorData thisCol2 = new STMColorData();
            thisCol2.color = HexToColor(myCol);
            return thisCol2;
        }
        //still no?
        STMColorData thisCol = new STMColorData();
        switch (myCol)
        { //see if it's a default unity color
            case "red": thisCol.color = Color.red; break;
            case "green": thisCol.color = Color.green; break;
            case "blue": thisCol.color = Color.blue; break;
            case "yellow": thisCol.color = Color.yellow; break;
            case "cyan": thisCol.color = Color.cyan; break;
            case "magenta": thisCol.color = Color.magenta; break;
            case "grey": thisCol.color = Color.grey; break;
            case "gray": thisCol.color = Color.gray; break;
            case "black": thisCol.color = Color.black; break;
            case "clear": thisCol.color = Color.clear; break;
            case "white": thisCol.color = Color.white; break;
            default: thisCol.color = color; break; //default color of mesh
        }
        return thisCol;
	}
	string ParseText(string myText){
		info.Clear();

		STMTextInfo myInfo = new STMTextInfo(this); 
		for(int i=0; i<myText.Length; i++)
        { 
			bool checkAgain = false;

            if (IsUseGradientColor && this.GradientColor != null)//暂时处理整体渐变
            {
                myInfo.gradientData = new STMGradientData();
                myInfo.gradientData.gradient = this.GradientColor;
                myInfo.gradientData.direction = CurGradientDirection;
            }

            if (richText && myText[i] == '<'){ 
				int closingIndex = myText.IndexOf(">",i); 
				int equalsIndex = closingIndex > -1 ? myText.IndexOf("=",i, closingIndex-i) : -1;
				int endIndex = (equalsIndex > -1 && closingIndex > -1) ? Mathf.Min(equalsIndex,closingIndex) : closingIndex;//for figuring out what the "tag" is
				if(closingIndex != -1){//don't do anything if there's no closing tag at all
					string myTag = myText.Substring(i, endIndex-i+1); //this is the "TAG" like " =" or "<br>"
					string myString = equalsIndex > -1 ? myText.Substring(equalsIndex+1,closingIndex-equalsIndex-1) : "";//this is the "STRING" like "fire" or "blue"
					//Debug.Log("Found this tag: '" + myTag + "'! And this string: '" + myString + "'.");
					bool clearAfter = true;
					bool exitLoopAfter = false;
					string insertAfter = "";

                        switch (myTag){
					//Line Break
						case "<br>":
							insertAfter = '\n'.ToString(); //insert a line break
							break;
					//Color
						case "<c=":
							myInfo.colorData = null; //clear to default
                            if (!IsUseGradientColor)//暂时处理整体渐变
                            {
                                myInfo.colorData = GetColor(myString);
                            }
                            
                            break;
						case "</c>":
							myInfo.colorData = null; //clear to default
							break;
					//Size
						case "<s=":
							float thisSize;
							if(float.TryParse(myString, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out thisSize)){ //parse as a float
								myInfo.size = thisSize * size; //set size relative to the one set in inspector!
							}
							break;
						case "<size=":
							float thisSize2;
							if(float.TryParse(myString, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out thisSize2)){ //parse as a float
								myInfo.size = thisSize2; //set size directly!
							}
							break;
						case "</s>":
						case "</size>":
							myInfo.size = size;
							break;
					//Timing
						case "<t=":
							float thisTiming;
							if(float.TryParse(myString, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out thisTiming)){ //parse as a float
								if(thisTiming < 0f) thisTiming = 0f; //or else it'll cause a loop!
								myInfo.readTime = thisTiming; //set time to be this float
							}
							break;
						case "<q=":
						case "<quad=":
                            if (Atlas != null)
                            {
                                //if this letter doesn't already have quad data:
                                if (myInfo.quadData == null)
                                {
                                    STMQuadData quadData = this._MakeSTMQuadData(myString);
                                    insertAfter = "`"; //a character to get used for the quad, in hyphenedtext
                                    myInfo.quadData = quadData;
                                }
                            }
                            break;
                        case "<quadAnim=":
                            if (myInfo.quadData == null)
                            {
                                STMQuadAnimData stmQuadAnimData = STMQuadAnimManager.GetSTMQuadAnim(myString);
                                if (stmQuadAnimData != null)
                                {
                                    stmQuadAnimData.Owner = this;
                                    this.Atlas = stmQuadAnimData.Atlas;
                                    STMQuadData quadData = stmQuadAnimData.GetSTMQuadData(Time.deltaTime);
                                    insertAfter = "`"; //a character to get used for the quad, in hyphenedtext
                                    myInfo.quadData = quadData;

                                 }
                            }
                            break;
						case "<a=":
							switch(myString.ToLower()){ //not case sensitive, for some reason? why not
								case "left": myInfo.alignment = Alignment.Left; break;
								case "right": myInfo.alignment = Alignment.Right; break;
								case "center": case "centre": myInfo.alignment = Alignment.Center; break;
								case "just": case "justify": case "justified": myInfo.alignment = Alignment.Justified; break;
								case "just2": case "justify2": case "justified2": myInfo.alignment = Alignment.ForceJustified; break;
							}
							break;
						case "</a>":
							myInfo.alignment = alignment; //return to default for mesh
							break;
					//Default
						default:
							clearAfter = false;//DONT remove characters and do stuff
							break;
					}
					if(clearAfter){
						myText = myText.Remove(i,closingIndex+1-i);
						//Debug.Log("Removing '" + myText.Substring(i,closingIndex+1-i) + "'. The string is now: '" + myText + "'.");
						myText = myText.Insert(i,insertAfter);
						checkAgain = true;
					}
					if(exitLoopAfter){
						//keep track of last pause, and skip over it
						myText = myText.Remove(i,myText.Length-i); //remove everything after
						break;
					}
				}
			}
			if(info.Count - 1 == i){
				info[i] = new STMTextInfo(myInfo); //update older one, it was checking again
				//Debug.Log("Updating older character " + myText[i].ToString() + " to be " + info[i].style);
			}else{
				info.Add(new STMTextInfo(myInfo) ); //add new HAS TO BE NEW OR ELSE IT JUST REFERENCES
			}
			if(checkAgain){
				i--;
			}else{ //stuff that gets reset!! single-use tags.
				//myInfo.delayData = null;// reset
				myInfo.quadData = null;
				myInfo.ev.Clear();
				myInfo.readTime = -1f;
			}
		}
		return myText;
	}
    private STMQuadData _MakeSTMQuadData(string spritName)
    {
        STMQuadData quadData = new STMQuadData();
        quadData.SpriteName = spritName;
        quadData.Atlas = this.Atlas;
        return quadData;
    }
	int GetFontSize(Font myFont, STMTextInfo myInfo){ //so dynamic and non-dynamic fonts can be used together
		if(!myFont.dynamic && myFont.fontSize != 0){
			return myFont.fontSize; //always go w/ non-dynamic size first
		}
		if(myInfo.fontData != null){
			return myInfo.fontData.quality; //then set quality
		}
		if(myInfo.ch.size != 0){
			return myInfo.ch.size; //then natural quality
		}
		return quality; //default
	}
	void RequestAllCharacters(){ //by calling this every frame, should keep specific letters in the texture? not sure if it's a waste
		for(int i=0, iL=hyphenedText.Length; i<iL; i++)
        {
            if (i < info.Count)
            {
                Font myFont = info[i].fontData != null ? info[i].fontData.font : font; //use info's font, or default?
                myFont.RequestCharactersInTexture(hyphenedText[i].ToString(), GetFontSize(myFont, info[i]), info[i].ch.style); //request characters to draw                                                                                                                              //and special characters:
                myFont.RequestCharactersInTexture("-", GetFontSize(myFont, info[i]), FontStyle.Normal); //still call this, for when you're inserting hyphens anyway
            }
		}
	}

	public float CurrentLineWidth = 0;
	
	void RebuildTextInfo(){ 
		drawText = ParseText(text); //remove parsing junk (<col>, <b>), and fill textinfo again
		Vector3 pos = new Vector3(info.Count > 0 ? info[0].indent : 0f, 0f, 0f); //keep track of where to place this text
		lineBreaks.Clear(); //index of line break characters, for centering

		hyphenedText = string.Copy(drawText);
		if( AutoWrap > 0f){ //use autowrap?
			//XXXXXX TODOOOOO AHHH see if setting "quality" to be info[i].ch.size has any issues, now: 2016-10-26
			for(int i=0, iL=hyphenedText.Length; i<iL; i++){ //first, get character info...
				Font myFont = info[i].fontData != null ? info[i].fontData.font : font; //use info's font, or default?
				myFont.RequestCharactersInTexture(hyphenedText[i].ToString(), GetFontSize(myFont,info[i]), info[i].ch.style); //request characters to draw
				CharacterInfo ch;
				if(myFont.GetCharacterInfo(hyphenedText[i], out ch, GetFontSize(myFont,info[i]), info[i].ch.style)){ //does this character exist?
					info[i].ch = ch; //remember character info!
				}//else, don't draw anything! this charcter won't have info
			}

			CurrentLineWidth = 0;
			float lineWidth = info.Count > 0 ? info[0].indent : 0f;
			int indexOffset = 0;
			for(int i=0, iL=hyphenedText.Length; i<iL; i++){
				Font myFont = info[i].fontData != null ? info[i].fontData.font : font; //use info's font, or default?
				CharacterInfo spaceCh; //moved these into this loop 2016-10-26
				myFont.GetCharacterInfo(' ', out spaceCh, GetFontSize(myFont,info[i]), style); //get data for space
				CharacterInfo hyphenCh;
				//myFont.RequestCharactersInTexture("-", GetFontSize(myFont,info[i]), style); //still call this, for when you're inserting hyphens anyway
				myFont.RequestCharactersInTexture(" ", GetFontSize(myFont,info[i]), style); //still call this, for when you're inserting hyphens anyway
				myFont.GetCharacterInfo('-', out hyphenCh, GetFontSize(myFont,info[i]), style);
				//float hyphenWidth = hyphenCh.advance * (info[i].size / info[i].ch.size); //have hyphen size match last character in row
				if(hyphenedText[i] == '\n'){ //is this character a line break?
					lineWidth = 0f; //new line, reset
				}else if(hyphenedText[i] == '\t'){ // linebreak with a tab...
					lineWidth += 0.5f * tabSize * info[i].size;
				}else{
					lineWidth += info[i].Advance(characterSpacing, info[i].ch.size).x;
				}

				CurrentLineWidth = Mathf.Max(CurrentLineWidth,lineWidth) ;
				
				//TODO: watch out for natural hyphens going over bounds limits
				if(lineWidth > AutoWrap){
					int myBreak = hyphenedText.LastIndexOf(' ',i); //safe spot to do a line break, can be a hyphen
					//int myHyphenBreak = hyphenedText.LastIndexOf('-',i);
					int myHyphenBreak = hyphenedText.LastIndexOf(' ',i); // 把换行的连接字符换成 ‘ ’
					int myTabBreak = hyphenedText.LastIndexOf('\t',i); //can break at a tab, too!
					int myActualBreak = Mathf.Max(new int[]{myBreak, myHyphenBreak, myTabBreak}); //get the largest of all 3
					int lastBreak = hyphenedText.LastIndexOf('\n',i); //last place a ine break happened
					if(!breakText && myActualBreak != -1 && myActualBreak > lastBreak){ //is there a space to do a line break? (and no hyphens...) AND we're not breaking text up at all
						//
						if(myActualBreak == myHyphenBreak){ //the break is at a hyphen
							hyphenedText = hyphenedText.Insert(myActualBreak+1, '\n'.ToString());
							info.Insert(myActualBreak+1,new STMTextInfo(info[myActualBreak], spaceCh));
							i = myActualBreak+1; //go back
							//if(AutoWrap < info[i - indexOffset].size){ //otherwise, it'll loop foreverrr
							//	i += 1;
							//}
							iL += 1;
							indexOffset += 1;
						}else{
							hyphenedText = hyphenedText.Remove(myActualBreak, 1); //this is wrong, don't remove the space ooops
							hyphenedText = hyphenedText.Insert(myActualBreak, '\n'.ToString());
							i = myActualBreak;
						}
						
						lineWidth = info[i].indent; //reset
					}else if(i != 0){ //split it here! but not if it's the first character
						if(insertHyphens){
							//hyphenedText = hyphenedText.Insert(i, "-\n");
							hyphenedText = hyphenedText.Insert(i, " \n");
							//Debug.Log("This needs a hyphen: " + hyphenedText);
							info.Insert(i,new STMTextInfo(info[i - indexOffset], spaceCh));
							info.Insert(i,new STMTextInfo(info[i - indexOffset], hyphenCh));
							if(AutoWrap < info[i - indexOffset].size){ //otherwise, it'll loop foreverrr
								i += 2;
							}
							iL += 2;
							indexOffset += 2;
						}else{
							hyphenedText = hyphenedText.Insert(i, "\n");
							info.Insert(i,new STMTextInfo(info[i - indexOffset], spaceCh));
							if(AutoWrap < info[i - indexOffset].size){ //otherwise, it'll loop foreverrr
								i += 1;
							}
							iL += 1;
							indexOffset += 1;
						}
						lineWidth = info[i].indent; //reset
					}//no need to check for following space, it'll come up anyway
				}
			}
			
		}else{
			for(int i=0, iL=hyphenedText.Length; i<iL; i++){ //from character info...
				Font myFont = info[i].fontData != null ? info[i].fontData.font : font; //use info's font, or default?
				//vvvv very important
				myFont.RequestCharactersInTexture(hyphenedText[i].ToString(), GetFontSize(myFont,info[i]), info[i].ch.style); //request characters to draw
				//font.RequestCharactersInTexture(System.Text.Encoding.UTF8.GetString(System.BitConverter.GetBytes(info[i].ch.index)), GetFontSize(myFont,info[i]), info[i].ch.style); //request characters to draw
				CharacterInfo ch;
				if(myFont.GetCharacterInfo(hyphenedText[i], out ch, GetFontSize(myFont,info[i]), info[i].ch.style)){ //does this character exist?
					info[i].ch = ch; //remember character info!
				}//else, don't draw anything! this charcter won't have info
			}
		}
		//get position
		int currentLineCount = 0;
		for(int i=0, iL=hyphenedText.Length; i<iL; i++){ //for each character to draw...
			Font myFont = info[i].fontData != null ? info[i].fontData.font : font; //use info's font, or default?
			float myQuality = (float)GetFontSize(myFont,info[i]);
			info[i].pos = pos; //save this position data!
			info[i].line = currentLineCount;
			if(hyphenedText[i] == '\n'){//drop a line
				if(i == 0){ //first character is a line break?
					lineBreaks.Add(0);
				}else{
					lineBreaks.Add(i-1);
				}
				//start new row at the X position of the indent character
				pos = new Vector3(info[i].indent, pos.y ,0); //assume left-orintated for now. go back to start of row
				pos -= new Vector3(0, myQuality * lineSpacing, 0) * (size / myQuality); //drop down
				currentLineCount++;
			}
			else if(iL - 1 == i){ //last character, and not a line break?
				lineBreaks.Add(i);
			}
			else if(hyphenedText[i] == '\t'){//tab?
				pos += new Vector3(myQuality * 0.5f * tabSize, 0,0) * (info[i].size / myQuality);
			}
			else{// Advance character position
				pos += info[i].Advance(characterSpacing,myQuality);
			}//remember position data for whatever
		}
		lineBreaks = lineBreaks.Distinct().ToList(); //remove doubles, preventing horizontal offset glitch
		
		ApplyOffsetDataToTextInfo(); //just to clean up this very long function...
		PrepareSubmeshes();
	}
	void ApplyOffsetDataToTextInfo(){ //this works!!! ahhhh!!!
		float[] allMaxes = new float[lineBreaks.Count];
		for(int i=0, iL=lineBreaks.Count; i<iL; i++){
			//get max x data from this line
			allMaxes[i] = info[lineBreaks[i]].TopRightVert.x;
			if(float.IsNaN(allMaxes[i])){
				allMaxes[i] = 0f; //for rows that are just linebreaks! take THAT
			}
		}
		float maxX = Mathf.Max(allMaxes);
		Vector3 offset = -baseOffset; //apply anchor offset
		float lowestVert = size;
		float rightestVert = 0f;
		int rowStart = 0; //index of where this row starts
		for(int i=0, iL=lineBreaks.Count; i<iL; i++){ //for each line of text //2016-06-09 new alignment script
			float myOffsetRight = maxX - info[lineBreaks[i]].TopRightVert.x; //empty space on this row
			if(AutoWrap > 0f){
				myOffsetRight += AutoWrap - maxX;
			}
			int spaceCount = 0;
			for(int j=rowStart, jL=lineBreaks[i]+1; j<jL; j++){ //see how many spaces there are
				if(hyphenedText[j] == ' '){
					spaceCount++;
				}
			}
			float justifySpace = spaceCount > 0 ? myOffsetRight / (float)spaceCount : 0f;
			int passedSpaces = 0;
			for(int j=rowStart, jL=lineBreaks[i]+1; j<jL; j++){//if this character is in the range...
				if(hyphenedText[j] == ' '){
					passedSpaces++;
				}
				//Debug.Log("Aligning character " + j + ", which is: '" + hyphenedText[j] + "'.");
				switch(info[j].alignment){
					case Alignment.Center:
						info[j].pos.x += myOffsetRight / 2f; //use half of empty space
						break;
					case Alignment.Right:
						info[j].pos.x += myOffsetRight;
						break;
					case Alignment.Justified:
						if(jL != hyphenedText.Length && drawText[jL - (hyphenedText.Length - drawText.Length)] != '\n'){ //not the very last row, or a row with a linebreak?
							info[j].pos.x += justifySpace * passedSpaces;
						}
						break;
					case Alignment.ForceJustified:
						info[j].pos.x += justifySpace * passedSpaces; //justify no matter what
						break;
					//do nothing for left-aligned
				}
				if(lineCountLimit == 0 || info[j].line < lineCountLimit){ //only keep counting if it's not past the line count limit
					lowestVert = Mathf.Min(lowestVert, info[j].pos.y); //yeah this works. shouldn't change with waves/weird letters
				}
				rightestVert = Mathf.Max(rightestVert, info[j].BottomRightVert.x);
			}
			rowStart = lineBreaks[i]+1;
		}
		if(autoWrap > 0f){//anchor to box instead of text
			switch(anchor){ //yep, just use autowrap limit
				case TextAnchor.UpperLeft: offset += new Vector3(0, size, 0); break;
				case TextAnchor.UpperCenter: offset += new Vector3(autoWrap * 0.5f, size, 0); break;
				case TextAnchor.UpperRight: offset += new Vector3(autoWrap, size, 0); break;
				case TextAnchor.MiddleLeft: offset += new Vector3(0, (size + lowestVert) * 0.5f, 0); break;
				case TextAnchor.MiddleCenter: offset += new Vector3(autoWrap * 0.5f, (size + lowestVert) * 0.5f, 0); break;
				case TextAnchor.MiddleRight: offset += new Vector3(autoWrap, (size + lowestVert) * 0.5f, 0); break;
				case TextAnchor.LowerLeft: offset += new Vector3(0, lowestVert, 0); break;
				case TextAnchor.LowerCenter: offset += new Vector3(autoWrap * 0.5f, lowestVert, 0); break;
				case TextAnchor.LowerRight: offset += new Vector3(autoWrap, lowestVert, 0); break;
			}
		}else{
			switch(anchor){
				case TextAnchor.UpperLeft: offset += new Vector3(0, size, 0); break;
				case TextAnchor.UpperCenter: offset += new Vector3(maxX * 0.5f, size, 0); break;
				case TextAnchor.UpperRight: offset += new Vector3(maxX, size, 0); break;
				case TextAnchor.MiddleLeft: offset += new Vector3(0, (size + lowestVert) * 0.5f, 0); break;
				case TextAnchor.MiddleCenter: offset += new Vector3(maxX * 0.5f, (size + lowestVert) * 0.5f, 0); break;
				case TextAnchor.MiddleRight: offset += new Vector3(maxX, (size + lowestVert) * 0.5f, 0); break;
				case TextAnchor.LowerLeft: offset += new Vector3(0, lowestVert, 0); break;
				case TextAnchor.LowerCenter: offset += new Vector3(maxX * 0.5f, lowestVert, 0); break;
				case TextAnchor.LowerRight: offset += new Vector3(maxX, lowestVert, 0); break;
			}
		}
		for(int i=0, iL=info.Count; i<iL; i++){ //apply all offsets
			info[i].pos -= offset;
		}
		rawTopLeftBounds = new Vector3(offset.x, offset.y - size, offset.z); //scale to show proper bunds even when parent is scaled weird
		rawBottomRightBounds = new Vector3(AutoWrap > 0f ? offset.x - AutoWrap :offset.x - rightestVert, 
															offset.y - lowestVert, 
															offset.z);
	
		RecalculateBounds();
	}
	void RecalculateBounds(){
		topLeftBounds = rawTopLeftBounds;
		topRightBounds = new Vector3(rawBottomRightBounds.x, rawTopLeftBounds.y, rawTopLeftBounds.z);
		bottomLeftBounds = new Vector3(rawTopLeftBounds.x, rawBottomRightBounds.y, rawBottomRightBounds.z);
		bottomRightBounds = rawBottomRightBounds;

		topLeftBounds = t.rotation * topLeftBounds;
		topRightBounds = t.rotation * topRightBounds;
		bottomLeftBounds = t.rotation * bottomLeftBounds;
		bottomRightBounds = t.rotation * bottomRightBounds;

		topLeftBounds.Scale(t.lossyScale);
		topRightBounds.Scale(t.lossyScale);
		bottomLeftBounds.Scale(t.lossyScale);
		bottomRightBounds.Scale(t.lossyScale);

		topLeftBounds = t.position - topLeftBounds; //do this last, so previous transforms are based around 0
		topRightBounds = t.position - topRightBounds;
		bottomLeftBounds = t.position - bottomLeftBounds;
		bottomRightBounds = t.position - bottomRightBounds;

		centerBounds = Vector3.Lerp(topLeftBounds, bottomRightBounds, 0.5f);
	}

    Vector3 WaveValue(STMTextInfo myInfo, STMWaveControl wave){ //multiply offset by 6 because ??????? seems to work
                                                                //float currentTime = GetTime;
        float myTime = 0;
		return new Vector3(wave.curveX.Evaluate(((myTime * wave.speed.x) + wave.offset * 6f) + (myInfo.pos.x * wave.density.x / myInfo.size)) * wave.strength.x * myInfo.size, 
							wave.curveY.Evaluate(((myTime * wave.speed.y) + wave.offset * 6f) + (myInfo.pos.x * wave.density.y / myInfo.size)) * wave.strength.y * myInfo.size, 
							wave.curveZ.Evaluate(((myTime * wave.speed.z) + wave.offset * 6f) + (myInfo.pos.x * wave.density.z / myInfo.size)) * wave.strength.z * myInfo.size); //multiply by universal size;
	}
	void PrepareSubmeshes(){
		//since this only needs to be calculated during Rebuild(), putting this in its own function.

		subMeshes = new List<SubMeshData>(); //include default submesh
        SubMeshData defaultMesh = new SubMeshData(this);

        subMeshes.Add(defaultMesh); //add default submesh
		for(int i=0, iL=hyphenedText.Length; i<iL; i++)
        { 
            //vvvv this way seems fine tho
            defaultMesh.tris.Add(4*i + 0);
            defaultMesh.tris.Add(4*i + 1);
            defaultMesh.tris.Add(4*i + 2);
            defaultMesh.tris.Add(4*i + 0);
            defaultMesh.tris.Add(4*i + 2);
            defaultMesh.tris.Add(4*i + 3);
		}
	}
	void UpdateMesh(float myTime) { //set the data for the endmesh
		endVerts = new Vector3[hyphenedText.Length * 4];
		endUv = new Vector2[hyphenedText.Length * 4];
		endUv2 = new Vector2[hyphenedText.Length * 4]; //overlay images
        endUv3 = new Vector2[hyphenedText.Length * 4];
        endCol32 = new Color32[hyphenedText.Length * 4];
        for (int i=0, iL=hyphenedText.Length; i<iL; i++)
        {
			Vector3 jitterValue = Vector3.zero;
			Vector3 waveValue = Vector3.zero; //universal
			Vector3 waveValueTopLeft = Vector3.zero;
			Vector3 waveValueTopRight = Vector3.zero;
			Vector3 waveValueBottomRight = Vector3.zero;
			Vector3 waveValueBottomLeft = Vector3.zero;
			if(info[i].waveData != null && info[i].size != 0)
            {
				waveValue = WaveValue(info[i], info[i].waveData.main);
				if(info[i].waveData.individualVertexControl){
					waveValueTopLeft = WaveValue(info[i], info[i].waveData.topLeft);
					waveValueTopRight = WaveValue(info[i], info[i].waveData.topRight);
					waveValueBottomRight = WaveValue(info[i], info[i].waveData.bottomRight);
					waveValueBottomLeft = WaveValue(info[i], info[i].waveData.bottomLeft);
				}
			}
			Vector3 lowestLineOffset = lineCountLimit > 0 && lowestLine > lineCountLimit-1 ? new Vector3(0, info[i].ch.size * lineSpacing, 0) * (size / info[i].ch.size) * (lowestLine - lineCountLimit + 1) : Vector3.zero; //drop down
			if(lineCountLimit > 0 && info[i].line < lowestLine - lineCountLimit + 1){
				endVerts[4*i + 0] = Vector3.zero;
				endVerts[4*i + 1] = Vector3.zero;
				endVerts[4*i + 2] = Vector3.zero;
				endVerts[4*i + 3] = Vector3.zero;
			}else{
				if(info[i].quadData == null){
					endVerts[4*i + 0] = (info[i].TopLeftVert + jitterValue + waveValueTopLeft + waveValue) + lowestLineOffset;
					endVerts[4*i + 1] = (info[i].TopRightVert + jitterValue + waveValueTopRight + waveValue) + lowestLineOffset;
					endVerts[4*i + 2] = (info[i].BottomRightVert + jitterValue + waveValueBottomRight + waveValue) + lowestLineOffset;
					endVerts[4*i + 3] = (info[i].BottomLeftVert + jitterValue + waveValueBottomLeft + waveValue) + lowestLineOffset;
					
				//Assign text UVs
					//this only needs to be changed on Rebuild()
					endUv[4*i + 0] = info[i].ch.uvTopLeft;
					endUv[4*i + 1] = info[i].ch.uvTopRight;
					endUv[4*i + 2] = info[i].ch.uvBottomRight;
					endUv[4*i + 3] = info[i].ch.uvBottomLeft;
				}else{
					endVerts[4*i + 0] = (info[i].RelativePos2(info[i].quadData.TopLeftVert) + jitterValue + waveValueTopLeft + waveValue) + lowestLineOffset;
					endVerts[4*i + 1] = (info[i].RelativePos2(info[i].quadData.TopRightVert) + jitterValue + waveValueTopRight + waveValue) + lowestLineOffset;
					endVerts[4*i + 2] = (info[i].RelativePos2(info[i].quadData.BottomRightVert) + jitterValue + waveValueBottomRight + waveValue) + lowestLineOffset;
					endVerts[4*i + 3] = (info[i].RelativePos2(info[i].quadData.BottomLeftVert) + jitterValue + waveValueBottomLeft + waveValue) + lowestLineOffset;

                    endUv[4 * i + 0] = info[i].quadData.UvTopLeft(0);
                    endUv[4 * i + 1] = info[i].quadData.UvTopRight(0);
                    endUv[4 * i + 2] = info[i].quadData.UvBottomRight(0);
                    endUv[4 * i + 3] = info[i].quadData.UvBottomLeft(0);
                }
			}
			if(info[i].quadData != null){ //quad silhouette?
				if(!info[i].quadData.silhouette){
					endUv2[4*i + 0] = endUv[4*i+0]; //same
					endUv2[4*i + 1] = endUv[4*i+1];
					endUv2[4*i + 2] = endUv[4*i+2];
					endUv2[4*i + 3] = endUv[4*i+3];

                    //indicate whether it is quad
                    endUv3[4 * i + 0] = Vector2.one;
                    endUv3[4 * i + 1] = Vector2.one;
                    endUv3[4 * i + 2] = Vector2.one;
                    endUv3[4 * i + 3] = Vector2.one;
                }
			}

		//Color data:
			if(info[i].quadData != null && !info[i].quadData.silhouette){ //if it's a quad but not a silhouette
				endCol32[4*i + 0] = Color.white; //set color to be white, so it doesn't interfere with texture
				endCol32[4*i + 1] = Color.white;
				endCol32[4*i + 2] = Color.white;
				endCol32[4*i + 3] = Color.white;
			}
            //gradient

            else if (info[i].gradientData != null)
            { //gradient speed + gradient spread
                float bottomY = endVerts[4 * i + 2].y;
                float topY = endVerts[4 * i + 0].y;
                float height = topY - bottomY;
                switch (info[i].gradientData.direction)
                {
                    case STMGradientData.GradientDirection.Vertical:
                        {
                            endCol32[4 * i + 0] = info[i].gradientData.gradient.Evaluate(Mathf.Abs((endVerts[4 * i + 0].y - bottomY) / height));
                            endCol32[4 * i + 1] = info[i].gradientData.gradient.Evaluate(Mathf.Abs((endVerts[4 * i + 1].y - bottomY) / height));
                            endCol32[4 * i + 2] = info[i].gradientData.gradient.Evaluate(Mathf.Abs((endVerts[4 * i + 2].y -bottomY) / height));
                            endCol32[4 * i + 3] = info[i].gradientData.gradient.Evaluate(Mathf.Abs((endVerts[4 * i + 3].y - bottomY) / height));
                        }
                                break;
                    default:
                        {
                            endCol32[4 * i + 0] = info[i].gradientData.gradient.Evaluate(endVerts[4 * i + 0].x / info[i].size); //this works!
                            endCol32[4 * i + 1] = info[i].gradientData.gradient.Evaluate(endVerts[4 * i + 1].x / info[i].size);
                            endCol32[4 * i + 2] = info[i].gradientData.gradient.Evaluate(endVerts[4 * i + 2].x / info[i].size);
                            endCol32[4 * i + 3] = info[i].gradientData.gradient.Evaluate(endVerts[4 * i + 3].x / info[i].size);
                            break;
                        }
                }
            }

            else if(info[i].colorData != null){ //use colordata
				endCol32[4*i + 0] = info[i].colorData.color;
				endCol32[4*i + 1] = info[i].colorData.color;
				endCol32[4*i + 2] = info[i].colorData.color;
				endCol32[4*i + 3] = info[i].colorData.color;
			}else{ //use default color
				endCol32[4*i + 0] = color;
				endCol32[4*i + 1] = color;
				endCol32[4*i + 2] = color;
				endCol32[4*i + 3] = color;
			}
		}
        _CheckOutLine();
    }
    void _CheckOutLine()
    {
        if (IsUseOutLine)
        {
            if (outLineType == OutLineType.MESH_CREATE)
            {
                int start = 0;
                int end = endVerts.Length;

                _AddOutLine(start, end, OutLineWidth.x / 100, 0);
                _AddOutLine(start, end, -OutLineWidth.x / 100, 0);
                start = end;
                end = endVerts.Length;
                _AddOutLine(start, end, 0, OutLineWidth.y / 100);
                _AddOutLine(start, end, 0, -OutLineWidth.y / 100);


                List<Vector3> outLineVer = new List<Vector3>(endVerts);
                List<Color32> outLineCol = new List<Color32>(endCol32);
                List<Vector2> outLineUV1 = new List<Vector2>(endUv);
                List<Vector2> outLineUV2 = new List<Vector2>(endUv2);
                List<Vector2> outLineUV3 = new List<Vector2>(endUv3);
                outLineVer.Reverse();
                outLineCol.Reverse();
                outLineUV1.Reverse();
                outLineUV2.Reverse();
                outLineUV3.Reverse();
                endVerts = outLineVer.ToArray();
                endCol32 = outLineCol.ToArray();
                endUv = outLineUV1.ToArray();
                endUv2 = outLineUV2.ToArray();
                endUv3 = outLineUV3.ToArray();
            }
        }
    }
    void _AddOutLine(int start, int end, float offset_x, float offset_y)
    {
        List<Vector3> outLineVer = new List<Vector3>(endVerts);
        List<Color32> outLineCol = new List<Color32>(endCol32);
        List<Vector2> outLineUV1 = new List<Vector2>(endUv);
        List<Vector2> outLineUV2 = new List<Vector2>(endUv2);
        List<Vector2> outLineUV3 = new List<Vector2>(endUv3);
        int count = outLineVer.Count;
        for (int i = start; i < end; ++i)
        {
            if (outLineUV3[i] == Vector2.zero)//显示字体的地方
            {
                Vector3 vt = outLineVer[i];
                float x = vt.x + offset_x;
                float y = vt.y + offset_y;
                vt = new Vector3(x, y, vt.z);
                outLineVer.Add(vt);
                outLineCol.Add(OutLineColor);
                outLineUV1.Add(outLineUV1[i]);
                outLineUV3.Add(outLineUV3[i]);
                outLineUV2.Add(outLineUV2[i]);
            }

        }
        int triCount = outLineVer.Count;
        triCount = (triCount - endVerts.Length) / 4;
        int oldCount = endVerts.Length / 4;
        endVerts = outLineVer.ToArray();
        endCol32 = outLineCol.ToArray();
        endUv = outLineUV1.ToArray();
        endUv2 = outLineUV2.ToArray();
        endUv3 = outLineUV3.ToArray();
        SubMeshData meshData = subMeshes[0];
        int j = oldCount;
        int totalCount = (oldCount + triCount);
        for (; j < totalCount; ++j)
        {
            meshData.tris.Add(4 * j + 0);
            meshData.tris.Add(4 * j + 1);
            meshData.tris.Add(4 * j + 2);
            meshData.tris.Add(4 * j + 0);
            meshData.tris.Add(4 * j + 2);
            meshData.tris.Add(4 * j + 3);
        }
    }
	void SetMesh(float timeValue){
		SetMesh(timeValue, false);
	}
	//actually update the mesh attached to the meshfilter
	void SetMesh(float timeValue, bool undrawingMesh){ //0 => start mesh, < 0 => end mesh, > 0 => midway mesh
		if(textMesh == null){
			textMesh = new Mesh(); //create the mesh initially
			textMesh.MarkDynamic(); //just do it
		}
		textMesh.Clear();
		if(text.Length > 0){
            if (timeValue == 0f){
				textMesh.vertices = startVerts;
				textMesh.colors32 = startCol32;
			}else{
				UpdateMesh(totalReadTime+1f);
				textMesh.vertices = endVerts;
				textMesh.colors32 = endCol32;
			}

			textMesh.uv = endUv; //this technically only needs to be set on Rebuild()
			textMesh.uv2 = endUv2; //use 2nd texture...
            textMesh.uv3 = endUv3;
		    textMesh.SetTriangles(subMeshes[0].tris, 0); //causes less garbage?
		}
        if (!isUIMode)
            f.sharedMesh = textMesh;
    }

	void ApplyMaterials(){
        Material mat = null;
        if (Application.isPlaying)
        {
            if (SuperTextManager.Instance != null)
                mat = SuperTextManager.Instance.GetShareMat(this.Atlas, this.font);
            else
            {
                if (mat == null)
                {
                    mat = new Material(Shader.Find("Unlit/SuperTextUV2"));
                    mat.SetTexture("_MainTex", font.material.mainTexture);
                    if (this.Atlas != null)
                        mat.SetTexture("_SecondTex", Atlas.texture);
                }
            }
        }
        else
        {
#if UNITY_EDITOR
            mat = editorMat;
#endif
        }
        if (mat != null)
        {
            if (isUIMode)
            {
                c.SetMesh(this.textMesh);
                c.materialCount = 1;
                c.SetMaterial(mat, 0);
                mat.SetFloat("_IsUseOutLine", (outLineType == OutLineType.SHADER_CREATE ? 1 : 0));
                mat.SetColor("_OutlineColor", OutLineColor);
                mat.SetFloat("_OutlineWidth", shaderOutLineWidth);
                if (_isMask)
                    this.RecalculateMasking();
            }
            else
            {
                r.sharedMaterial = mat;
                r.sharedMaterial.SetFloat("_IsUseOutLine", (outLineType == OutLineType.SHADER_CREATE ? 1 : 0));
                r.sharedMaterial.SetColor("_OutlineColor", OutLineColor);
                r.sharedMaterial.SetFloat("_OutlineWidth", shaderOutLineWidth);
            }

        }

	}
    private void _UpdateVertexAlpha()
    {
        if (textMesh != null)
        {
            Color32[] colors = textMesh.colors32;
            int length = textMesh.colors32.Length;
            for (int i = 0; i < length; ++i)
            {
                colors[i].a =  (byte)(this._alpha * 255);
            }
            textMesh.colors32 = colors;
        }
    }
    
    /// <summary>
    /// 为UI模板缓冲处理的接口
    /// </summary>
    public void RecalculateMasking()
    {
        if (isUIMode)
        {
            int m_StencilValue = 0;
            Transform rootCanvas = MaskUtilities.FindRootSortOverrideCanvas(transform);
            m_StencilValue = MaskUtilities.GetStencilDepth(transform, rootCanvas);
            if (m_StencilValue > 0)
            {
                Material mat = c.GetMaterial(0);
                if (mat != null)
                {
                    Material maskMat = StencilMaterial.Add(mat, (1 << m_StencilValue) - 1, StencilOp.Keep, CompareFunction.Equal, ColorWriteMask.All, (1 << m_StencilValue) - 1, 0);
                    c.SetMaterial(maskMat, 0);
                }

            }
            _isMask = true;
        }
    }
    public void CancelMask()
    {
        _isMask = false;
    }
}
