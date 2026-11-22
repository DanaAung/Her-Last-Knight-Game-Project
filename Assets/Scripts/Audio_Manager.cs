using System.Collections;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [Header(" Audio Source")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header(" Audio Clips ")]
    public AudioClip background;
    public AudioClip att;
    public AudioClip jump;
    public AudioClip footstep;
    public AudioClip victory;
    public AudioClip defeat;

    private Coroutine footstepCoroutine;
    private readonly float footstepTime = .5f;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StartFootstepSound()
    {
        footstepCoroutine ??= StartCoroutine(FootstepLoop());
    }

    public void StopFootstepSound()
    {
        if (footstepCoroutine != null )
        {
            StopCoroutine(footstepCoroutine);
            footstepCoroutine = null;
        }
    }

    private IEnumerator FootstepLoop()
    {
        while (true)
        {
            SFXSource.PlayOneShot(footstep);
            yield return new WaitForSeconds(footstepTime);
        }

    }

    public void PlayEndGame(AudioClip clip)
    {
        musicSource.Pause();
        SFXSource.PlayOneShot(clip);
    }
}
