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
 *  : Ÿ���� �߻�ü �����տ� ����
 *  
 *  Functions
 *   : SetUp() - �ܺο��� ȣ���� �߻�ü�� ������, ��ȭ��, ������ ���θ� ����
 */
