using UnityEngine;

public class SoundsStep : MonoBehaviour
{
    private InputController _inputController;
    private AudioSource _audioSource;
    private bool isStep = false;

    private void Awake()
    {
        _inputController = new InputController();
        _inputController.LeftHand.Move.started += ctx => MoveVoice(true);
        _inputController.LeftHand.Move.canceled += ctx => MoveVoice(false);

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _inputController.Enable();
    }

    private void OnDisable()
    {
        _inputController.Disable();
    }

    private void MoveVoice(bool isSteping)
    {
        if (isSteping)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
