using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalType
{
    Kill,
    PlaceObject
}
[Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public bool isHanakoAtPeace;

    
}
