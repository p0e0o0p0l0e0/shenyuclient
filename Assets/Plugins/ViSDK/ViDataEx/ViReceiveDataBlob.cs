using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using UInt8 = System.Byte;

//public class ViReceiveDataBlob : ViReceiveDataNode
//{
//    public ViIStream Value { get { return _value; } }
//    public override void OnUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
//    {
//        if (MatchChannel(channel))
//        {
//            ViIStream oldValue = _value;
//            IS.Read(out _value);
//            OnUpdateInvoke(oldValue);
//        }
//    }
//    public new void Start(UInt8 channel, ViIStream IS, ViEntity entity)
//    {
//        if (MatchChannel(channel))
//        {
//            IS.Read(out _value);
//        }
//    }
//    public new void Start(UInt16 channelMask, ViIStream IS, ViEntity entity)
//    {
//        if (MatchChannel(channelMask))
//        {
//            IS.Read(out _value);
//        }
//    }
//    public static bool operator ==(ViReceiveDataBlob lhs, ViReceiveDataBlob rhs)
//    {
//        return false;
//    }
//    public static bool operator !=(ViReceiveDataBlob lhs, ViReceiveDataBlob rhs)
//    {
//        return false;
//    }
//    public static bool operator ==(ViReceiveDataBlob lhs, ViIStream rhs)
//    {
//        return false;
//    }
//    public static bool operator !=(ViReceiveDataBlob lhs, ViIStream rhs)
//    {
//        return false;
//    }
//    public static implicit operator ViIStream(ViReceiveDataBlob data)
//    {
//        return data.Value;
//    }
//    public override int GetHashCode()
//    {
//        return _value.GetHashCode();
//    }
//    public override bool Equals(object other)
//    {
//        if (!(other is ViReceiveDataBlob))
//        {
//            return false;
//        }
//        ViReceiveDataBlob data = (ViReceiveDataBlob)other;
//        return _value.Equals(data.Value);
//    }
//    ViIStream _value = new ViIStream();
//}
//public static class ViReceiveDataBlobSerialize
//{
//    public static void Append(this ViOStream OS, ViReceiveDataBlob value)
//    {
//        OS.Append(value);
//    }
//}