using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio sources")]
    [SerializeField] private List<AudioSource> _audioSources = new List<AudioSource>();

    [Header("Audio list")]
    [SerializeField] private List<LeveledAudio> _audioList = new List<LeveledAudio>();

    public static AudioManager Instance;
    
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        AudioManager.Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    //------------------------------------------------------------------

    public void PlayAudio(int audioID)
    {
        LeveledAudio audio = null;
        for(int i = 0; i < _audioList.Count; i++)
        {
            if(_audioList[i].AudioID == audioID)
            {
                audio = _audioList[i];
            }
        }

        AudioSource audioSource = FindAvailableAudioSource();

        if(audio != null && audioSource != null)
        {
            audioSource.clip = audio.LeveledAudioClip;
            audioSource.volume = audio.AudioVolume;
            audioSource.Play();
        }
    }

    AudioSource FindAvailableAudioSource()
    {
        for(int i = 0; i < _audioSources.Count; i++)
        {
            if(_audioSources[i].clip == null || !_audioSources[i].isPlaying)
            {
                return _audioSources[i];
            }
        }

        return null;
    }
}