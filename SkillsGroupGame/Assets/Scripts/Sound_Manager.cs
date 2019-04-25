using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource arrive;
    public AudioSource leave;
    public AudioSource leaveFail;
    public AudioSource partChange;
    public AudioSource Background;

    public void ChangeArrive(AudioSource newArrive)
    {
        arrive.clip = newArrive.clip;
    }

    public void PlayArrive()
    {
        arrive.Play();
    }

    public void PlayLeave()
    {
        leave.Play();
        Background.Stop();
    }

    public void PlayLeaveFail()
    {
        leaveFail.Play();
        Background.Stop();
    }

    public void PartChange()
    {
        partChange.Play();
    }
}
