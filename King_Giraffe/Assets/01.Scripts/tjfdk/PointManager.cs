using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private static PointManager _instance;

    public static PointManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public bool canDash = false;

    public int curPoint = 0;
    public int pointMax;

    public void ResetDash()
    { 
        curPoint = 0;
        canDash = false;
    }
}
