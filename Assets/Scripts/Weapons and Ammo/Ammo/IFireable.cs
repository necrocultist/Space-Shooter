using UnityEngine;

public interface IFireable
{ 
    void InitializeAmmo(AmmoDetailsSO ammoDetails, float ammoSpeed, bool overrideAmmoMovement = false);

    GameObject GetGameObject();

}
