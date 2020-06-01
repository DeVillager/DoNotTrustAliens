using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Types;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector]
    public float time;
    public float gameTime = 60f;
    public Texture2D cursor;
    public int enemiesLeft;
    public GameState state = GameState.Game;
    public int score = 0;
    public GameObject gameStartScreen;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        time = gameTime;
        Cursor.SetCursor(cursor, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        if (state == GameState.Game)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                LoadScene("Ending");
            }
        }
    }


    public void LoadScene(string sceneName)
    {
        if (sceneName == "Opening")
        {
            state = GameState.Opening;
        }
        else if (sceneName == "Game")
        {
            SoundManager.Instance.PlayMusic(SoundManager.Instance.battleMusic);
            //gameStartScreen.SetActive(true);
            state = GameState.Game;
        }
        else if (sceneName == "Ending")
        {
            SoundManager.Instance.PlayMusic(SoundManager.Instance.menuMusic);
            state = GameState.Ending;
        }
        ShadeOutScreen.Instance.ShadeOut();
        StartCoroutine(LoadScene(sceneName, 1f));
    }

    private IEnumerator LoadScene(string name, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        ShadeOutScreen.Instance.ShadeOut();
        StartCoroutine(Quit(2f));
    }

    private IEnumerator Quit(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Quitting game...");
        Application.Quit();
    }


}
