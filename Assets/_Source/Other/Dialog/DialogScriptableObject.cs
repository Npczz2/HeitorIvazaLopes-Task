using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Scriptable Objects/Dialog")]
public class DialogScriptableObject : ScriptableObject
{
    public int DialogID;
    public List<DialogLine> DialogLines;
}

[Serializable]
public struct DialogLine
{
    public string CharacterName;
    public string Line;
}
