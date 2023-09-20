using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private PlayerCoin   playerCoin;
    [SerializeField]
    private EnemySpawner enemySpawner; // 현재 맵에 존재하는 적 리스트 정보
    private GameObject   towerPrefab;
    private float        paymentCoin;

    public GameObject TowerPrefab
    {
        get { return towerPrefab; }
        set { towerPrefab = value; }
    }

    public void SpawnTower(Transform tileTransform)
    {
        PlacementArea placementArea = tileTransform.GetComponent<PlacementArea>();
        paymentCoin = towerPrefab.GetComponent<TowerWeapon>().TowerPrice;

        if ( placementArea.isBuildTower == true ) { return; }
        if ( paymentCoin > playerCoin.CurrentCoin ) { return; }

        placementArea.isBuildTower = true;
        Vector3    position = tileTransform.position + Vector3.back;
        GameObject clone    = Instantiate(towerPrefab, position, Quaternion.identity);
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);

        playerCoin.CurrentCoin -= paymentCoin;
        towerPrefab = null;
        paymentCoin = 0;
    }
}

/*
 * File : TowerSpawner.cs
 * Desc
 *  : 타워 생성 제어
 *  
 *  Functions
 *   : SpawnTower() - 매개 변수의 위치에 타워 생성
 */
