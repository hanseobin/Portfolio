using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI  textDamage;
    [SerializeField]
    private TextMeshProUGUI  textRate;
    [SerializeField]
    private TextMeshProUGUI  textRange;
    [SerializeField]
    private TextMeshProUGUI  textSlow;
    [SerializeField]
    private TowerAttackRange towerAttackRange;

    private TowerWeapon      currentTower;

    private void Awake()
    {
        OffPanel();
    }

    public void OnPanel(Transform towerWeapon)
    {
        currentTower = towerWeapon.GetComponent<TowerWeapon>();

        gameObject.SetActive(true);

        UpdateTowerData();

        if ( currentTower.Range > 0  )
        {
            towerAttackRange.OnAttackRange(currentTower.transform.position, currentTower.Range);
        }
    }
    
    public void OffPanel()
    {
        gameObject.SetActive(false);

        towerAttackRange.OffAttackRange();
    }

    private void UpdateTowerData()
    {
        if ( currentTower.Damage > 0 )
        {
            textDamage.text = "Dmg : " + currentTower.Damage;
        }

        if ( currentTower.Rate > 0 )
        {
            textRate.text = "Rate : 1/" + currentTower.Rate + "s";
        }

        if ( currentTower.Range > 0 )
        {
            textRange.text = "Range : " + currentTower.Range;
        }

        if ( currentTower.Slow > 0 )
        {
            textSlow.text = "Slow : " + (100 * (1 - currentTower.Slow)) + "%";
        }
    }
}

/*
 * File : TowerDataViewer.cs
 * Desc
 *  : TowerPanel 오브젝트에게 부착
 *  
 *  Functions
 *   : OnPanel()         - 외부에서 호출해 매개변수의 정보를 활성화
 *   : OffPanel()        - 외부에서 호출해 TowerPanel을 비활성화
 *   : UpdataTowerData() - TowerPanel에 선택한 타워의 정보를 출력
 */