using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class InventoryGrabbable : MonoBehaviour
{
    public InventoryItemData itemData;

    public bool isClone;

    private XRGrabInteractable grabInteractable;
    private XRInteractionManager interactionManager;

    private bool duplicated;

    private void Awake()
    {
        grabInteractable =
            GetComponent<XRGrabInteractable>();

        interactionManager =
            FindFirstObjectByType<XRInteractionManager>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (isClone || duplicated)
            return;

        duplicated = true;

        CreateClone(args);
    }

    private void CreateClone(SelectEnterEventArgs args)
    {
        GameObject clone = Instantiate(
            gameObject,
            transform.position,
            transform.rotation);

        InventoryGrabbable cloneScript =
            clone.GetComponent<InventoryGrabbable>();

        cloneScript.isClone = true;

        XRGrabInteractable cloneGrab =
            clone.GetComponent<XRGrabInteractable>();

        interactionManager.SelectExit(
            args.interactorObject,
            grabInteractable);

        interactionManager.SelectEnter(
            args.interactorObject,
            cloneGrab);
    }

    public void StoreInInventory()
    {
        XRInventoryManager.Instance.AddItem(itemData);

        StartCoroutine(DestroyNextFrame());
    }

    private IEnumerator DestroyNextFrame()
    {
        yield return null;
        Destroy(gameObject);
    }
}