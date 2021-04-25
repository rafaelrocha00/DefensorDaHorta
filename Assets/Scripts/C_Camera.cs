using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class C_Camera : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera Main;
    CinemachineBasicMultiChannelPerlin Noise;

    void Start()
    {
        C_Jogo.instancia.CenaMudou += GetPerlinNoise;
    }


    public void GetPerlinNoise()
    {
        GameObject CameraMain = GameObject.FindGameObjectWithTag("CameraVirtualPrincipal");
        if(CameraMain != null)
        {
            Main = CameraMain.GetComponent<CinemachineVirtualCamera>();
            Noise = Main.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        }

    }

    public void AdicionarNoise(float Forca, float tempo)
    {
        StartCoroutine(AddNoise(Forca, tempo));
    }

    IEnumerator AddNoise(float Forca, float tempo)
    {
        Noise.m_AmplitudeGain += Forca;
        yield return new WaitForSeconds(tempo);
        Noise.m_AmplitudeGain -= Forca;
    }
}
