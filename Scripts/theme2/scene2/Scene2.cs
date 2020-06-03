using UnityEngine;
using System.Collections;

public class Scene2 : MonoBehaviour
{
    public GameObject KitchenAssets, TableAssets, table, Boa;
    public bool detectedCard, detectedPage = false;

    void Start()
    {
        KitchenAssets.SetActive(false);
        TableAssets.SetActive(false);
        table.SetActive(false);
        Boa.SetActive(false);
    }

    void Update()
    {
        if (detectedPage)
        {
            StartCoroutine(setEnvironment());
        }
    }

    public IEnumerator setEnvironment()
    {
        KitchenAssets.SetActive(true);
        TableAssets.SetActive(true);
        table.SetActive(true);
        Boa.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }
}
