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
    private int           currentIndex = 0;    // 현재 목표지점 인덱스
    private EnemySpawner  enemySpawner;       

    [SerializeField]
    private int           coin = 0;            // 적 사망시 획득 가능한 골드

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
        // EnemySpawner에서 리스트로 적 정보를 관리하기 때문에 DestroyEnemy() 함수 호출
        enemySpawner.DestroyEnemy(type, this, coin);
    }
}

/*
 * File : Enemy.cs
 * Desc
 *  : enemy 오브젝트에게 부착
 *  
 *  Functions
 *   : SetUp()        - 외부에서 호출해 적 정보, 이동 경로를 설정
 *   : MoveOn()       - 적의 이동을 제어하는 코루틴 함수
 *   : MoveToNext()   - 다음 목표 지점이 있으면 적의 이동 방향을 설정하고, 없으면 OnDie() 함수 호출
 *   : SetDirection() - 적의 이동 방향을 설정
 *   : DiedBy()       - 외부에서 호출해 적의 사망 유형을 설정
 */   
