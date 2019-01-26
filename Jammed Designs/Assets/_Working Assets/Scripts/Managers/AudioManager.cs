using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public AudioClip SelectClip;
    public AudioClip ClickClip;
    public AudioClip ErrorClip;
    public AudioClip DominoClip;
    public AudioClip TypingClip;

    public AudioSource EffectSource;
    public AudioSource TickTock;
    public AnimationCurve TickTockCurve;

    protected override void Awake()
    {
        base.Awake();
        GameManager.Instance.Started += OnStarted;
    }

    private void Update()
    {
        TickTock.volume = TickTockCurve.Evaluate(GameManager.Instance.NormalizedTime);
    }

    private void OnStarted()
    {
        TickTock.Play();
    }

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

    public void PlayTyping()
    {
        EffectSource.PlayOneShot(TypingClip);
    }
}
