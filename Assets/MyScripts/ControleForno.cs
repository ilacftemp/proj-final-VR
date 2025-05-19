using UnityEngine;

public class ControleForno : MonoBehaviour
{
    public static bool fornoAberto = true;
    public GameObject portaAberta;
    public GameObject portaFechada;

    public void AlternarEstadoForno()
    {
        fornoAberto = !fornoAberto;
        portaAberta.SetActive(fornoAberto);
        portaFechada.SetActive(!fornoAberto);
    }
}