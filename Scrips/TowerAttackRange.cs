using UnityEngine;

public class TowerAttackRange : MonoBehaviour
{
    private void Awake()
    {
        OffAttackRange();
    }

    public void OnAttackRange(Vector3 position, float range)
    {
        gameObject.SetActive(true);

        float diameter = range * 2.0f;
        transform.localScale = Vector3.one * diameter;

        transform.localPosition = position;
    }

    public void OffAttackRange()
    {
        gameObject.SetActive(false);
    }
}

/*
 * File : TowerAttackRange.cs
 * Desc
 *  : TowerAttackRange ������Ʈ���� ����
 *  
 *  Functions
 *   : OnAttackRange()  - �ܺο��� ȣ���� TowerAttackRange ������Ʈ�� Ȱ��ȭ
 *   : OffAttackRange() - �ܺο��� ȣ���� TowerAttackRange ������Ʈ�� ��Ȱ��ȭ
 */