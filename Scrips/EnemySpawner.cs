using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject   enemyHpSliderPrefab; 
    [SerializeField]
    private Transform    canvasTransform;  
    
    [SerializeField]
    private Transform[]  wayPoints;     
    
    [SerializeField]
    private PlayerHealth playerHealth;         
    [SerializeField]
    private PlayerCoin   playerCoin;       
    
    private Wave         currentWave;
    private int          currentEnemyCount;
    private List<Enemy>  enemyList;           

    public  List<Enemy> EnemyList => enemyList;
    public  int CurrentEnemyCount => currentEnemyCount;
    public  int MaxEnemyCount => currentWave.maxEnemyCount;

    private void Awake()
    {
        enemyList = new List<Enemy>();
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;

        currentEnemyCount = currentWave.maxEnemyCount;

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnEnemyCount = 0;

        while ( spawnEnemyCount < currentWave.maxEnemyCount )
        {
            int        enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject clone      = Instantiate(currentWave.enemyPrefabs[enemyIndex]);       
            Enemy      enemy      = clone.GetComponent<Enemy>();   

            enemy.Setup(this, wayPoints);                           
            enemyList.Add(enemy);                     

            SpawnEnemyHpSlider(clone);

            spawnEnemyCount ++;

            yield return new WaitForSeconds(currentWave.spawnTime);      
        }
    }

    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy, int coin)
    {
        if ( type == EnemyDestroyType.Arrive )
        {
            playerHealth.TakeDamage(1);
        }
        else if ( type == EnemyDestroyType.Kill )
        {
            playerCoin.CurrentCoin += coin;
        }

        currentEnemyCount --;
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHpSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<HPBarAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHpViewer>().Setup(enemy.GetComponent<EnemyHealth>());
    }
}

/*
 * File : EnemySpawner.cs
 * Desc
 *  : ���� �����ϴ� EnemySpawner ������Ʈ�� ����
 *  
 *  Functions
 *   : StartWave()          - ��ư Ŭ���� ȣ���� ���̺� ����
 *   : SpawnEnemy()         - ���� ���̺��� ������ ���� ����ŭ ���� �����ϰ� ������ ���� ������ List�� �����ϴ� �ڷ�ƾ �Լ�
 *   : DestryEnemy()        - �� ����� ��� ���� ����, ����� ���� ������ List���� ����
 *   : SpawnEnemyHpSlider() - ���� ü�������� ǥ���ϴ� Slider�� ����
 */