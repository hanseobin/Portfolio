using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ButtonPrefabPair
{
    public Button     button;
    public GameObject towerPrefab;
}

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private ButtonPrefabPair[] buttonPrefabPairs;
    [SerializeField] 
    private TowerSpawner       towerSpawner;

    private void Start()
    {
        foreach ( ButtonPrefabPair pair in buttonPrefabPairs )
        {
            pair.button.onClick.AddListener(() => OnButtonClick(pair.towerPrefab));
        }
    }

    private void OnButtonClick(GameObject prefab)
    {
        towerSpawner.TowerPrefab = prefab;
    }
}

/*
 * File : ShopManager.cs
 * Desc
 *  : ShopManager 오브젝트에게 부착
 *  
 *  Functions
 *  : OnButtonClick() - 버튼을 클릭하면 버튼의 페어 프리팹을 선택
 */