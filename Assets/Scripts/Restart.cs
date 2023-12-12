using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
