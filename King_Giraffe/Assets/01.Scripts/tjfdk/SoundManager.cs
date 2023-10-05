using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]          
public class Sound
{
    public string soundName;  
    public AudioClip clip;  
}

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;        // ���� �Ŵ��� �̱���
    private void Awake()
    {
        if (instance == null)                
            instance = this;               
        else                                  
            Destroy(this.gameObject);
    }



    public Sound[] bgmSounds;           // BGM 사운드 저장
    public Sound[] effectSounds;        // SFX 사운드 저장

    public AudioSource audioSourceBgmPlayers;           // BGM을 출력할 오디오 소스
    public AudioSource[] audioSourceEffectsPlayers;     // SFX를 출력할 오디오 소스

    public string[] playSoundName;                      // ??? ???? ????? ???? ??? 

    private void Start()
    {
        playSoundName = new string[audioSourceEffectsPlayers.Length];
        PlayBGM("BGM");
    }

    public void PlaySE(string name) // 
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (name == effectSounds[i].soundName)
            {
                for (int j = 0; j < audioSourceEffectsPlayers.Length; j++)
                {
                    if (!audioSourceEffectsPlayers[j].isPlaying)                        // ????????? ???? ????? ?????
                    {
                        audioSourceEffectsPlayers[j].clip = effectSounds[i].clip;       // clip: ????? ???
                        audioSourceEffectsPlayers[j].Play();                            //????? ???
                        playSoundName[j] = effectSounds[i].soundName;
                        return;
                    }
                }

                return;
            }
        }
    }

    public void PlayBGM(string name) // BGM 실행
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (name == bgmSounds[i].soundName)
            {
                audioSourceBgmPlayers.clip = bgmSounds[i].clip;
                audioSourceBgmPlayers.Play();
                return;
            }
        }
    }

    public void StopAllEffectsSound() // 모든 SFX룰 중지
    {
        for (int i = 0; i < audioSourceEffectsPlayers.Length; i++)
        {
            audioSourceEffectsPlayers[i].Stop();
        }
    }

    public void StopEffectsSound(string name)       //??? ????? ????
    {
        for (int i = 0; i < audioSourceEffectsPlayers.Length; i++)
        {
            if (playSoundName[i] == name)
            {
                audioSourceEffectsPlayers[i].Stop();
                break;
            }
        }

        Debug.Log("??????? " + name + "???? ????");

    }
}
