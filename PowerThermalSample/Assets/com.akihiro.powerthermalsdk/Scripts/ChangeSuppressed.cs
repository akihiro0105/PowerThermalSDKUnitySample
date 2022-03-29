#if POWERTHERMALNOTIFICATION
using Microsoft.MixedReality.PowerThermalNotification;
using UnityEngine;

public class ChangeSuppressed : MonoBehaviour
{
    [SerializeField] private PowerThermalPeripheralFlags powerThermalPeripheralFlags = (PowerThermalPeripheralFlags)0;

    private PowerThermalNotification powerNotification = PowerThermalNotification.GetForCurrentProcess();

    public void IsSuppressed(bool isSuppressed)
    {
        powerNotification.SuppressPlatformMitigation(powerThermalPeripheralFlags, isSuppressed);
    }
}
#endif
