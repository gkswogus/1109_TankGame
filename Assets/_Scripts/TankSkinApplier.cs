using UnityEditor.SceneManagement;
using UnityEngine;

public class TankSkinApplier : MonoBehaviour
{
   [SerializeField] private Transform skinRoot;

    private void Start()
    {
        ApplySelectedSkin();
    }
    private void ApplySelectedSkin()
    {
        GameObject selectedSkin = GameManager.Instance.SelectedTankPrefab;

        foreach(Transform chile in skinRoot)
        {
            Destroy(chile.gameObject);
        }

        GameObject newSkin = Instantiate(selectedSkin, skinRoot);

        newSkin.transform.localPosition = Vector3.zero;
        newSkin.transform.localRotation = Quaternion.identity;
        newSkin.transform.localScale = Vector3.one;
    }

    

}
