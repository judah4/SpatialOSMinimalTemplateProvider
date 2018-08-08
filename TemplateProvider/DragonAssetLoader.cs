using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Improbable.Assets;
using UnityEngine;
using Object = UnityEngine.Object;

public class DragonAssetLoader : IAssetLoader<GameObject>
{
    private EntityPrefabs _entityPrefabs;

    private List<GameObject> _loadedPrefabs = new List<GameObject>();

    private Transform _transform;

    public DragonAssetLoader(Transform transform, EntityPrefabs entityPrefabs)
    {
        _transform = transform;
        _entityPrefabs = entityPrefabs;
    }

    public void LoadAsset(string prefabName, Action<GameObject> onGameObjectLoaded, Action<Exception> onError)
    {
        try
        {

            for (int cnt = 0; cnt < _loadedPrefabs.Count; cnt++)
            {
                if (_loadedPrefabs[cnt].name == prefabName)
                {
                    onGameObjectLoaded(_loadedPrefabs[cnt]);
                    return;
                }
            }

            for (int cnt = 0; cnt < _entityPrefabs.Entities.Count; cnt++)
            {
                if (_entityPrefabs.Entities[cnt].name == prefabName)
                {
                    var prefabInScene = GameObject.Instantiate(_entityPrefabs.Entities[cnt], _transform);
                    prefabInScene.SetActive(false);
                    _loadedPrefabs.Add(prefabInScene);
                    //load into our local scene catch so we can compile out certain scripts

                    onGameObjectLoaded(prefabInScene);
                    return;
                }
            }

            onError(new Exception(string.Format("Could not find the entity in list '{0}'.", prefabName)));
            
        }
        catch (Exception ex)
        {
            onError(ex);
        }

    }

    public void CancelAllLoads()
    {
        //nothing needed to do
    }
}

