using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkyBoxAddresable : MonoBehaviour
{
    [SerializeField] private List<AssetReference> addressableMaterial;

    private AsyncOperationHandle operatorHandler;


    public void SetTexture(int index)
    {
        StartCoroutine(ChangedTexture(index));
    }
    public IEnumerator ChangedTexture(int index)
    {
        if (operatorHandler.IsValid())
        {
            Addressables.Release(operatorHandler);
        }
        AssetReference assetReference = addressableMaterial[index];
        operatorHandler = assetReference.LoadAssetAsync<Material>();
        yield return operatorHandler;
        RenderSettings.skybox = (Material)operatorHandler.Result;
    }
}
