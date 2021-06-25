using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureCommand : CommandManager.ICommand
{
    private Vector3Int start;
    private Vector3Int end;

    private Unit captured;
    private Unit captureing;

    public CaptureCommand(Vector3Int start, Vector3Int end)
    {
        this.start = start;
        this.end = end;
    }

    public void Execute()
    {
        captured = Gameboard.Instance.GetUnit(end);
        captureing = Gameboard.Instance.GetUnit(start);

        Gameboard.Instance.MoveUnit(captureing, end);
        Gameboard.Instance.TakeOutUnit(captured);
        Gameboard.Instance.SwitchTeam();
    }

    public void Undo()
    {
        Gameboard.Instance.MoveUnit(captureing, start);
        Gameboard.Instance.MoveUnit(captured, end);
        Gameboard.Instance.SwitchTeam();
    }
}
