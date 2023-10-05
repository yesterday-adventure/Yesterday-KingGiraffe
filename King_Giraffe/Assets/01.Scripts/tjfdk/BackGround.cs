using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private GameObject backGround;

    private void Update() {
        
        if (backGround.transform.position.x < -2840) {

            Debug.Log("어이");
        }
    }
}
