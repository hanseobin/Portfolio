using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] 
    private float maxHP; 
    private float currentHP;
    private bool  isDied = false;
    private Enemy enemy;

    public  float MaxHP => maxHP;
    public  float CurrentHP => currentHP;

    private void Start()
    {
        currentHP = maxHP;

        enemy = GetComponent<Enemy>();
    }

    public void TakeDamage(float damageAmount)
    {
        if ( isDied ) { return; }

        currentHP -= damageAmount;

        if ( currentHP <= 0 )
        {
            isDied = true;
            enemy.DiedBy(EnemyDestroyType.Kill);
        }
    }
}

/*
 * File : EnemyHealth.cs
 * Desc
 *  : enemy 오브젝트에게 부착
 *  
 *  Functions
 *   : SetUp()      - 외부에서 호출해 발사체의 데미지, 둔화량, 관통의 여부를 설정
 *   : TakeDamage() - 외부에서 호출해 적의 피해 관리
 */