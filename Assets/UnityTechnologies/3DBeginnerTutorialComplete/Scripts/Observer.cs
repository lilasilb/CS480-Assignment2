using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;
    public bool isLookingAtPlayer;

    // used to differentiate enemy types so that exclamation mark will appear only for ghosts
    public enum EnemyType
    {
        Ghost,
        Gargoyle
    }
    public EnemyType enemyType;

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update ()
    {
        isLookingAtPlayer = false;

        // direction player is in to look at
        Vector3 direction = player.position - transform.position + Vector3.up;
        // normalize for dot product usage
        Vector3 toPlayer = direction.normalized;

        // compares where enemy is facing to direction of player (1 means player is directly in front)
        float dot = Vector3.Dot(transform.forward, toPlayer);

        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycastHit;
        
        if (Physics.Raycast (ray, out raycastHit))
        {
            if (raycastHit.collider.transform == player)
            {
                // dot being exactly 1 is rare, so give boundary of 0.8
                if (dot > 0.8f)
                {
                    isLookingAtPlayer = true;
                }

                if (m_IsPlayerInRange)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
