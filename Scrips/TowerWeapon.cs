using System.Collections;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }

public class TowerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject   bulletPrefab;                          
    [SerializeField]
    private Transform    spawnPoint;                       
    [SerializeField]
    private float        fireForce = 0.0f;                 
    [SerializeField]
    private float        attackRate = 0.0f;              
    [SerializeField]
    private float        attackDamage = 0.0f;        
    [SerializeField]
    private float        attackRange = 0.0f;          
    [SerializeField]
    private bool         canPenetrate = false;            
    [SerializeField]
    private float        slowDownAmount = 0.0f;             
    [SerializeField]
    private float        towerPrice = 0.0f;                
    [SerializeField]
    private bool         isSummonTower = false;                  
    private WeaponState  weaponState = WeaponState.SearchTarget; 
    private Transform    attackTarget = null;                 
    private EnemySpawner enemySpawner;                    

    public  float Damage => attackDamage;
    public  float Rate   => attackRate;
    public  float Range  => attackRange;
    public  float Slow   => slowDownAmount;
    public  float TowerPrice => towerPrice; 
    
    public void Setup(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;

        if ( !isSummonTower )
        {
            ChangeState(WeaponState.SearchTarget);
        }
        else if ( isSummonTower ) 
        {
            SummonKnight();
        }
    }

    public void ChangeState(WeaponState newStatus)
    {
        StopCoroutine(weaponState.ToString());

        weaponState = newStatus;

        StartCoroutine(weaponState.ToString());
    }

    private IEnumerator SearchTarget()
    {
        while ( true )
        {
            float closestTarget = Mathf.Infinity;

            for ( int i = 0; i < enemySpawner.EnemyList.Count; ++ i ) 
            {
                float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, spawnPoint.position);

                if ( distance <= attackRange && distance <= closestTarget )
                {
                    closestTarget = distance;
                    attackTarget  = enemySpawner.EnemyList[i].transform;
                }
            }

            if ( attackTarget != null )
            {
                ChangeState(WeaponState.AttackToTarget);
            }

            yield return null;
        }
    }

    private IEnumerator AttackToTarget()
    {
        while ( true ) 
        {
            if ( attackTarget == null )
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            float distance = Vector3.Distance(attackTarget.position, spawnPoint.position);
            if ( distance > attackRange )
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            yield return new WaitForSeconds(attackRate);

            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Bullet>().Setup(attackDamage, slowDownAmount, canPenetrate);

        if ( attackTarget != null )
        {
            Vector3 direction        = (attackTarget.position - spawnPoint.position).normalized;
            float   angle            = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            clone.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * fireForce);
        }
    }

    private void SummonKnight()
    {
        GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Knight>().Setup(attackDamage, slowDownAmount, attackRate, canPenetrate);
    }
}

/*
 * File : SoundManager.cs
 * Desc
 *  : SoundMgr 오브젝트에게 부착
 *  
 *  Functions
 *  : Setup()          - 외부에서 호출해서 타워 유형을 설정
 *  : ChangeState()    - 타워의 상태를 변경
 *  : SearchTarget()   - 적을 찾는 코루틴 함수
 *  : AttackToTarget() - 발견한 적을 공격하는 함수
 *  : SpawnBullet()    - 프리팹 발사체를 생성
 *  : SummonKnight()   - Knight 프리팹을 생성
 */
