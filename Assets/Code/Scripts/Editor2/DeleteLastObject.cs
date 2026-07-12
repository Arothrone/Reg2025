using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeleteLastObject : MonoBehaviour
{

    InputAction undoAction;

    private void Start()
    {
        undoAction = InputSystem.actions.FindAction("Undo");
    }

    public void OnDeleteButtonPressed()
    {
        PerformUndo();
    }

    private void PerformUndo()
    {
        if (HandleEditorLogic.currentObjects.Any())
        {
            Destroy(HandleEditorLogic.currentObjects.Last().GO);
            HandleEditorLogic.currentObjects.RemoveAt(HandleEditorLogic.currentObjects.Count - 1);
        }
    }


    void Update()
    {
        // triggered is true only for the single frame the combo is completed
        if (undoAction.triggered)
        {
            PerformUndo();
        }
    }
}
