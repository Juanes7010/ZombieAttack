using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] AudioClip[] soundClips;

    AudioSource sound;
    float randomTime;
    int randomSound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();

        randomTime = Random.Range(10, 30);
        randomSound = Random.Range(0, soundClips.Length);
        Invoke("PlaySound", randomTime);
    }
    void PlaySound()
    {
        randomTime = Random.Range(20, 80);
        randomSound = Random.Range(0, soundClips.Length);
        sound.PlayOneShot(soundClips[randomSound], 1.0f);
        
        Debug.Log("metodo");
        Debug.Log(randomTime);
        Invoke("PlaySound", randomTime);
    }
}
