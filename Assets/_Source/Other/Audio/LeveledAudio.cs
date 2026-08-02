using UnityEngine;

[CreateAssetMenu(fileName = "New Leveled Audio", menuName = "Scriptable Objects/Leveled Audio")]
public class LeveledAudio : ScriptableObject
{
    public int AudioID;
    public AudioClip LeveledAudioClip;
    public float AudioVolume;
}
