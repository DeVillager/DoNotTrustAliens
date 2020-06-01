using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using Types;

public class Enemy : MonoBehaviour
{
    public EnemyColor color;
    private Color col;
    public int enemyNumber;
    public AudioClip die;
    public AudioClip wrong;

    private void Start()
    {
        color = (EnemyColor)Random.Range(0, 3);

        switch (color)
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
        GetComponent<SpriteRenderer>().color = col;
    }

    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log($"{mousePos} joo");
        GameManager.Instance.enemiesLeft--;
        if (enemyNumber == UIManager.Instance.chosenEnemyNumber && color == UIManager.Instance.chosenColor)
        {
            GameManager.Instance.score -= 100;
            SoundManager.Instance.Play(wrong);
        }
        else
        {
            GameManager.Instance.score += 100;
            SoundManager.Instance.Play(die);
        }

        ParticleManager.Instance.PlayBlood(transform.position);
        Destroy(gameObject);
    }

}
