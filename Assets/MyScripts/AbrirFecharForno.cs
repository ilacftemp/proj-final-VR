using UnityEngine;

public class AbrirFecharForno : MonoBehaviour
{
    public GameObject objetoParaAtivar;

    private void OnTriggerEnter(Collider other)
    {
        if (objetoParaAtivar != null)
            objetoParaAtivar.SetActive(true);

        gameObject.SetActive(false);
    }
}