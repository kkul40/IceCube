using System.Collections;
using System;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;

public class GameService : MonoBehaviour
{

    public string environment = "production";

    async void Start()
    {
        try
        {
            var options = new InitializationOptions()
                .SetEnvironmentName(environment);

            await UnityServices.InitializeAsync(options);
        }
        catch (Exception exception)
        {
            // An error occurred during initialization.
        }
    }
}