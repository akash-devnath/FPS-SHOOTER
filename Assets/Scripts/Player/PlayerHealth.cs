using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth;
    [SerializeField] CinemachineCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;

    GameManager gameManager;
    int currentHealth;
    int cameraPriority = 20;
    private void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
        gameManager = FindFirstObjectByType<GameManager>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        AdjustShieldUI();
        if (currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deathVirtualCamera.Priority = cameraPriority;
            StarterAssetsInputs starterAssetsInputs = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssetsInputs.SetCursorState(false);
            Destroy(this.gameObject);
            gameManager.GameOver();
        }
    }

    void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
