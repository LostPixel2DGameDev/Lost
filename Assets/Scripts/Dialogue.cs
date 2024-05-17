using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/New Dialogue Container")]
public class Dialogue : ScriptableObject
{
    public string speakerName;

    [TextArea(5, 10)]
    public string[] paragraphs;
    
}
