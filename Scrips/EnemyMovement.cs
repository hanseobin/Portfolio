using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float   moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    private bool    isSlowdown = false;

    public  float MoveSpeed 
    { 
        get { return moveSpeed; } 
        set { moveSpeed = value; } 
    }
    public  bool IsSlowdown { get; set; }

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }
}

/*
 * File : EnemyMovement.cs
 * Desc
 *  : Enemy ������Ʈ���� ����
 *  
 * Functions
 *  : SetDirection() - �ܺο��� ȣ���� �̵� ������ ����
 */  