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
 *  : 적을 생성하는 EnemySpawner 오브젝트에 부착
 *  
 *  Functions
 *   : StartWave()          - 버튼 클릭시 호출해 웨이브 시작
 *   : SpawnEnemy()         - 현재 웨이브의 설정된 적의 수만큼 적을 생성하고 생성한 적의 정보를 List에 저장하는 코루틴 함수
 *   : DestryEnemy()        - 적 사망시 사망 유형 관리, 사망한 적의 정보를 List에서 제거
 *   : SpawnEnemyHpSlider() - 적의 체력정보를 표시하는 Slider를 생성
 */