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
 *  : enemy ������Ʈ���� ����
 *  
 *  Functions
 *   : SetUp()      - �ܺο��� ȣ���� �߻�ü�� ������, ��ȭ��, ������ ���θ� ����
 *   : TakeDamage() - �ܺο��� ȣ���� ���� ���� ����
 */