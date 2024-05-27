using UnityEngine;

public class StartWave : MonoBehaviour
{
    [SerializeField] private GameObject _interactCanvas;
    [SerializeField] private GameObject _inLocationObject;
    [SerializeField] public AudioClip[] _audioClips;

    private InputController inputController;
    private Animator animator;
    private AudioSource _audioSource;
    private SoundViewers _soundViewers;
    
    private bool inTrigger = false;
    private bool isOpen = false;

    private void Awake()
    {
        inputController = new InputController();

        inputController.LeftHand.Interact.started += ctx => DoorOpen();

        _soundViewers = FindObjectOfType<SoundViewers>();
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOpen)
            {
                inTrigger = true;
                _interactCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
            _interactCanvas.SetActive(false);
        }
    }

    private void DoorOpen()
    {
        if (inTrigger)
        {
            isOpen = true;
            _interactCanvas.SetActive(false);
            _audioSource.PlayOneShot(_audioClips[0]);
            _soundViewers.Barabans();
            animator.SetTrigger("isOpen");
        }
    }
}
