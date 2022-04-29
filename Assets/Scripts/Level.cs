using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject tiles;
    public LevelType type;

    public enum LevelType
    {
        Light,
        Dark
    }
}
