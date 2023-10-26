using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    public string userName = "";

    public List<float> bestScore = new List<float>();

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

    public float BestSocre(float score)
    {
        bestScore.Add(score);


        float maxScore = bestScore[0];
        for (int i = 1; i < bestScore.Count; i++)
        {
            Debug.Log(bestScore[i]);
            if (bestScore[i] > maxScore)
            {
                maxScore = bestScore[i];
            }
        }

        return maxScore;
    }

    public string LoadData()
    {
        userName = PlayerPrefs.GetString("userName");
        return userName;
    }
}