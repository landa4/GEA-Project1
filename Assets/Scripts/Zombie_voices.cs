using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_voices : MonoBehaviour
{
    public bool aggressive;
    public List<AudioSource> aggressiveSounds;
    public List<AudioSource> passiveSounds;
    private AudioSource lastPlaying;
    // Start is called before the first frame update
    void Start()
    {
        aggressive = false;
        lastPlaying = passiveSounds[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(aggressive) {
            if(!lastPlaying.isPlaying) {
                int i = Random.Range(0, aggressiveSounds.Count);
                lastPlaying = aggressiveSounds[i];
                lastPlaying.Play();
            }
        } else {
            if(!lastPlaying.isPlaying) {
                int i = Random.Range(0, passiveSounds.Count);
                lastPlaying = passiveSounds[i];
                lastPlaying.Play();
            }
        }
    }
}
