using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private Transform enemyParent;
    private Enemy enemy;


    private void Start()
    {
        enemyParent = transform.parent;
        enemy = enemyParent.GetComponent<Enemy>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyPatrol")
        {

            enemy.ChangeDir();
            Debug.Log("Switch");
        }
    }
}
