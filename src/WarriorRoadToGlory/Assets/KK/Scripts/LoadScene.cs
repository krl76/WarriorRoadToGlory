using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver;
using Slider = UnityEngine.UI.Slider;

public class LoadScene : MonoBehaviour
{
    [Header("Load Sets")]
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private GameObject _load;

    private float progressValue;

    public void SceneLoad(string nameScene)
    {
        _load.SetActive(true);
        StartCoroutine(LoadSceneAsync(nameScene));
    }

    private IEnumerator LoadSceneAsync(string nameScene)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(nameScene);

        while (!loadOperation.isDone)
        {
            progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _progressSlider.value = progressValue;
            yield return null;
        }
        //_load.SetActive(false);
    }
}
