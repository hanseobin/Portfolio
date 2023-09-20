using UnityEngine;

public class ObjectDetecter : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner    towerSpawner;
    [SerializeField]
    private TowerDataViewer towerDataViewer;
    [SerializeField]
    private ShopManager     shopManager;
    [SerializeField]
    private GameObject      shopWindow;
    [SerializeField]
    private GameObject      settingsWindow;

    private Camera          mainCamera;
    private Ray             ray;
    private RaycastHit      raycastHit;

    public  RaycastHit RaycastHit => raycastHit;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            towerDataViewer.OffPanel();

            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if ( Physics.Raycast(ray, out raycastHit, Mathf.Infinity) )
            {
                if ( raycastHit.transform.CompareTag("PlacementArea") )
                {
                    if ( !shopWindow.activeSelf && !settingsWindow.activeSelf )
                    {
                        if ( towerSpawner.TowerPrefab != null )
                        {
                            towerSpawner.SpawnTower(raycastHit.transform);
                        }
                    }
                }
                else if ( raycastHit.transform.CompareTag("Tower") )
                {
                    towerDataViewer.OnPanel(raycastHit.transform);
                }
            }
        }
    }
}

/*
 * File : ObjectDetecter.cs
 * Desc
 *  : ObjectDetecter 오브젝트에게 부착
 */