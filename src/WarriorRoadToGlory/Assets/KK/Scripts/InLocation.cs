using UnityEngine;

public class InLocation : MonoBehaviour
{
    [SerializeField] private Animator _doors;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _inWave;

    private StartWave _startWave;
    public bool onMain;
    
    private void Awake()
    {
        _startWave = FindObjectOfType<StartWave>();
        onMain = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!onMain)
            {
                _audioSource.PlayOneShot(_startWave._audioClips[1]);
                _doors.SetTrigger("isClose");
                onMain = true;
                gameObject.SetActive(false);
                _inWave.gameObject.SetActive(true);
            }
        }
    }
}
