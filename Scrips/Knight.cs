using System.Collections;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;                           
    [SerializeField]
    private Transform spawnPoint;                      
    [SerializeField]
    private float     attackRange = 0.0f;                    
    private float     attackRate = 0.0f;                      
    private float     attackDamage = 0.0f;                 
    private bool      isPenetrateAble = false;               
    private float     slowdownAmount = 0.0f;                 

    private void Start()
    {
        SearchRoad();
    }

    public void Setup(float attackDamage, float slowdownAmount, float attackRate, bool isPenetrateAble)
    {
        this.attackDamage    = attackDamage;
        this.slowdownAmount  = slowdownAmount;
        this.attackRate      = attackRate;
        this.isPenetrateAble = isPenetrateAble;
    }

    private void SearchRoad()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("Road");

        Transform closestTarget   = null; 
        float     closestDistance = float.MaxValue; 

        Road closestRoadComponent = null; 

        for ( int i = 0; i < roads.Length; ++i )
        {
            Road roadComponent = roads[i].GetComponent<Road>();

            if ( !roadComponent.isSummonKnight )
            {
                float distance = Vector3.Distance(roads[i].transform.position, transform.position);

                if ( closestTarget == null || distance < closestDistance )
                {
                    closestTarget        = roads[i].transform; 
                    closestDistance      = distance; 
                    closestRoadComponent = roadComponent; 
                }
            }
        }

        if ( closestTarget != null )
        {
            transform.position = closestTarget.position; 

            if ( closestRoadComponent != null )
            {
                closestRoadComponent.isSummonKnight = true;
            }
        }

        StartCoroutine(SpawnBullet());
    }


    private IEnumerator SpawnBullet()
    {
        while ( true )
        {
            GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            clone.transform.localScale = new Vector3 (attackRange, attackRange);

            clone.GetComponent<Bullet>().Setup(attackDamage, slowdownAmount, isPenetrateAble);

            yield return new WaitForSeconds(attackRate);
        }
    }
}

/*
 * File : Knight.cs
 * Desc
 *  : Knight ������Ʈ���� ����
 *  
 * Functions
 *  : SetUp()       - �ܺο��� ȣ���� ������, ��ȭ��, ���ݼӵ�, ���� ���� ���θ� ����
 *  : SearchRoad()  - Ÿ���� ���� ����� Road ������Ʈ�� �ִ� ���� Knight�� ����
 *  : SpawnBullet() - �߻�ü �������� �����ϴ� �ڷ�ƾ �Լ�
 */ 