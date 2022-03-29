#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.UI;
using UnityEditor.PackageManager.Requests;
using System.Linq;

public class SampleImport
{
    private const string menuName = "PowerThermalSDK";
    private const string packageName = "com.microsoft.mixedreality.powerthermalnotification";
    private const string sampleName = "PowerThermalNotification Dual Use Sample";

    private static ListRequest listRequest;

    [MenuItem(menuName + " Sample/Import")]
    public static void ImportSample()
    {
        listRequest = Client.List();
        EditorApplication.update += requestProgress;
    }

    private static void requestProgress()
    {
        if (!listRequest.IsCompleted) return;
        EditorApplication.update -= requestProgress;
        var package = listRequest.Result.Where(item => item.name.Equals(packageName)).FirstOrDefault();
        if (package == null)
        {
            Debug.LogError($"Import \"{packageName}\"");
            return;
        }
        var samples = Sample.FindByPackage(package.name, package.version).Where(item => item.displayName.Equals(sampleName));
        if (samples.Count() == 0)
        {
            Debug.LogError($"Not found \"{sampleName}\"");
            return;
        }
        var sample = samples.First();
        Debug.Log($"{(sample.Import() ? "Complete" : "Faile")} \"{sample.displayName}\" in \"{package.displayName}\"");
    }
}
#endif
