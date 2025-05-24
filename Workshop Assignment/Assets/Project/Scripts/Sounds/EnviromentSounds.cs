using System.Collections;
using UnityEngine;

public class EnviromentSounds : MonoBehaviour
{
    

    [SerializeField] private AudioSource thunderSource;

    [SerializeField] private float lowestValueTime;
    [SerializeField] private float highestValueTime;
    [SerializeField] private float lowestValuePitch;
    [SerializeField] private float highestValuePitch;

    void Start()
    {
        StartCoroutine(ThunderStruck());
    }

    
    void Update()
    {
        
    }

    //Plays a random thunder sound in array at a random time interval between 2 values
    IEnumerator ThunderStruck()
    {

        while (true)
        {
            //Wait a random time between 2 values
            float waitTime = Random.Range(lowestValueTime, highestValueTime);

            yield return new WaitForSeconds(waitTime);

            //Pick a random thunder clip
            AudioClip[] thunder = SoundBank.Instance.thunderSounds;
            thunderSource.clip = thunder[Random.Range(0, thunder.Length)];
            thunderSource.pitch = Random.Range(lowestValuePitch, highestValuePitch);
            
             thunderSource.Play();
            
            
        }
       

       

    }
}
