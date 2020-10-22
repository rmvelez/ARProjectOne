using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Vector3 TargetPos; // reference to the position of the player
    public float Speed; // the speed at which the enemy moves
    public string conTag; // the tag for the bullet that destroys the enemy
    public string proTag; // the tag for the bullet that helps the enemy

    // Update is called once per frame
    void Update()
    {
        // sets the path for the enemy to follow
        Vector3 directionToTarget = TargetPos - transform.position;

        if (directionToTarget.magnitude < Speed * Time.deltaTime)
        {
            transform.position = TargetPos;
        }
        else
        {
            transform.position += directionToTarget.normalized * Speed * Time.deltaTime;
        }
    }

    // used to check for collisions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(conTag))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag(proTag))
        {
            transform.localScale = new Vector3(0.4f, 1f, 0.4f);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
