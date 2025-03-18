using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpdateUpgradeButton : MonoBehaviour
{
    public Upgrade upgrade;
    public UpgradeManager upgradeManager;
    public Text costField;
    public Text nameField;
    public Text levelField;
    public Image imageField;
    public Sprite disabledImage;
    public Sprite enabledImage;

    public void updateButton(){
        // Update Text
        nameField.text = upgrade.upgradeName;
        costField.text = upgrade.GetUpgradeCost().ToString();

        // Update Image
        imageField.sprite = upgrade.image;

        // Desplay Level
        if (upgrade.currentLevel < upgrade.maxLevel){
            levelField.text = upgrade.currentLevel.ToString() + " / " + upgrade.maxLevel;
        } else {
            levelField.text = "MAX";
            levelField.color = Color.green;
        }


        if (!TryGetComponent<Button>(out Button button)) return;


        // Get Appearance Type
        if (upgrade.PrerequisitesMet(upgradeManager.allUpgrades) == true){
            button.image.sprite = enabledImage;
            SetCanvasGroupState(1f, true);
        } else if (upgrade.MainPrerequisiteMet(upgradeManager.allUpgrades) == true){
            button.image.sprite = disabledImage;
            SetCanvasGroupState(.4f, false);
        } else {
            SetCanvasGroupState(0f , false);
        }
    }

    private void SetCanvasGroupState(float alpha, bool interactable)
    {
        if (TryGetComponent<CanvasGroup>(out CanvasGroup canvasGroup))
        {
            canvasGroup.alpha = alpha;
            canvasGroup.interactable = interactable;
        }
    }
}

