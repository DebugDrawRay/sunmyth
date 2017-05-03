﻿using UnityEngine;
using UnityEditor;
using System.IO;

[System.Serializable]
public class CreateAsset
{
    [MenuItem("Assets/Create/Abilities/Projectile")]
    public static ProjectileAbility CreateProjectileAbility()
    {
        ProjectileAbility asset = ScriptableObject.CreateInstance<ProjectileAbility>();

        AssetDatabase.CreateAsset(asset, GetSelectedPathOrFallback() + "/NewProjectileAbility.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

    [MenuItem("Assets/Create/Abilities/Melee")]
    public static MeleeAbility CreateMeleeAbility()
    {
        MeleeAbility asset = ScriptableObject.CreateInstance<MeleeAbility>();

        AssetDatabase.CreateAsset(asset, GetSelectedPathOrFallback() + "/NewMeleeAbility.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }

    public static string GetSelectedPathOrFallback()
    {
        string path = "Assets";

        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }
}
