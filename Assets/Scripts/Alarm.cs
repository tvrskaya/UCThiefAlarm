using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float SoundChangeSpeed = 0.05f;
    private const float MinVolume = 0f;
    private const float MaxVolume = 0.5f;

    private Coroutine _coroutine;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = MinVolume;
    }

    public void Activate()
    {
        StartVolumeChange(MaxVolume);
    }
    
    public void Deactivate()
    {
        StartVolumeChange(MinVolume);
    }

    private void StartVolumeChange(float targetVolume)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeAlarmVolumeRoutine(targetVolume));
    }

    private IEnumerator ChangeAlarmVolumeRoutine(float volume)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, SoundChangeSpeed * Time.deltaTime);
            yield return null;
        }

        if (volume == MinVolume)
            _audioSource.Stop();

        _coroutine = null;
    }
}
