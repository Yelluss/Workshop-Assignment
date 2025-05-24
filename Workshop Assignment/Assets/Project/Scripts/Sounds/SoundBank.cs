using UnityEngine;

public class SoundBank : MonoBehaviour
{

    public AudioClip stepAudio;

    public AudioClip[] thunderSounds;

    public static SoundBank Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        
    }


    void Update()
    {
        
    }


}
