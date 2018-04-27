//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace RakNet {

using System;
using System.Runtime.InteropServices;
#pragma warning disable 0660

public class RakString : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal RakString(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RakString obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~RakString() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          RakNetPINVOKE.CSharp_RakNet_delete_RakString(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }


	public override int GetHashCode()
	{
		return this.C_String().GetHashCode();
	}

	public static bool operator ==(RakString a, RakString b)
	{
 	   	// If both are null, or both are same instance, return true.
 		if (System.Object.ReferenceEquals(a, b))
 		{
 	       		return true;
 	   	}

  		// If one is null, but not both, return false.
   	 	if (((object)a == null) || ((object)b == null))
    		{
       		 	return false;
    		}

		    return a.Equals(b);//Equals should be overloaded as well
	}

	public static bool operator ==(RakString a, string b)
	{
 	   	// If both are null, or both are same instance, return true.
 		if (System.Object.ReferenceEquals(a, b))
 		{
 	       		return true;
 	   	}

  		// If one is null, but not both, return false.
   	 	if (((object)a == null) || ((object)b == null))
    		{
       		 	return false;
    		}

		    return a.Equals(b);//Equals should be overloaded as well
	}

	public static bool operator ==(RakString a, char b)
	{
 	   	// If both are null, or both are same instance, return true.
 		if (System.Object.ReferenceEquals(a, b))
 		{
 	       		return true;
 	   	}

  		// If one is null, but not both, return false.
   	 	if (((object)a == null) || ((object)b == null))
    		{
       		 	return false;
    		}

		    return a.Equals(b);//Equals should be overloaded as well
	}

	public static bool operator !=(RakString a, char b)
	{
   		 return !(a==b);
	}

	public static bool operator !=(RakString a, RakString b)
	{
   		 return a.OpNotEqual(b);
	}

	public static bool operator !=(RakString a, string b)
	{
   		 return a.OpNotEqual(b);
	}

	public static bool operator < (RakString a, RakString b)
	{
    		return a.OpLess(b);
	}

	public static bool operator >(RakString a, RakString b)
	{
		return a.OpGreater(b);
	}

	public static bool operator <=(RakString a, RakString b)
	{
		return a.OpLessEquals(b);
	}

	public static bool operator >=(RakString a, RakString b)
	{
		return a.OpGreaterEquals(b);
	}

	public char this[int index]  
 	{  
		get   
		{
			 return (char)OpArray((uint)index); // use indexto retrieve and return another value.    
		}  
		set   
		{
        		Replace((uint)index,1,(byte)value);// use index and value to set the value somewhere.   
		}  
	}  

	public static RakString operator +(RakString a, RakString b)
	{
		return RakNet.OpPlus(a,b);
	}

	public static implicit operator RakString(String s)
	{
		return new RakString(s);
	} 

	public static implicit operator RakString(char c)
	{
		return new RakString(c);
	} 

	public static implicit operator RakString(byte c)
	{
		return new RakString(c);
	} 
	
	public override string ToString()
	{
		return C_String();
	}

	public void SetChar(uint index, char inChar)
	{
		SetChar(index,(byte)inChar);
	}

	public void Replace(uint index, uint count, char inChar)
	{
		Replace(index,count,(byte)inChar);
	}

  public RakString() : this(RakNetPINVOKE.CSharp_RakNet_new_RakString__SWIG_0(), true) {
  }

  public RakString(char input) : this(RakNetPINVOKE.CSharp_RakNet_new_RakString__SWIG_1(input), true) {
  }

  public RakString(byte input) : this(RakNetPINVOKE.CSharp_RakNet_new_RakString__SWIG_2(input), true) {
  }

  public RakString(string format) : this(RakNetPINVOKE.CSharp_RakNet_new_RakString__SWIG_3(format), true) {
  }

  public RakString(RakString rhs) : this(RakNetPINVOKE.CSharp_RakNet_new_RakString__SWIG_4(RakString.getCPtr(rhs)), true) {
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
  }

  public string C_String() {
    string ret = RakNetPINVOKE.CSharp_RakNet_RakString_C_String(swigCPtr);
    return ret;
  }

  public string C_StringUnsafe() {
    string ret = RakNetPINVOKE.CSharp_RakNet_RakString_C_StringUnsafe(swigCPtr);
    return ret;
  }

  public RakString CopyData(RakString rhs) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_CopyData__SWIG_0(swigCPtr, RakString.getCPtr(rhs)), false);
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public RakString CopyData(string str) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_CopyData__SWIG_1(swigCPtr, str), false);
    return ret;
  }

  public RakString CopyData(SWIGTYPE_p_unsigned_char str) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_CopyData__SWIG_2(swigCPtr, SWIGTYPE_p_unsigned_char.getCPtr(str)), false);
    return ret;
  }

  public RakString CopyData(char c) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_CopyData__SWIG_4(swigCPtr, c), false);
    return ret;
  }

  private byte OpArray(uint position) {
    byte ret = RakNetPINVOKE.CSharp_RakNet_RakString_OpArray(swigCPtr, position);
    return ret;
  }

  public uint Find(string stringToFind, uint pos) {
    uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_Find__SWIG_0(swigCPtr, stringToFind, pos);
    return ret;
  }

  public uint Find(string stringToFind) {
    uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_Find__SWIG_1(swigCPtr, stringToFind);
    return ret;
  }

  public bool Equals(RakString rhs) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_Equals__SWIG_0(swigCPtr, RakString.getCPtr(rhs));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Equals(string str) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_Equals__SWIG_1(swigCPtr, str);
    return ret;
  }

  private bool OpLess(RakString right) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_OpLess(swigCPtr, RakString.getCPtr(right));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private bool OpLessEquals(RakString right) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_OpLessEquals(swigCPtr, RakString.getCPtr(right));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private bool OpGreater(RakString right) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_OpGreater(swigCPtr, RakString.getCPtr(right));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private bool OpGreaterEquals(RakString right) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_OpGreaterEquals(swigCPtr, RakString.getCPtr(right));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private bool OpNotEqual(RakString rhs) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_OpNotEqual__SWIG_0(swigCPtr, RakString.getCPtr(rhs));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private bool OpNotEqual(string str) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_OpNotEqual__SWIG_1(swigCPtr, str);
    return ret;
  }

  public string ToLower() {
    string ret = RakNetPINVOKE.CSharp_RakNet_RakString_ToLower(swigCPtr);
    return ret;
  }

  public string ToUpper() {
    string ret = RakNetPINVOKE.CSharp_RakNet_RakString_ToUpper(swigCPtr);
    return ret;
  }

  public void Set(string format) {
    RakNetPINVOKE.CSharp_RakNet_RakString_Set(swigCPtr, format);
  }

  public RakString Assign(string str, uint pos, uint n) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_Assign(swigCPtr, str, pos, n), true);
    return ret;
  }

  public bool IsEmpty() {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_IsEmpty(swigCPtr);
    return ret;
  }

  public uint GetLength() {
    uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_GetLength(swigCPtr);
    return ret;
  }

  public uint GetLengthUTF8() {
    uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_GetLengthUTF8(swigCPtr);
    return ret;
  }

  public void Replace(uint index, uint count, byte c) {
    RakNetPINVOKE.CSharp_RakNet_RakString_Replace(swigCPtr, index, count, c);
  }

  public void SetChar(uint index, byte c) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SetChar__SWIG_0(swigCPtr, index, c);
  }

  public void SetChar(uint index, RakString s) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SetChar__SWIG_1(swigCPtr, index, RakString.getCPtr(s));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
  }

  public void Truncate(uint length) {
    RakNetPINVOKE.CSharp_RakNet_RakString_Truncate(swigCPtr, length);
  }

  public void TruncateUTF8(uint length) {
    RakNetPINVOKE.CSharp_RakNet_RakString_TruncateUTF8(swigCPtr, length);
  }

  public RakString SubStr(uint index, uint count) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_SubStr(swigCPtr, index, count), true);
    return ret;
  }

  public void Erase(uint index, uint count) {
    RakNetPINVOKE.CSharp_RakNet_RakString_Erase(swigCPtr, index, count);
  }

  public void TerminateAtFirstCharacter(char c) {
    RakNetPINVOKE.CSharp_RakNet_RakString_TerminateAtFirstCharacter(swigCPtr, c);
  }

  public void TerminateAtLastCharacter(char c) {
    RakNetPINVOKE.CSharp_RakNet_RakString_TerminateAtLastCharacter(swigCPtr, c);
  }

  public void StartAfterFirstCharacter(char c) {
    RakNetPINVOKE.CSharp_RakNet_RakString_StartAfterFirstCharacter(swigCPtr, c);
  }

  public void StartAfterLastCharacter(char c) {
    RakNetPINVOKE.CSharp_RakNet_RakString_StartAfterLastCharacter(swigCPtr, c);
  }

  public int GetCharacterCount(char c) {
    int ret = RakNetPINVOKE.CSharp_RakNet_RakString_GetCharacterCount(swigCPtr, c);
    return ret;
  }

  public void RemoveCharacter(char c) {
    RakNetPINVOKE.CSharp_RakNet_RakString_RemoveCharacter(swigCPtr, c);
  }

  public static RakString NonVariadic(string str) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_NonVariadic(str), true);
    return ret;
  }

  public static uint ToInteger(string str) {
    uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_ToInteger__SWIG_0(str);
    return ret;
  }

  public static uint ToInteger(RakString rs) {
    uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_ToInteger__SWIG_1(RakString.getCPtr(rs));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static int ReadIntFromSubstring(string str, uint pos, uint n) {
    int ret = RakNetPINVOKE.CSharp_RakNet_RakString_ReadIntFromSubstring(str, pos, n);
    return ret;
  }

  public int StrCmp(RakString rhs) {
    int ret = RakNetPINVOKE.CSharp_RakNet_RakString_StrCmp(swigCPtr, RakString.getCPtr(rhs));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int StrNCmp(RakString rhs, uint num) {
    int ret = RakNetPINVOKE.CSharp_RakNet_RakString_StrNCmp(swigCPtr, RakString.getCPtr(rhs), num);
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public int StrICmp(RakString rhs) {
    int ret = RakNetPINVOKE.CSharp_RakNet_RakString_StrICmp(swigCPtr, RakString.getCPtr(rhs));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Clear() {
    RakNetPINVOKE.CSharp_RakNet_RakString_Clear(swigCPtr);
  }

  public void Printf() {
    RakNetPINVOKE.CSharp_RakNet_RakString_Printf(swigCPtr);
  }

  public bool IPAddressMatch(string IP) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_IPAddressMatch(swigCPtr, IP);
    return ret;
  }

  public bool ContainsNonprintableExceptSpaces() {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_ContainsNonprintableExceptSpaces(swigCPtr);
    return ret;
  }

  public bool IsEmailAddress() {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_IsEmailAddress(swigCPtr);
    return ret;
  }

  public RakString URLEncode() {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_URLEncode(swigCPtr), false);
    return ret;
  }

  public RakString URLDecode() {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_URLDecode(swigCPtr), false);
    return ret;
  }

  public void SplitURI(RakString header, RakString domain, RakString path) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SplitURI(swigCPtr, RakString.getCPtr(header), RakString.getCPtr(domain), RakString.getCPtr(path));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
  }

  public RakString SQLEscape() {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_SQLEscape(swigCPtr), false);
    return ret;
  }

  public static RakString FormatForPOST(string uri, string contentType, string body, string extraHeaders) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_FormatForPOST__SWIG_0(uri, contentType, body, extraHeaders), true);
    return ret;
  }

  public static RakString FormatForPOST(string uri, string contentType, string body) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_FormatForPOST__SWIG_1(uri, contentType, body), true);
    return ret;
  }

  public static RakString FormatForPUT(string uri, string contentType, string body, string extraHeaders) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_FormatForPUT__SWIG_0(uri, contentType, body, extraHeaders), true);
    return ret;
  }

  public static RakString FormatForPUT(string uri, string contentType, string body) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_FormatForPUT__SWIG_1(uri, contentType, body), true);
    return ret;
  }

  public static RakString FormatForGET(string uri, string extraHeaders) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_FormatForGET__SWIG_0(uri, extraHeaders), true);
    return ret;
  }

  public static RakString FormatForGET(string uri) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_FormatForGET__SWIG_1(uri), true);
    return ret;
  }

  public static RakString FormatForDELETE(string uri, string extraHeaders) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_FormatForDELETE__SWIG_0(uri, extraHeaders), true);
    return ret;
  }

  public static RakString FormatForDELETE(string uri) {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_FormatForDELETE__SWIG_1(uri), true);
    return ret;
  }

  public RakString MakeFilePath() {
    RakString ret = new RakString(RakNetPINVOKE.CSharp_RakNet_RakString_MakeFilePath(swigCPtr), false);
    return ret;
  }

  public static void FreeMemory() {
    RakNetPINVOKE.CSharp_RakNet_RakString_FreeMemory();
  }

  public static void FreeMemoryNoMutex() {
    RakNetPINVOKE.CSharp_RakNet_RakString_FreeMemoryNoMutex();
  }

  public void Serialize(BitStream bs) {
    RakNetPINVOKE.CSharp_RakNet_RakString_Serialize__SWIG_0(swigCPtr, BitStream.getCPtr(bs));
  }

  public static void Serialize(string str, BitStream bs) {
    RakNetPINVOKE.CSharp_RakNet_RakString_Serialize__SWIG_1(str, BitStream.getCPtr(bs));
  }

  public void SerializeCompressed(BitStream bs, byte languageId, bool writeLanguageId) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SerializeCompressed__SWIG_0(swigCPtr, BitStream.getCPtr(bs), languageId, writeLanguageId);
  }

  public void SerializeCompressed(BitStream bs, byte languageId) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SerializeCompressed__SWIG_1(swigCPtr, BitStream.getCPtr(bs), languageId);
  }

  public void SerializeCompressed(BitStream bs) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SerializeCompressed__SWIG_2(swigCPtr, BitStream.getCPtr(bs));
  }

  public static void SerializeCompressed(string str, BitStream bs, byte languageId, bool writeLanguageId) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SerializeCompressed__SWIG_3(str, BitStream.getCPtr(bs), languageId, writeLanguageId);
  }

  public static void SerializeCompressed(string str, BitStream bs, byte languageId) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SerializeCompressed__SWIG_4(str, BitStream.getCPtr(bs), languageId);
  }

  public static void SerializeCompressed(string str, BitStream bs) {
    RakNetPINVOKE.CSharp_RakNet_RakString_SerializeCompressed__SWIG_5(str, BitStream.getCPtr(bs));
  }

  public bool Deserialize(BitStream bs) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_Deserialize__SWIG_0(swigCPtr, BitStream.getCPtr(bs));
    return ret;
  }

  public static bool Deserialize(string str, BitStream bs) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_Deserialize__SWIG_1(str, BitStream.getCPtr(bs));
    return ret;
  }

  public bool DeserializeCompressed(BitStream bs, bool readLanguageId) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_DeserializeCompressed__SWIG_0(swigCPtr, BitStream.getCPtr(bs), readLanguageId);
    return ret;
  }

  public bool DeserializeCompressed(BitStream bs) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_DeserializeCompressed__SWIG_1(swigCPtr, BitStream.getCPtr(bs));
    return ret;
  }

  public static bool DeserializeCompressed(string str, BitStream bs, bool readLanguageId) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_DeserializeCompressed__SWIG_2(str, BitStream.getCPtr(bs), readLanguageId);
    return ret;
  }

  public static bool DeserializeCompressed(string str, BitStream bs) {
    bool ret = RakNetPINVOKE.CSharp_RakNet_RakString_DeserializeCompressed__SWIG_3(str, BitStream.getCPtr(bs));
    return ret;
  }

  public static string ToString(long i) {
    string ret = RakNetPINVOKE.CSharp_RakNet_RakString_ToString__SWIG_0(i);
    return ret;
  }

  public static string ToString(ulong i) {
    string ret = RakNetPINVOKE.CSharp_RakNet_RakString_ToString__SWIG_1(i);
    return ret;
  }

  public static uint GetSizeToAllocate(uint bytes) {
    uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_GetSizeToAllocate(bytes);
    return ret;
  }

  public class SharedString : global::System.IDisposable {
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;
  
    internal SharedString(global::System.IntPtr cPtr, bool cMemoryOwn) {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }
  
    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SharedString obj) {
      return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
  
    ~SharedString() {
      Dispose();
    }
  
    public virtual void Dispose() {
      lock(this) {
        if (swigCPtr.Handle != global::System.IntPtr.Zero) {
          if (swigCMemOwn) {
            swigCMemOwn = false;
            RakNetPINVOKE.CSharp_RakNet_delete_RakString_SharedString(swigCPtr);
          }
          swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }
        global::System.GC.SuppressFinalize(this);
      }
    }
  
    public SimpleMutex refCountMutex {
      set {
        RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_refCountMutex_set(swigCPtr, SimpleMutex.getCPtr(value));
      } 
      get {
        global::System.IntPtr cPtr = RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_refCountMutex_get(swigCPtr);
        SimpleMutex ret = (cPtr == global::System.IntPtr.Zero) ? null : new SimpleMutex(cPtr, false);
        return ret;
      } 
    }
  
    public uint refCount {
      set {
        RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_refCount_set(swigCPtr, value);
      } 
      get {
        uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_refCount_get(swigCPtr);
        return ret;
      } 
    }
  
    public uint bytesUsed {
      set {
        RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_bytesUsed_set(swigCPtr, value);
      } 
      get {
        uint ret = RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_bytesUsed_get(swigCPtr);
        return ret;
      } 
    }
  
    public string bigString {
      set {
        RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_bigString_set(swigCPtr, value);
      } 
      get {
        string ret = RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_bigString_get(swigCPtr);
        return ret;
      } 
    }
  
    public string c_str {
      set {
        RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_c_str_set(swigCPtr, value);
      } 
      get {
        string ret = RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_c_str_get(swigCPtr);
        return ret;
      } 
    }
  
    public string smallString {
      set {
        RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_smallString_set(swigCPtr, value);
      } 
      get {
        string ret = RakNetPINVOKE.CSharp_RakNet_RakString_SharedString_smallString_get(swigCPtr);
        return ret;
      } 
    }
  
    public SharedString() : this(RakNetPINVOKE.CSharp_RakNet_new_RakString_SharedString(), true) {
    }
  
  }

  public static int RakStringComp(RakString key, RakString data) {
    int ret = RakNetPINVOKE.CSharp_RakNet_RakString_RakStringComp(RakString.getCPtr(key), RakString.getCPtr(data));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static void LockMutex() {
    RakNetPINVOKE.CSharp_RakNet_RakString_LockMutex();
  }

  public static void UnlockMutex() {
    RakNetPINVOKE.CSharp_RakNet_RakString_UnlockMutex();
  }

  public void AppendBytes(byte[] inByteArray, uint count) {
    RakNetPINVOKE.CSharp_RakNet_RakString_AppendBytes(swigCPtr, inByteArray, count);
  }

}

}
