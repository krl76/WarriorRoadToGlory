using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private GameObject _mainMenu;
    void Update()
    {
        _mainMenu.transform.LookAt(new Vector3(_head.position.x, _mainMenu.transform.position.y, _head.position.z ));
        _mainMenu.transform.forward *= -1;
    }

    void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
