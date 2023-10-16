using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Windows.Speech;
using UnityEngine.Video;

public class BackGround : MonoBehaviour
{
    public static BackGround instance;

    [SerializeField] private GameObject menuBackGround;
    public int turnCount = 0;

    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Update() {

        if (menuBackGround != null)
        {
            menuBackGround.transform.position += Vector3.left * 100f * Time.deltaTime;
            if (menuBackGround.transform.position.x <= -970)
                menuBackGround.transform.position = new Vector3(970, 540, 0);
        }
    }
}
