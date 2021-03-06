using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DroneDelivery.Exceptions;
using DroneDelivery.Models;

namespace DroneDelivery.Providers
{
    public class DroneProvider
    {
        private Drone _drone;
        private readonly ActionsProvider actionsProvider;
        private readonly FilesProvider filesProvider;
        private readonly LoggerProvider loggerProvider;

        public DroneProvider(Drone drone)
        {
            _drone = drone;
            actionsProvider = new ActionsProvider();
            filesProvider = new FilesProvider();
            loggerProvider = new LoggerProvider();
        }
        public Task ExecuteDelivery()
        {
            _drone.inputFile = filesProvider.getInputFilePath(_drone.id);
            _drone.outputFile = filesProvider.getOutputFilePath(_drone.id);
            try
            {
                var inputs = filesProvider.getInputs(_drone.inputFile);
                if (inputs.Length <= Constants.Application.DRONE_CAPACITY)
                {
                    List<string> outputs = new List<string>();
                    foreach (var input in inputs)
                    {
                        outputs.Add(ProcessDelivery(input));
                    }
                    filesProvider.setOutput(_drone.outputFile, outputs);
                }
                else
                {
                    throw new DroneCapacityException(_drone.id);
                }
            }
            catch (Exception e)
            {
                loggerProvider.LogWrite(string.Format("{0}", e.Message));
            }

            return Task.CompletedTask;
        }

        private string ProcessDelivery(string input)
        {
            foreach (var action in input)
            {
                Enum.TryParse<Constants.Action>(action.ToString(), out var actionEnum);
                switch (actionEnum)
                {
                    case Constants.Action.A:
                        actionsProvider.ExecuteA(_drone);
                        break;
                    case Constants.Action.I:
                        actionsProvider.ExecuteI(_drone);
                        break;
                    case Constants.Action.D:
                        actionsProvider.ExecuteD(_drone);
                        break;
                    default:
                        throw new InvalidActionException(input, _drone.id);
                }
            }
            return _drone.CurrentPosition.ToString();
        }
    }
}