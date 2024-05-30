using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldLeftHand : MonoBehaviour
{
    [SerializeField] GameObject attachPoint;
    void Start()
    { }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "LeftHand")
        {
            attachPoint.transform.eulerAngles = new Vector3(attachPoint.transform.eulerAngles.x, attachPoint.transform.eulerAngles.y, attachPoint.transform.eulerAngles.z - 180);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        attachPoint.transform.eulerAngles = new Vector3(attachPoint.transform.eulerAngles.x, attachPoint.transform.eulerAngles.y, attachPoint.transform.eulerAngles.z + 180);
    }
}
