using System.Collections;
using System.Collections.Generic;

public class VisualCornerList : ViSealedData
{
    public ViEnum32<PlayerEquipSlotType>  type;
    public ViForeignKey<PathFileResStruct> path;
    public string icon;
    public string name;
}

