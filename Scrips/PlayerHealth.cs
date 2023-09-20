using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverWindow;
    [SerializeField]
    private int        maxHP = 10;
    private int        currentHP;

    public  int MaxHP => maxHP;
    public  int CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if ( currentHP <= 0 )
        {
            Time.timeScale = 0f;
            gameOverWindow.SetActive(true);
        }
    }
}

/*
 * File : PlayerHealth.cs
 * Desc
 *  : PlayerStatus ������Ʈ���� ����
 *  
 *  Functions
 *  : TakeDamage() - �ܺο��� ȣ���� �÷��̾��� ���� ����
 */