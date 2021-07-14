using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint MissileLauncher;
    public TurretBlueprint LazerBeamer;
    BuildManager buildManager;

    private void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Тыкается на пушку");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Тыкается на Ракетную установку");
        buildManager.SelectTurretToBuild(MissileLauncher);
    }
    public void SelectLazerBeamer()
    {
        Debug.Log("Тыкается на лазер");
        buildManager.SelectTurretToBuild(LazerBeamer);
    }
    
}
