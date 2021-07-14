
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Colors")]
    public Color hoverColor, ClickColor;
    public Color NotEnoughMoney;
    [Header("Other components")]
    public Vector3 positionTurret;
    public Vector3 positionDestroyEffect;
    private Renderer rend;
    [Header("Optional")]

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool IsUpgraded = false;
    private Color StartColor;
    BuildManager buildManager;
    private void Start() {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionTurret;
    }
    private void OnMouseEnter() { // При наведении мышкой
    if(EventSystem.current.IsPointerOverGameObject())
        return;

        if(!buildManager.CanBuild)
        return;

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = NotEnoughMoney;
        }
    }
    private void OnMouseDown() { // Нажатие мышкой
        if(EventSystem.current.IsPointerOverGameObject())
        return;

        rend.material.color = ClickColor;
        if(turret != null)
        {
            Debug.Log("Нельзя здесь поставить сооружение");
            buildManager.SelectNode(this);
            return;
        }

        if(!buildManager.CanBuild)
            return;

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = NotEnoughMoney;
        }
        //Постройка башни
        BuildTurret(buildManager.GetTurretToBuild());
    }

    public void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("В данный момент вам нельзя купить данное оборудование");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject effect = Instantiate(buildManager.BuildEffect, GetBuildPosition(),Quaternion.identity);
        Destroy(effect, 2f);

        GameObject Object_turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = Object_turret;

        turretBlueprint = blueprint;
        
        Debug.Log($"Сооружение построено, у вас осталось: {PlayerStats.Money}");
    }
    public void UpgradedTurret()
    {
        if(PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("В данный момент вам нельзя купить данное оборудование");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;
         Destroy(turret); // Снос старой пушки
        GameObject effect = Instantiate(buildManager.BuildEffect, GetBuildPosition(),Quaternion.identity);
        Destroy(effect, 2f);

        // Создание новой пушки
        GameObject Object_turret = Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret = Object_turret;

        IsUpgraded = true;
        
        Debug.Log($"Сооружение построено, у вас осталось: {PlayerStats.Money}");
    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellCost();

        // Крутой эффект уничтожения постройки
        GameObject effect = Instantiate(buildManager.DestroyBuildEffect, GetBuildPosition() + positionDestroyEffect,Quaternion.identity);
        Destroy(effect, 2f);

        IsUpgraded = false;
        Destroy(turret);
        turretBlueprint = null;
    }
    private void OnMouseExit() { // При выходе мыши от объекта
    if(EventSystem.current.IsPointerOverGameObject())
        return;

        rend.material.color = StartColor;
        if(!buildManager.CanBuild)
            return;
    }
}
