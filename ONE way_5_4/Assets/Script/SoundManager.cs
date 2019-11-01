using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}


public class SoundManager : MonoBehaviour
{
    
    static public SoundManager instance;

    #region singleton
    void Awake() //객체 생성 최초 실행
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
            
        else
            Destroy(this.gameObject);
    }
    #endregion singleton

    public AudioSource[] audioSourcesEffects;
    public AudioSource audioSourceBgm;

    public string[] playSoundName;

    public Sound[] effectSounds;
    public Sound[] bgmSounds;

    void Start()
    {
        playSoundName = new string[audioSourcesEffects.Length];
    }

   public void PlaySE(string _name)
    {
        for(int i = 0; i<effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name)
            {
                for(int j = 0; j<audioSourcesEffects.Length; j++)
                {
                    if (!audioSourcesEffects[j].isPlaying)
                    {
                        playSoundName[j] = effectSounds[i].name;
                        audioSourcesEffects[j].clip = effectSounds[i].clip;
                        audioSourcesEffects[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 AudioSource가 사용");
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager 에 등록 안됨");
    }

    public void StopAllSE()
    {
        for(int i = 0; i<audioSourcesEffects.Length; i++)
        {
            audioSourcesEffects[i].Stop();
        }

    }

    public void StopSE(string _name)
    {
        for(int i = 0; i<audioSourcesEffects.Length; i++)
        {
            if(playSoundName[i] == _name)
            {
                audioSourcesEffects[i].Stop();
                return;
            }
        }
        Debug.Log("재생중인" + _name + "사운드가 없음");
    }
}
