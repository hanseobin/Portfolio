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
 *  : PlayerStatus 오브젝트에게 부착
 *  
 *  Functions
 *  : TakeDamage() - 외부에서 호출해 플레이어의 피해 관리
 */