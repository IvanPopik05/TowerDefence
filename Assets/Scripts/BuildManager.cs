
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject BuildEffect;
    public GameObject DestroyBuildEffect;

    private void Awake() {
        if(instance != null)
        {
            Debug.Log("Больше одного объекта находится на сцене");
            return;
        }
        instance = this;
    }
    private TurretBlueprint turretToBuild;
    private Node SelectedNode; // Отобранная доска
    public NodeUI nodeUI;

    public bool CanBuild {get {return turretToBuild != null;}}
    public bool HasMoney {get {return PlayerStats.Money >= turretToBuild.cost;}}  
    
    public void SelectNode(Node node)
    {
        if(SelectedNode == node)
        {
            DeselectNode();
            return;
        }

        SelectedNode = node; // Отобранным доскам присваеваем доски
        turretToBuild = null;

        nodeUI.SetDesignate(node);
    }

    public void DeselectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild() // Получаем пушку, чтобы построить
    {
        return turretToBuild;
    }
}
