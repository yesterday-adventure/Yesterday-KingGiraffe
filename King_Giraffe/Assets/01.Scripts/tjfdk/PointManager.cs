using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject point;

    public bool canDash = false;

    public int curPoint = 0;
    public int pointMax;

    public void ResetDash()
    { 
        curPoint = 0;
        canDash = false;
    }

    public void SpawnPoint()
    {
        int ran = Random.Range((int)_player.transform.position.x + 20
                , (int)_player.transform.position.x + 30);
        Vector3 dir = new Vector3(ran, -2);
        Instantiate(point, dir, Quaternion.identity);
    }
}
