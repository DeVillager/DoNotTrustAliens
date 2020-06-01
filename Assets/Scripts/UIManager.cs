using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : Singleton<UIManager>
{
    public Sprite[] sprites;
    //[HideInInspector]
    public EnemyColor chosenColor;
    public Enemy chosenEnemy;
    private Color col;
    public Image enemyImage;
    [HideInInspector]
    public int chosenEnemyNumber;
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI scoreText;
    public GameObject TrustPanel;
    public Texture2D cursor;
    

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        ChooseEnemy();
        ChooseColor();
        StartCoroutine(HidePanel(1.8f));
    }

    public void ChooseEnemy()
    {
        chosenEnemyNumber = UnityEngine.Random.Range(0, sprites.Length);
        enemyImage.sprite = sprites[chosenEnemyNumber];
    }

    public void ChooseColor()
    {
        int randInt = UnityEngine.Random.Range(0, 3);
        chosenColor = (EnemyColor)randInt;
        switch (chosenColor)
        {
            case EnemyColor.Magenta:
                col = Color.magenta;
                break;
            case EnemyColor.Green:
                col = Color.green;
                break;
            case EnemyColor.Cyan:
                col = Color.cyan;
                break;
            default:
                break;
        }
        enemyImage.color = col;
    }


    private void Update()
    {
        timeLeftText.text = $"Time:\n{(int)GameManager.Instance.time}";
        scoreText.text = $"Score:\n{(int)GameManager.Instance.score}";
    }

    public IEnumerator HidePanel(float time)
    {
        yield return new WaitForSeconds(time);
        TrustPanel.SetActive(false);
    }
}
