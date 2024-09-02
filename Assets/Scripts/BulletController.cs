using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public TMP_Text Score_Text;
    private int Score;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(0.25f, 0);

        if (transform.position.x > 14)
        {
            Destroy(gameObject);
        }
    }

}
