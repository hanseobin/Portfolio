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
 *  : �� ü�¹� ������Ʈ���� ����
 *  
 *  Functions
 *   : SetUp() - �ܺο��� ȣ���� ���� ü���� ����
 */