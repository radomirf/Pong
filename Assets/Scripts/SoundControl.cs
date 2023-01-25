using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource playerSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            this.playerSound.Play();
        }
        else
        {
            this.wallSound.Play();
        }
    }
}
