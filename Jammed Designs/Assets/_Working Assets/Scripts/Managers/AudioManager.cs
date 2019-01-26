using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public AudioClip SelectClip;
    public AudioClip ClickClip;
    public AudioClip ErrorClip;
    public AudioClip DominoClip;

    public AudioSource EffectSource;

    public void PlaySelect()
    {
        EffectSource.pitch = Random.Range(0.9F, 1.1F);
        EffectSource.PlayOneShot(SelectClip);
    }

    public void PlayClick()
    {
        EffectSource.pitch = Random.Range(0.9F, 1.1F);
        EffectSource.PlayOneShot(ClickClip);
    }

    public void PlayError()
    {
        EffectSource.pitch = Random.Range(0.9F, 1.1F);
        EffectSource.PlayOneShot(ErrorClip);
    }

    public void PlayDomino()
    {
        EffectSource.PlayOneShot(DominoClip);
    }
}
