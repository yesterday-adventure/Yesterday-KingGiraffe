using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Windows.Speech;
using UnityEngine.Video;

public class BackGround : MonoBehaviour
{
    [SerializeField] private GameObject menuBackGround;
    [SerializeField] private GameObject gameBackGround;

    private void Update() {

        if (menuBackGround != null) {

            menuBackGround.transform.position += Vector3.left * 100f * Time.deltaTime;
            if (menuBackGround.transform.position.x <= -970)
                menuBackGround.transform.position = new Vector3(970, 540, 0);
        }

        if (gameBackGround != null) {

            
        }
    }
}
