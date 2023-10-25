using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBG : MonoBehaviour
{
    public static PlayerBG instance;
    [SerializeField] private GameObject bg;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    public void MoveBG(Vector3 _dir)
    {
        bg.transform.position -= _dir;
        
        if (bg.transform.position.x <= -19)
        {
            bg.transform.position = Vector3.zero;
        }
    }
}
