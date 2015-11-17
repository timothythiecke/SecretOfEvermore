using UnityEngine;
using System.Collections;

public class CameraManager {

    private Camera _main;
    private float _yOffset;
    private float _zOffset;

    public CameraManager(float y, float z)
    {
        _main = Camera.main;
        _yOffset = y;
        _zOffset = z;
    }

    public void UpdateCameraLocation()
    { 
        var charPos = GameManager.Instance.FindMainCharacter().transform.position;
        var lerpTarget = new Vector3(charPos.x, charPos.y + _yOffset, charPos.z - _zOffset);

        _main.transform.position = Vector3.Lerp(_main.transform.position, lerpTarget, 0.075f);
    }
}

