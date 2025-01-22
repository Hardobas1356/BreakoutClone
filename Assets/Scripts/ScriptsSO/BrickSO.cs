using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BrickSO : ScriptableObject
{
    public Color color;
    public BrickSO precedingBrickSO;
}
