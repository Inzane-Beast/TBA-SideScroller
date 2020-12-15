using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlaying : MonoBehaviour
{
    public AudioSource wistle;
    public AudioSource click;
    public AudioSource coincollect;
    public AudioSource jump;

    public void playwistle()
    {
        wistle.Play();
    }
    public void playclick()
    {
        click.Play();
    }
    public void playjump()
    {
        jump.Play();
    }
    public void playcoin()
    {
        coincollect.Play();
    }
}
