using System.Collections;
using UnityEngine;

public enum EnemyDestroyType 
{
    Kill = 0, 
    Arrive 
}

public class Enemy : MonoBehaviour
{
    private int           wayPointCount;       
    private Transform[]   wayPoints;          
    private int           currentIndex = 0;    // ���� ��ǥ���� �ε���
    private EnemySpawner  enemySpawner;       

    [SerializeField]
    private int           coin = 0;            // �� ����� ȹ�� ������ ���

    [SerializeField]
    private float         moveSpeed     = 0.0f;
    private Vector3       moveDirection = Vector3.zero;
    public  bool          isSlowdown { get; set; }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        this.enemySpawner = enemySpawner;

        wayPointCount  = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;
        
        StartCoroutine(MoveOn());
    }

    private IEnumerator MoveOn()
    {
        MoveToNext();

        while ( true ) 
        {
            if ( Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02 * moveSpeed )
            {
                MoveToNext();
            }

            yield return null;
        }
    }

    private void MoveToNext()
    {
        if ( currentIndex < wayPointCount - 1 )
        {
            transform.position = wayPoints[currentIndex].position;

            currentIndex ++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            SetDirection(direction);
        }
        else
        {
            coin = 0;

            DiedBy(EnemyDestroyType.Arrive);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

    public void DiedBy(EnemyDestroyType type)
    {
        // EnemySpawner���� ����Ʈ�� �� ������ �����ϱ� ������ DestroyEnemy() �Լ� ȣ��
        enemySpawner.DestroyEnemy(type, this, coin);
    }
}

/*
 * File : Enemy.cs
 * Desc
 *  : enemy ������Ʈ���� ����
 *  
 *  Functions
 *   : SetUp()        - �ܺο��� ȣ���� �� ����, �̵� ��θ� ����
 *   : MoveOn()       - ���� �̵��� �����ϴ� �ڷ�ƾ �Լ�
 *   : MoveToNext()   - ���� ��ǥ ������ ������ ���� �̵� ������ �����ϰ�, ������ OnDie() �Լ� ȣ��
 *   : SetDirection() - ���� �̵� ������ ����
 *   : DiedBy()       - �ܺο��� ȣ���� ���� ��� ������ ����
 */   
