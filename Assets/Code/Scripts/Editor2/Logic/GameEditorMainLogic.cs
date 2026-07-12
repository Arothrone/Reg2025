using System.Linq;
using Unity.Cinemachine;
using UnityEngine;

public class GameEditorMainLogic : MonoBehaviour
{
    public static GameEditorMainLogic gameStarter;

    [SerializeField] GameObject cinemachineCamera;

    [SerializeField] GameObject editorCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject startMenuAll;
    [SerializeField] GameObject defeatMenu;
    [SerializeField] GameObject winMenu;
    
    [SerializeField] ListOfGOScriptableObject carsPrefabs;
    [SerializeField] UISlots slots;

    [SerializeField] GameObject simpleWheels;
    [SerializeField] GameObject spikedWheels;
    [SerializeField] GameObject rocket;
    [SerializeField] GameObject propeller;
    [SerializeField] GameObject wings;

    [SerializeField] Transform carSpawnPoint;
    [SerializeField] HideShowFinishTape firstGameObject;

    private void Start()
    {
        gameStarter = this;
        HandleEditorLogic.current = new EditorSceneInfoToId();
    }

    private void OnDisable()
    {
        gameStarter = null;
        HandleEditorLogic.current = null;
        HandleEditorLogic.currentObjects.Clear();
    }


    private void SetTape()
    {
        if (HandleEditorLogic.currentObjects.Any())
        {
            foreach (GameObjectPrefabIndex GOPI in HandleEditorLogic.currentObjects)
            {
                if (GOPI.GO.TryGetComponent<DragObjectOnScene>(out DragObjectOnScene dragScript))
                {
                    dragScript.enabled = false;
                }
                if (GOPI.GO.TryGetComponent<EnableOnStart>(out EnableOnStart enableScript))
                {
                    enableScript.enabled = true;
                }
            }

            int size = HandleEditorLogic.currentObjects.Count - 1;

            for (int i = size; i >= 0; i--)
            {
                if (HandleEditorLogic.currentObjects[i].GO.TryGetComponent<HideShowFinishTape>(out HideShowFinishTape finishTapeScript))
                {
                    firstGameObject.Show(false);
                    finishTapeScript.Show(true);
                    return;
                }
            }

        }

        firstGameObject.Show(true);
    }

    public void PlayButton()
    {
        if (HandleEditorLogic.actualScenesToIds.list == null || !HandleEditorLogic.actualScenesToIds.list.Any())
        {
            return;
        }
        if (HandleEditorLogic.current == null)
        {
            ChangeLevelValueEditor.currentLevelValue = 0;
        }
        else {
            ChangeLevelValueEditor.currentLevelValue = HandleEditorLogic.actualScenesToIds.GetListIndexById(HandleEditorLogic.current.id);
        }
        
        Set();
    }

    public void Set()
    {
        SetTape();
        editorCanvas.SetActive(false);

        

        



        foreach (Transform child in carSpawnPoint)
        {
            Destroy(child.gameObject);
        }

        Instantiate(carsPrefabs.listOfGO[HandleEditorLogic.current.info.carSettings.carModel], carSpawnPoint);

        startMenuAll.SetActive(true);

        gameCanvas.SetActive(true);

        cinemachineCamera.SetActive(false);
        cinemachineCamera.SetActive(true);

        slots.upgradeChoosableObjects.Clear();

        if (HandleEditorLogic.current.info.carSettings.spikedWheels)
        {
            slots.upgradeChoosableObjects.Add(spikedWheels);
            slots.upgradeChoosableObjects.Add(spikedWheels);
        }else
        {
            slots.upgradeChoosableObjects.Add(simpleWheels);
            slots.upgradeChoosableObjects.Add(simpleWheels);
        }

        if (HandleEditorLogic.current.info.carSettings.rocket)
        {
            slots.upgradeChoosableObjects.Add(rocket);
        }

        if (HandleEditorLogic.current.info.carSettings.propeller)
        {
            slots.upgradeChoosableObjects.Add(propeller);
        }

        if (HandleEditorLogic.current.info.carSettings.wings)
        {
            slots.upgradeChoosableObjects.Add(wings);
        }

        slots.Reset2();

        
        defeatMenu.SetActive(false);
        winMenu.SetActive(false);
    }
}
