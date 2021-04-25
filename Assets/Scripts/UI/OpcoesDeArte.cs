using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcoesDeArte : MonoBehaviour
{
    public void AtivarVSync(bool ativar)
    {
        if (ativar)
        {
            QualitySettings.vSyncCount = 1;
            return;
        }

        QualitySettings.vSyncCount = 0;
    }

    public void AtivarFullscreen(bool ativar)
    {
        if (ativar)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            return;
        }

        Screen.fullScreenMode = FullScreenMode.Windowed;
    }


}
