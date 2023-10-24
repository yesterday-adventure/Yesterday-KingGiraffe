using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using BackEnd;
using TMPro;
using UnityEngine.SceneManagement;

public class BackendManager : MonoBehaviour
{
    private static BackendManager _instance = null;

    public string userName = "";
    [SerializeField] private TMP_InputField inputField;
    
    int num;

    public static BackendManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendManager();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        //userName = inputField.GetComponent<TMP_InputField>().text;
    }

    void Start()
    {
        userName = inputField.GetComponent<TMP_InputField>().text;

        inputField.onSubmit.AddListener((inputField) => { NickName(); });

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

    public void NickName()
    {
        userName = inputField.text;

        BackendLogin.Instance.UpdateNickname(userName);

        Debug.Log(userName);
        SceneManager.LoadScene("Menu");
    }
}