using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public string userName = "";

    private static Data _instance = null;

    public static Data Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Data();
            }

            return _instance;
        }
    }

    void Start()
    {
        userName = inputField.GetComponent<TMP_InputField>().text;

        inputField.onSubmit.AddListener((inputField) => { NickName(); });
    }

    public void NickName()
    {
        userName = inputField.text;

        PlayerPrefs.SetString("userName", userName);

        BackendLogin.Instance.UpdateNickname(userName);

        Debug.Log(userName);
        SceneManager.LoadScene("Menu");
        DontDestroyOnLoad(gameObject);
    }

    public string LoadData()
    {
        userName = PlayerPrefs.GetString("userName");
        Debug.Log(userName);
        return userName;
    }
}