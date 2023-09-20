using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float durationPrefab;
    private float attackDamage;
    private float slowdownAmount;
    private bool  isPenetrateAble; 

    public void Setup(float attackDamage, float slowdownAmount, bool isPenetrateAble)
    {
        this.attackDamage    = attackDamage;
        this.slowdownAmount  = slowdownAmount;
        this.isPenetrateAble = isPenetrateAble;
    }

    private void Update()
    {
        durationPrefab -= Time.deltaTime;

        if ( durationPrefab <= 0 )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Enemy") )
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            Enemy       enemy       = collision.GetComponent<Enemy>();

            enemyHealth.TakeDamage(attackDamage);

            if ( slowdownAmount > 0 && !enemy.isSlowdown )
            {
                enemy.MoveSpeed *= slowdownAmount;
                enemy.isSlowdown = true;
            }

            if ( !isPenetrateAble )
            {
                Destroy(gameObject);
            }
        }
    }
}

/*
 * File : Bullet.cs
 * Desc
 *  : 타워의 발사체 프리팹에 부착
 *  
 *  Functions
 *   : SetUp() - 외부에서 호출해 발사체의 데미지, 둔화량, 관통의 여부를 설정
 */
