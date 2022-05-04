using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Level GO References")]
    public GameObject tiles;
    public LevelType type;
    public SpriteRenderer[] traps;

    //Light = dimension 1 | dark = dimension 2
    public enum LevelType
    {
        Light,
        Dark
    }
}
