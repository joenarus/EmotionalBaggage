using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject loadingScreen;
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public float totalSceneProgress = 0f;
    public static LoadManager Instance;
    public Text loadingPercent;

    public GameObject gameOverScreen;
    private void Awake()
    {
        Instance = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive);
    }

    public void ActivateGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void LoadTitle()
    {
        loadingScreen.gameObject.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.SQUARE));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress(1));
    }

    public void LoadGame(SceneIndexes scene)
    {
        loadingScreen.gameObject.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCREEN));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress(3));
    }

    public IEnumerator GetSceneLoadProgress(int waitTime)
    {

        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;
                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }
                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;
                loadingPercent.text = totalSceneProgress + "%";
                yield return null;
            }
        }
        yield return new WaitForSeconds(waitTime);
        loadingScreen.gameObject.SetActive(false);
        scenesLoading.Clear();
    }
}
