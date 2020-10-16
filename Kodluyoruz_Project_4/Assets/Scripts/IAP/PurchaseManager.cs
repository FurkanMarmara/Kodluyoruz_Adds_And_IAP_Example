using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class PurchaseManager : MonoBehaviour, IStoreListener
{

    private static PurchaseManager _instance;

    private static IStoreController storeController;            //Unity purchasing system
    private static IExtensionProvider storeExtensionProvider;        //Farklı Storelar ile konuşma eklentisi

    public static string productIdConsumable = "consumable";
    public static string productIdNonConsumable = "non-consumable";
    public static string productIdSub = "subscription";

    private static string iosProductSubName = "com.unity3d.subscription.new";
    private static string googleProductSubName = "com.unity3d.subscription.original";


    private void Awake()
    {
        if (_instance==null)
        {
            _instance = this;
        }
    }

    public static PurchaseManager Instance()
    {
        return _instance;
    }

    private void Start()
    {
        if (storeController == null)
        {
            InitializePurchasing();
        }
    }

    private void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(productIdConsumable, ProductType.Consumable);
        builder.AddProduct(productIdNonConsumable, ProductType.NonConsumable);
        builder.AddProduct(productIdSub, ProductType.Subscription, new IDs()
            {
                { iosProductSubName,AppleAppStore.Name },
                { googleProductSubName,GooglePlay.Name }
            });
        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return storeController != null && storeExtensionProvider != null;
    }

    public void BuyConsumable()
    {
        ByProduct(productIdConsumable);
    }

    public void BuySubscription()
    {
        ByProduct(productIdSub);
    }

    public void BuyNonConsumable()
    {
        ByProduct(productIdNonConsumable);
    }

    private void ByProduct(string productId)
    {
        if (IsInitialized())
        {
            Product product = storeController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("Cant get item " + product.definition);
            }

        }
        else
        {
            Debug.LogError("Terrible things happened");
        }
    }

    public void RestorePurchase()
    {
        if (!IsInitialized())
        {
            Debug.Log("Terrible things happened");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("Restoring purchase");
            var apple = storeExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((Result) => {
                Debug.Log("Restoring bla bla " + Result);
            });
        }
        else
        {
            Debug.Log("we are not in ios");
        }

    }

    #region Interface Build-In functions
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        storeExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Init failed");
    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        Debug.LogError("Purchase failed " + p + " "+ "with product" + i.definition.storeSpecificId);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (string.Equals(e.purchasedProduct.definition.id,productIdConsumable,StringComparison.Ordinal))
        {
            Debug.Log("product consumable " + e.purchasedProduct.definition + " is bought succesfully");
        }
        else if (string.Equals(e.purchasedProduct.definition.id, productIdNonConsumable, StringComparison.Ordinal))
        {
            Debug.Log("product nonconsumable " + e.purchasedProduct.definition + " is bought succesfully");
        }
        else if (string.Equals(e.purchasedProduct.definition.id, productIdSub, StringComparison.Ordinal))
        {
            Debug.Log("product sub " + e.purchasedProduct.definition + " is bought succesfully");
        }

        return PurchaseProcessingResult.Complete;
    }
    #endregion
}
