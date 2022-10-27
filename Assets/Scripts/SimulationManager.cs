using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalUIEnum;
using System;
using Cinemachine;

public class SimulationManager : MonoBehaviour
{
    [Header("Customizables")]
    [SerializeField]
    private int busAmount;
    [SerializeField]
    private int civilianAmount;
    [Header("Required")]
    [SerializeField]
    private SpawnableData busSpawnableData, civilianSpawnableData;
    [SerializeField]
    private List<Route> roadRoutes = new List<Route>();
    public List<Route> RoadRoutes => roadRoutes;
    [SerializeField]
    private List<Route> civilianRoutes = new List<Route>();
    public List<Route> CivilianRoutes => civilianRoutes;
    [SerializeField]
    private CinemachineFreeLook cinemachineFreeLook;
    [Header("Auto Assign")]
    [SerializeField]
    private SimulationAssets assets = new SimulationAssets();

    private void Awake()
    {
        AbstractUIAsset.GetAllUIAssetsInChildren<AbstractUIPanel>(transform, ref assets.panels);
        InitControlPanel();
    }

    private void Start()
    {
        SpawnBuses();
        SpawnCivilians();
        cinemachineFreeLook.Follow = busSpawnableData.activeSpawnables.First.Value.transform;
        cinemachineFreeLook.LookAt = busSpawnableData.activeSpawnables.First.Value.transform;
    }

    int currentTargetIndex = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cinemachineFreeLook.Follow = busSpawnableData.activeSpawnables.First.Value.transform;
            cinemachineFreeLook.LookAt = busSpawnableData.activeSpawnables.First.Value.transform;
        }
    }

    private void OnBusAmountInputChange(string value)
    {
        busAmount = int.Parse(value);
        busSpawnableData.DespawnAll();
        SpawnBuses();
    }

    private void OnCivilianAmountChange(string value)
    {
        civilianAmount = int.Parse(value);
        civilianSpawnableData.DespawnAll();
        SpawnCivilians();
    }

    private void SpawnBuses()
    {
        for (int count = 0; count < busAmount; count++)
        {
            Route roadRoute = RoadRoutes[UnityEngine.Random.Range(0, RoadRoutes.Count)];

            Vehicle vehicle = busSpawnableData.Spawn(null, Vector3.zero, Quaternion.identity).GetComponent<Vehicle>();
            vehicle.Init(roadRoute);
        }
    }

    private void SpawnCivilians()
    {
        for (int count = 0; count < civilianAmount; count++)
        {
            Route civilianRoute = CivilianRoutes[UnityEngine.Random.Range(0, CivilianRoutes.Count)];
            Civilian civilian = civilianSpawnableData.Spawn(null, Vector3.zero, Quaternion.identity).GetComponent<Civilian>();
            civilian.Init(civilianRoute);
        }
    }

    private void InitControlPanel()
    {
        assets.panels[PanelID.ControlPanel].InputsDictionary[UIControlPanelInput.ID.AmountOfBuses].Tmp_InputField.text = busAmount.ToString();
        assets.panels[PanelID.ControlPanel].InputsDictionary[UIControlPanelInput.ID.AmountOfCivilians].Tmp_InputField.text = civilianAmount.ToString();
        assets.panels[PanelID.ControlPanel].InputsDictionary[UIControlPanelInput.ID.AmountOfBuses].Tmp_InputField.onValueChanged.AddListener(OnBusAmountInputChange);
        assets.panels[PanelID.ControlPanel].InputsDictionary[UIControlPanelInput.ID.AmountOfCivilians].Tmp_InputField.onValueChanged.AddListener(OnCivilianAmountChange);
    }
}

[System.Serializable]
public class SimulationAssets
{
    public Dictionary<Enum, AbstractUIPanel> panels = new Dictionary<Enum, AbstractUIPanel>();
}