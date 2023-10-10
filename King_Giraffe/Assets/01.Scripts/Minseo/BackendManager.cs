using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

// 뒤끝 SDK namespace 추가
using BackEnd;

public class BackendManager : MonoBehaviour
{
    [SerializeField]
    private string userName = "";
    [SerializeField]
    private InputField userInputName;

    int num;

    void Start()
    {
        var bro = Backend.Initialize(true); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생
        }

        SignUpAndLogin();
    }

    async void SignUpAndLogin()
    {
        num = Random.Range(0, 9999);

        userName = userInputName.text;

        await Task.Run(() => {
            BackendLogin.Instance.CustomSignUp("user" + num.ToString() , "1234"); 
            BackendLogin.Instance.CustomLogin("user" + num.ToString() , "1234");

            if (userName != "")
            {
                BackendLogin.Instance.UpdateNickname(userName);
            }

            Debug.Log("테스트를 종료합니다.");
            BackendRank.Instance.RankGet();
        });
    }
}