using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ChangeTexture : MonoBehaviour
{
    [SerializeField]private List<AssetReference> addressableTexture;

    private AsyncOperationHandle operatorHandler;
    public Renderer[] sphere;

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
        AssetReference assetReference = addressableTexture[index];
        operatorHandler = assetReference.LoadAssetAsync<Material>();
        yield return operatorHandler;
        sphere[index].material = (Material)operatorHandler.Result;
    }           

}
