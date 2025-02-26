using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePreviewBehavior : MonoBehaviour
{
    
    public Text title;
    public Text description;

    void Start()
    {
        UpgradeManager.OnUpgradeButtonSelected += UpdatePreview;
    }

    public void UpdatePreview(Upgrade upgrade)
    {
        title.text = upgrade.upgradeName;
        description.text = upgrade.description;
    }
}
