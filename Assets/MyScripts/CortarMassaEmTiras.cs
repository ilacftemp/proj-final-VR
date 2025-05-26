using UnityEngine;


public class CortarMassaEmTiras : MonoBehaviour
{
    public GameObject massaDividida;
    public GameObject outraMassaAberta;
    public string tagPizzaCutter = "PizzaCutter";

    private static bool massaJaFoiCortada = false;

    private void OnTriggerEnter(Collider other)
    {
        if (massaJaFoiCortada) return;

        if (other.CompareTag(tagPizzaCutter))
        {
            massaJaFoiCortada = true;

            // massaDividida.SetActive(true);
            gameObject.SetActive(false);

            TornarPegavel(massaDividida);

            if (outraMassaAberta != null)
            {
                TornarPegavel(outraMassaAberta);

                var colocar = outraMassaAberta.GetComponent<ColocarNaForma>();
                if (colocar != null)
                    colocar.AtivarPegavel();
            }
        }
    }

    private void TornarPegavel(GameObject objeto)
    {
        var grabbable = objeto.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabbable != null)
            grabbable.enabled = true;
    }

    public static void ResetarEstado()
    {
        massaJaFoiCortada = false;
    }
}