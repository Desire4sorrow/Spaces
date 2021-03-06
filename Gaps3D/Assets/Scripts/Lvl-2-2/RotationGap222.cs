using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap222 : MonoBehaviour
{
	private enum Position
	{
		Forward,
		Right,
		Back,
		Left
	}

	private Vector3 _resetPosition;
	private bool _isObjectMoved = false; 
	private Position _position = Position.Forward;
	private Stopwatch _stopWatch = new Stopwatch();
	
	void OnMouseDown()
    {
		_stopWatch.Reset();
		_stopWatch.Start();
		
		if (!_isObjectMoved)
		{
			_resetPosition = GameObject.Find("Gap2").transform.position;
			_isObjectMoved = true; 
		}
    }
	
	void OnMouseUp()
    {
		_stopWatch.Stop();
		TimeSpan ts = _stopWatch.Elapsed;
		TimeSpan delay = new TimeSpan(1700000);
		
		if (ts > delay)
		{
			return;
		}
		
		if (AreObjectsInSamePosition(_resetPosition, gameObject.transform.position))
		{
			if (_position == Position.Forward)
			{
				transform.position = new Vector3(3.45f, gameObject.transform.position.y, -3);
				_position = Position.Left;
				transform.Rotate(0.0f, -90.0f, 0.0f);
			}
			else if (_position == Position.Left)
			{
				transform.position = new Vector3(3.05f, -2, -0.5f);
				_position = Position.Forward;
				transform.Rotate(0.0f, 90.0f, 0.0f);
			}
		}	
		
		_resetPosition = GameObject.Find("Gap2").transform.position;	
	}
	
	private bool AreObjectsInSamePosition(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.05f
			&& Math.Abs(position.y - gap.y) < 0.05f
			&& Math.Abs(position.z - gap.z) < 0.05f;
	}
}