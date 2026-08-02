using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private LeveledAudio _sceneMusic;
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayMusic();
    }

    void Update()
    {
        if(!_audioSource.isPlaying)
        {
            PlayMusic();
        }
    }

    //------------------------------------------------------------------

    void PlayMusic()
    {
        _audioSource.volume = _sceneMusic.AudioVolume;
        _audioSource.clip = _sceneMusic.LeveledAudioClip;
        _audioSource.Play();
    }
}
