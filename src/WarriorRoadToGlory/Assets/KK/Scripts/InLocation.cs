using UnityEngine;

public class InLocation : MonoBehaviour
{
    [SerializeField] private Animator _doors;
    public bool onMain;
    
    
    private void Awake()
    {
        onMain = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!onMain)
            {
                _doors.SetTrigger("isClose");
                onMain = true;
                gameObject.SetActive(false);
            }
        }
    }
}
