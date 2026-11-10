using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private readonly int ThievesToActivate = 1;
    private readonly float SoundChangeSpeed = 0.05f;
    private readonly float MinVolume = 0f;
    private readonly float MaxVolume = 0.5f;

    [SerializeField] private ThiefDetector _thiefDetector;

    private AudioSource _audioSource;
    private bool _isNeedAlarm = false;

    private void OnEnable()
    {
        _thiefDetector.ThiefEnter += ProcessThiefEnter;
        _thiefDetector.ThiefExit += ProcessThiefExit;
    }

    private void OnDisable()
    {
        _thiefDetector.ThiefEnter -= ProcessThiefEnter;
        _thiefDetector.ThiefExit -= ProcessThiefExit;
    }

    private void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.volume = MinVolume;
    }

    private void Update()
    {
        ProcessSound();
    }

    private void ProcessSound()
    {
        float targetVolume = _isNeedAlarm ? MaxVolume : MinVolume;
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, SoundChangeSpeed * Time.deltaTime);

        if (_isNeedAlarm && _audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }
        else if (_isNeedAlarm == false && _audioSource.isPlaying && _audioSource.volume == MinVolume)
        {
            _audioSource.Stop();
        }
    }

    private void ProcessThiefEnter(int thievesCount)
    {
        if (thievesCount >= ThievesToActivate)
            _isNeedAlarm = true;
    }

    private void ProcessThiefExit(int thievesCount)
    {
        if (thievesCount < ThievesToActivate)
            _isNeedAlarm = false;
    }
}
