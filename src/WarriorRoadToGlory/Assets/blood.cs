using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ToDestroy());
    }

    IEnumerator ToDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(this);
    }
}
