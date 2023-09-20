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
 *  : TowerAttackRange 오브젝트에게 부착
 *  
 *  Functions
 *   : OnAttackRange()  - 외부에서 호출해 TowerAttackRange 오브젝트를 활성화
 *   : OffAttackRange() - 외부에서 호출해 TowerAttackRange 오브젝트를 비활성화
 */