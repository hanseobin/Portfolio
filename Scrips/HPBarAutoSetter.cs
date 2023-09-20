using UnityEngine;

public class HPBarAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3       distance = Vector3.down;
    private Transform     enemyTransform;
    private RectTransform rectTransform; 

    public void Setup(Transform enemyTransform)
    {
        this.enemyTransform = enemyTransform;

        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if ( enemyTransform == null )
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemyTransform.position);
        rectTransform.position = screenPosition + distance;
    }
}

/*
 * File : EnemyHealth.cs
 * Desc
 *  : �� ü�¹� ������Ʈ���� ����
 *  
 *  Functions
 *   : SetUp() - �ܺο��� ȣ���� ���� ��ġ�� ����
 */