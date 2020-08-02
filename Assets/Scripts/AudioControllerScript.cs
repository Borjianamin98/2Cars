using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerScript : MonoBehaviour {

    public AudioSource receivePointAudio;
    public AudioSource gameOverAudio;

    public void playReceivePointAudio() {
        receivePointAudio.Play();
    }

    public void playGameOverAudio() {
        gameOverAudio.Play();
    }

}
