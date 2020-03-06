using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int currentLevel = 1;
    public int endLevel;
    public bool isReloading;
    public bool finishlevel;


    public static GameManager instance;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (SceneManager.sceneCount < 2)
            SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
    }
    private void Update()
    {
        /*
        if (Input.GetKeyDown("r"))
        {
            Restart();
        }
        */
    }

    public void endlevel()
    {
        if (finishlevel)
            return;
        finishlevel = true;
        StartCoroutine(LoadNextLevel());
    }
    public void Restart()
    {
        if (isReloading)
            return;
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        isReloading = true;
        AsyncOperation unload = SceneManager.UnloadSceneAsync(currentLevel);

        while (!unload.isDone)
        {
            yield return 0;
        }
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
        isReloading = false;
    }

    IEnumerator LoadNextLevel()
    {

        yield return new WaitForSeconds(0.5f);
        if (endLevel != currentLevel + 1)
        {

            AsyncOperation unload = SceneManager.UnloadSceneAsync(currentLevel);

            while (!unload.isDone)
            {
                yield return 0;
            }
            currentLevel++;
            SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
        }

        finishlevel = false;

    }

}
