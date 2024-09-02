using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int EnemySelected;
    private int EnemyLane;
    public GameObject snakePrefab;
    public GameObject slimePrefab;
    public GameObject snailPrefab;

    void Start()
    {
        EnemySpawns();
        StartCoroutine(EnemyAttacks());
    }

    IEnumerator EnemyAttacks()
    {
        yield return new WaitForSeconds(2);

        EnemySpawns();

        StartCoroutine(EnemyAttacks());
    }

    private void EnemySpawns()
    {
        EnemySelected = Random.Range(0, 3);
        EnemyLane = Random.Range(0, 5);

        if (EnemySelected == 0)
        {
            if (EnemyLane == 0)
            {
                Instantiate(snakePrefab, new Vector3 (9.6f, 0.15f, 0), new Quaternion (0,0,0,0));
            }
            if (EnemyLane == 1)
            {
                Instantiate(snakePrefab, new Vector3(9.6f, -0.6f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 2)
            {
                Instantiate(snakePrefab, new Vector3(9.6f, -1.5f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 3)
            {
                Instantiate(snakePrefab, new Vector3(9.6f, -2.5f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 4)
            {
                Instantiate(snakePrefab, new Vector3(9.6f, -3.2f, 0), new Quaternion(0, 0, 0, 0));
            }
        }
        if (EnemySelected == 1)
        {
            if (EnemyLane == 0)
            {
                Instantiate(slimePrefab, new Vector3(9.6f, 0.15f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 1)
            {
                Instantiate(slimePrefab, new Vector3(9.6f, -0.6f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 2)
            {
                Instantiate(slimePrefab, new Vector3(9.6f, -1.5f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 3)
            {
                Instantiate(slimePrefab, new Vector3(9.6f, -2.5f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 4)
            {
                Instantiate(slimePrefab, new Vector3(9.6f, -3.2f, 0), new Quaternion(0, 0, 0, 0));
            }
        }
        if (EnemySelected == 2)
        {
            if (EnemyLane == 0)
            {
                Instantiate(snailPrefab, new Vector3(9.6f, 0.15f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 1)
            {
                Instantiate(snailPrefab, new Vector3(9.6f, -0.6f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 2)
            {
                Instantiate(snailPrefab, new Vector3(9.6f, -1.5f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 3)
            {
                Instantiate(snailPrefab, new Vector3(9.6f, -2.5f, 0), new Quaternion(0, 0, 0, 0));
            }
            if (EnemyLane == 4)
            {
                Instantiate(snailPrefab, new Vector3(9.6f, -3.2f, 0), new Quaternion(0, 0, 0, 0));
            }
        }

    }
}
