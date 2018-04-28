using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IAction {
	void Begin();
	bool InProgress();
	void Process();
	void Complete ();
}