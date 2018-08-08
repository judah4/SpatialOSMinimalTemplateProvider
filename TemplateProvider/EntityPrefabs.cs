using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

#endif



    [CreateAssetMenu(fileName = "EntityPrefabs", menuName = "Twokinds Online/Spatial/Entity Prefabs", order = 1)]
    public class EntityPrefabs : ScriptableObject
    {

        public List<GameObject> Entities= new List<GameObject>();

        #if UNITY_EDITOR
        [ContextMenu("Grab From Entities Folder")]
        protected void UpdateFromFolder()
        {
            var assets = AssetDatabase.FindAssets("t:Prefab", new []{"Assets/EntityPrefabs"});
            for (int cnt = 0; cnt < assets.Length; cnt++)
            {
                var gm = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(assets[cnt]));
                if (Entities.Contains(gm) == false)
                {
                    Entities.Add(gm);
                }
            }

            Entities.Sort((s1, s2) => s1.name.CompareTo(s2.name));

        }
        #endif
    }

