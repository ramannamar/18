using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}