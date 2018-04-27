using System;

public class TaskStruct : ViSealedData
{
   public ViEnum32<PartyType> Type; //任务类型枚举
   public string TypeName; //任务类型的名字
   public string TaskName; //任务名字
   public ViEnum32<Difficult> Difficulty; //难度
   public int LowLevel; //低等级
   public int HightLevel; //高等级

    public ViForeignKey<SpaceObjectBirthPositionStruct> SpacePosition;

}

public enum TaskType
{
    OutDoor,
    Copy1,
    Copy2,
    Copy3,
    Copy4,
    Copy5,
    Sports
}

public enum Difficult
{
    easy,
    middle,
    hard
}
