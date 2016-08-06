using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour {

    public AudioClip[] music;

    AudioSource audioSource;

    int currentIndex;

    void Awake()
    {
        currentIndex = Random.Range(0, music.Length);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music[currentIndex];
    }

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	    if(!audioSource.isPlaying)
        {
            currentIndex++;
            if(currentIndex > music.Length-1)
            {
                currentIndex = 0;
            }
            audioSource.clip = music[currentIndex];
            audioSource.Play();
        }
	}
}
