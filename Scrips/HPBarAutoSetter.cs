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
 *  : 적 체력바 오브젝트에게 부착
 *  
 *  Functions
 *   : SetUp() - 외부에서 호출해 적의 위치를 설정
 */