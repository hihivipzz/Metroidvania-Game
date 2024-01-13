using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;


    public void LoadLevelBtn(string levelToLoad)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        
        StartCoroutine(LoadLevelAsync(levelToLoad));
    }

    IEnumerator LoadLevelAsync(string levelToLoad)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;

            yield return null;
        }
    }


}
