using UnityEngine;
using UnityEngine.UI;

public class EnemyHpViewer : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private Slider      enemyHpSlider;

    public void Setup(EnemyHealth enemyHealth)
    {
        this.enemyHealth = enemyHealth;

        enemyHpSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        enemyHpSlider.value = enemyHealth.CurrentHP / enemyHealth.MaxHP;
    }
}

/*
 * File : EnemyHpViewer.cs
 * Desc
 *  : 적 체력바 오브젝트에게 부착
 *  
 *  Functions
 *   : SetUp() - 외부에서 호출해 적의 체력을 설정
 */