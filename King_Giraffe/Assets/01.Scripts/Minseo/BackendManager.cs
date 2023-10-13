using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using BackEnd;

public class BackendManager : MonoBehaviour
{
    [SerializeField]
        private string userName = "";
        //[SerializeField]
        //private InputField userInputName;

    int num;

    void Start()
    {
        var bro = Backend.Initialize(true); // �ڳ� �ʱ�ȭ

        // �ڳ� �ʱ�ȭ�� ���� ���䰪
        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 204 Success
        }
        else
        {
            Debug.LogError("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 400�� ���� �߻�
        }

        SignUpAndLogin();
    }

    async void SignUpAndLogin()
    {
        num = Random.Range(0, 9999);

        //userName = userInputName.text;  

        await Task.Run(() => {
            #region ȸ������ �α���
            BackendLogin.Instance.CustomSignUp("user" + num.ToString() , "1234"); 
            BackendLogin.Instance.CustomLogin("user" + num.ToString() , "1234");

            if (userName != "")
            {
                BackendLogin.Instance.UpdateNickname(userName);
            }
            #endregion

            #region ������
            BackendGameData.Instance.GameDataGet(); 

            if (BackendGameData.userData == null)
            {
                BackendGameData.Instance.GameDataInsert();
            }

            BackendGameData.Instance.SocreUp();

            BackendGameData.Instance.GameDataUpdate();
            #endregion

            BackendRank.Instance.RankInsert(3);
            BackendRank.Instance.RankGet();

            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }
}