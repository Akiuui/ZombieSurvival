using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : MonoBehaviour
{
    public RectTransform uiDot;
    public Camera mainCamera;
    public LayerMask hoverLayer;
    public GameObject clickButton;
    private PlayerManager playerManager;


    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    private void Update()
    {
        GameObject obj = GetHoveredGameObject();

        if (obj != null && uiDot.gameObject.activeSelf == true)
        {
            clickButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) { 
                
                if(obj.tag == "HealingBox")
                    playerManager.Heal(50);

                if (obj.tag == "Objective")
                    playerManager.collectObjective();

                Destroy(obj,1f);
            }
        }
        else
        {
            clickButton.SetActive(false);
        }

    }

    private GameObject GetHoveredGameObject()
    {
        // Raycast from UI center dot into the world
        Ray ray = mainCamera.ScreenPointToRay(uiDot.position);
        //print(ray);
        if (Physics.Raycast(ray, out RaycastHit hit, 2f, hoverLayer))
        {
            //print(hit.collider.gameObject);
            return hit.collider.gameObject;
        }
        return null;
    }



}
