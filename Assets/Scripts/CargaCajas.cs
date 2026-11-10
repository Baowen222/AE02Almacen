
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaCajas : MonoBehaviour
{
    bool cargadas = false;
    bool cambiando = false;

    void Update()
    {
        if (cambiando) return;

        if (Input.GetKeyDown(KeyCode.L) && !cargadas)
        {
            StartCoroutine(Cargar());
        }

        if (Input.GetKeyDown(KeyCode.U) && cargadas)
        {
            StartCoroutine(Descargar());
        }
    }

    System.Collections.IEnumerator Cargar()
    {
        cambiando = true;

        yield return SceneManager.LoadSceneAsync(
            "ZonaCajas", LoadSceneMode.Additive);

        cargadas = true;
        cambiando = false;
        Debug.Log("Cajas cargadas");
    }

    System.Collections.IEnumerator Descargar()
    {
        cambiando = true;

        yield return SceneManager.UnloadSceneAsync("ZonaCajas");

        cargadas = false;
        cambiando = false;
        Debug.Log("Cajas descargadas");
    }
}
