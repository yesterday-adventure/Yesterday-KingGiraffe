using UnityEngine;
using System.Threading.Tasks;

// �ڳ� SDK namespace �߰�
using BackEnd;

public class BackendManager : MonoBehaviour
{
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

        Test();
    }

    // ���� �Լ��� �񵿱⿡�� ȣ���ϰ� ���ִ� �Լ�(����Ƽ UI ���� �Ұ�)
    async void Test()
    {
        int userNum = 0;
        await Task.Run(() => {
            BackendLogin.Instance.CustomLogin("user1", userNum.ToString()); // �ڳ� �α��� �Լ�

            BackendRank.Instance.RankGet(); // [�߰�] ��ŷ �ҷ����� �Լ�

            userNum++;
            Debug.Log(userNum);
            Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }
}