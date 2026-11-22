using UnityEngine;

public class Entity_AnimationEvents : MonoBehaviour
{
    private Entity entity;
    protected Audio_Manager Audio_Manager;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
        Audio_Manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }

    private void DamageTargets()
    {
        entity.DamageTargets();
    }

    private void DisableMovementAndJump()
    {
        entity.EnableMovement(false);
    }

    private void EnableMovementAndJump() 
    {
       entity.EnableMovement(true); 
    }

    private void PlayAttSound()
    {
        if (Audio_Manager != null)
            Audio_Manager.PlaySFX(Audio_Manager.att);
    }
}
