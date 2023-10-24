using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private static PointManager _instance = null;

    public static PointManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PointManager();
            }

            return _instance;
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
