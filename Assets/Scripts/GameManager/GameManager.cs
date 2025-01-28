using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class GameManager : SingletonMonobehaviour<GameManager>
{
    #region Header DUNGEON LEVELS

    [Space(10)]
    [Header("DUNGEON LEVELS")]

    #endregion Header DUNGEON LEVELS

    #region Tooltip

    [Tooltip("Populate with the dungeon level scriptable objects")]

    #endregion Tooltip

    [SerializeField] private List<DungeonLevelSO> dungeonLevelList;

    #region Tooltip

    [Tooltip("Populate with the starting dungeon level for testing , first level = 0")]

    #endregion Tooltip

    [SerializeField] private int currentDungeonLevelListIndex = 0;

    [HideInInspector] public GameState gameState;
    [HideInInspector] public GameState previousGameState;

    protected override void Awake()
    {
        // Call base class
        base.Awake();


    }

    /// <summary>
    /// Create player in scene at position
    /// </summary>
  

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        // Unsubscribe from room changed event
       

    }

 

    // Start is called before the first frame update
    private void Start()
    {
        previousGameState = GameState.gameStarted;
        gameState = GameState.gameStarted;

        // Set score to zero

        // Set multiplier to 1;

        // Set screen to black
    }

    // Update is called once per frame
    private void Update()
    {
        HandleGameState();

        if (Input.GetKeyDown(KeyCode.P))
        {
            gameState = GameState.gameStarted;
        }

    }

    /// <summary>
    /// Handle game state
    /// </summary>
    private void HandleGameState()
    {
        // Handle game state
        switch (gameState)
        {
            case GameState.gameStarted:


                gameState = GameState.playingLevel;


                break;

            case GameState.dungeonOverviewMap:

                if (Input.GetKeyUp(KeyCode.Tab))
                {
                }

                break;

        }

    }



  

  
    /// <summary>
    /// Get the current dungeon level
    /// </summary>
    public DungeonLevelSO GetCurrentDungeonLevel()
    {
        return dungeonLevelList[currentDungeonLevelListIndex];
    }


    #region Validation

#if UNITY_EDITOR

    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(dungeonLevelList), dungeonLevelList);
    }

#endif

    #endregion Validation

}