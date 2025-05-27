using UnityEngine;

public class DoughFlattener : MonoBehaviour
{
    public GameObject doughObject;
    public GameObject flatDoughObject;
    public GameObject poofEffect;

    private bool hasDough = false;
    private bool hasRollingPin = false;

    private void Start()
    {
        // Certifique-se de que o objeto de massa achatada esteja desativado no início
        flatDoughObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dough"))
        {
            hasDough = true;
        }

        if (other.CompareTag("RollingPin"))
        {
            hasRollingPin = true;
        }

        if (hasDough && hasRollingPin)
        {
            FlattenDough();
        }
    }

    private void FlattenDough()
    {
        // Desativa o objeto de massa original
        // doughObject.SetActive?(false);
        // Destroi o objeto de massa original
        Destroy(doughObject);

        // Ativa o objeto de massa achatada
        flatDoughObject.SetActive(true);

        // Instancia o efeito de poof
        Instantiate(poofEffect, transform.position, Quaternion.identity);

        // Reseta os estados
        hasDough = false;
        hasRollingPin = false;

        Debug.Log("Massa achatada com sucesso!");
    }
}