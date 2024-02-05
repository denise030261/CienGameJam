using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{

    public GameObject upgradeMenu;
    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void upgrade()
    {
        upgradeMenu.SetActive(true);
        Debug.Log("fdsfgsdfg");
    }
    public void upgradex()
    {
        upgradeMenu.SetActive(false);
    }

}
