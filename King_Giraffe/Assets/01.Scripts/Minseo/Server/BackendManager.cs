using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using BackEnd;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class BackendManager : MonoBehaviour
{
    int num;

    void Start()
    {
        var bro = Backend.Initialize(true);

        if (bro.IsSuccess())
        {
            Debug.Log("Backend initialized: " + bro);
        }
        else
        {
            Debug.LogError("Backend initialization failed: " + bro);
        }

        StartCoroutine(SignUpAndLoginCoroutine());


        Data.Instance.ResetBestScore();
    }



    private IEnumerator SignUpAndLoginCoroutine()
    {
        num = Random.Range(0, 9999);

        #region 로그인 회원가입
        BackendLogin.Instance.CustomSignUp("user" + num.ToString(), "1234");
        BackendLogin.Instance.CustomLogin("user" + num.ToString(), "1234");
        #endregion

        #region 데이터
        BackendGameData.Instance.GameDataGet();

        if (BackendGameData.userData == null)
        {
            BackendGameData.Instance.GameDataInsert();
        }

        BackendGameData.Instance.GameDataUpdate();
        #endregion

        yield return new WaitForSeconds(2f);

        Debug.Log("끝");
    }

    
}