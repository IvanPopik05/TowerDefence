using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node designateNode;
    public GameObject ui;
    public Text UpgradeCost;
    public Text SellText;
    public Button UpgradeButton;

    public void SetDesignate(Node _designedTarget)
    {
        designateNode = _designedTarget;
        transform.position = designateNode.GetBuildPosition();
        ui.SetActive(true);

        if(!designateNode.IsUpgraded)
        {
            UpgradeCost.text = designateNode.turretBlueprint.upgradeCost.ToString() + "$";
            UpgradeButton.interactable = true;
        } else
        {
            UpgradeCost.text = "DONE";
            UpgradeButton.interactable = false;
        }

        SellText.text = designateNode.turretBlueprint.GetSellCost().ToString() + "$";
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgraded()
    {
        designateNode.UpgradedTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        designateNode.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
