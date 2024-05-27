using UnityEngine;

public class SoundsGame : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;
    private WaveManager _waveManager;
    private Final _final;
    
    private bool _isPlaying;
    private bool _isPlaying2;
    private bool _isPlaying3;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _waveManager = FindObjectOfType<WaveManager>();
        _final = FindObjectOfType<Final>();
    }

    private void Update()
    {
        if (_final.inFinal && !_isPlaying3)
        {
            _audioSource.Stop();
            _audioSource.clip = _audioClips[2];
            _audioSource.Play();
            _isPlaying3 = true;
        }
        if (_waveManager.inWave && !_isPlaying2)
        {
            _isPlaying = false;
            _audioSource.Stop();
            _audioSource.clip = _audioClips[1];
            _audioSource.Play();
            _isPlaying2 = true;
        }
        if (!_waveManager.inWave && !_isPlaying)
        {
            _audioSource.clip = _audioClips[0];
            _audioSource.Play();
            _isPlaying = true;
        }
    }
}
