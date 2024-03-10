using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFX : MonoBehaviour
{
    public AudioSource MyFX;
    public AudioClip HoverFx;
    public AudioClip ClickFx;

    public void HoverSound()
    {
        MyFX.PlayOneShot(HoverFx);
    }

    public void ClickSound()
    {
        MyFX.PlayOneShot(ClickFx);
    }
}
