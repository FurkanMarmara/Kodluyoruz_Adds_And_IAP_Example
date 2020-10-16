using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreGameUIController : MonoBehaviour
{
    [SerializeField] Text _bestTimeText;

    private PurchaseManager purchaseManager;

    private void Start()
    {
        purchaseManager = PurchaseManager.Instance();
        WriteBestTime();
    }

    private void WriteBestTime()
    {
        _bestTimeText.text = PlayerPrefs.GetFloat("Score").ToString("F1");
    }

    public void OpenPanel(GameObject panel)
    {
        UIManagerSystem.instance.SetCurrentPanel(panel,true);
    }

    public void ClosePanel(GameObject panel)
    {
        UIManagerSystem.instance.SetCurrentPanel(panel,false);
    }

    public void BuyConsumable()
    {
        purchaseManager.BuyConsumable();
    }

    public void BuyNonConsumable()
    {
        purchaseManager.BuyNonConsumable();
    }

    public void BuySubscription()
    {
        purchaseManager.BuySubscription();
    }

}
