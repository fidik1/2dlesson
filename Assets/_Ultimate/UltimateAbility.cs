using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UltimateAbility : Ability
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private Animator _playerAnimator;

    [SerializeField] private float _startLensSize;
    [SerializeField] private float _targetLensSize;
    [SerializeField] private float _startScreenY;
    [SerializeField] private float _targetScreenY;

    private CinemachineComposer _composer;

    private float _timeToAnim = 0.5f;

    private void Start()
    {
        _startLensSize = _camera.m_Lens.OrthographicSize;
        _composer = _camera.GetCinemachineComponent<CinemachineComposer>();
        _startScreenY = _composer.m_ScreenY;
    }

    public override void CreateAbility(PlayerController playerController)
    {
        StartCoroutine(CameraAnim());
    }

    private IEnumerator CameraAnim()
    {
        _playerAnimator.SetTrigger("Ultimate");
        float currentSize = _camera.m_Lens.OrthographicSize;
        float screenY = _composer.m_ScreenY;
        float time = 0;
        float scale = 2;
        while (time < 1 / scale)
        {
            currentSize = Mathf.Lerp(currentSize, _targetLensSize, time * scale);
            _camera.m_Lens.OrthographicSize = currentSize;

            screenY = Mathf.Lerp(screenY, _targetScreenY, time * scale);
            _composer.m_ScreenY = screenY;
            
            time += Time.deltaTime / scale;
            yield return new WaitForSeconds(Time.deltaTime / scale);
        }
        _camera.m_Lens.OrthographicSize = _targetLensSize;
        _composer.m_ScreenY = _targetScreenY;
        yield return new WaitForSeconds(_timeToAnim / 2);
        currentSize = _camera.m_Lens.OrthographicSize;
        screenY = _composer.m_ScreenY;
        time = 0;
        scale = 4;
        while (time < 1 / scale)
        {
            currentSize = Mathf.Lerp(currentSize, _startLensSize, time * scale);
            _camera.m_Lens.OrthographicSize = currentSize;

            screenY = Mathf.Lerp(screenY, _startScreenY, time * scale);
            _composer.m_ScreenY = screenY;

            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _camera.m_Lens.OrthographicSize = _startLensSize;
        _composer.m_ScreenY = _startScreenY;
    }
}
