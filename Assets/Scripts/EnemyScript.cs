using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public int health;
    public AudioClip enemyHit;
    public AudioClip enemyDeath;
    public TMP_Text Lives_Text;
    private int TotalLives;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health--;
            AudioSource.PlayClipAtPoint(enemyHit, transform.position);

            if (speed == -0.07f)
            {
                speed = 0;
                StartCoroutine(Wait1(0.5f));
            }
            if (speed == -0.055f)
            {
                speed = 0;
                StartCoroutine(Wait2(0.5f));
            }
            if (speed == -0.04f)
            {
                speed = 0;
                StartCoroutine(Wait3(0.5f));
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            Lives_Text.text = "Lives: " + TotalLives;
        }
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(speed, 0);

        if (health < 1)
        {
            AudioSource.PlayClipAtPoint(enemyDeath, transform.position);
            Destroy(gameObject);
        }
    }

    IEnumerator Wait1(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = -0.07f;
    }
    IEnumerator Wait2(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = -0.055f;
    }
    IEnumerator Wait3(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = -0.04f;
    }
}
