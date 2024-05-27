using UnityEngine;

public class SoundsClick : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Click()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
