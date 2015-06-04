/*
	
	This file is a part of JustLogic product which is distributed under 
	the BSD 3-clause "New" or "Revised" License
	
	Copyright (c) 2015. All rights reserved. 
	Authors: Vladyslav Taranov.
	
	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
	
	* Redistributions of source code must retain the above copyright notice, this
	  list of conditions and the following disclaimer.
	
	* Redistributions in binary form must reproduce the above copyright notice,
	  this list of conditions and the following disclaimer in the documentation
	  and/or other materials provided with the distribution.
	
	* Neither the name of JustLogic nor the names of its
	  contributors may be used to endorse or promote products derived from
	  this software without specific prior written permission.
	
	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
	FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
	DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
	SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
	CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
	OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
	OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

 */
  
#if !JUSTLOGIC_FREE

using System;
using System.Collections.Generic;
using JustLogic.Core;
using JustLogic.Core.Events;
using UnityEngine;
using Object = UnityEngine.Object;

/// <tocexclude />
public abstract class JustLogicTimerBase : JustLogicBehaviorBase
{
    public float Interval;
    public bool Once;
    public Object Receiver;
    [NonSerialized]
    float _spent;

    protected void Reset()
    {
        Receiver = gameObject;
    }

    protected void Update()
    {
        if ((_spent += Time.deltaTime) > Interval)
        {
            _spent = 0f;
            if (Once) enabled = false;
            var jlscript = Receiver as JustLogicScriptBase;
            if (jlscript)
                jlscript.StartExecutionByEvent(new EventData(new OnJLTimerTick(), new[] { this }, null, 0));
            else
            {
                var script = Receiver as MonoBehaviour;
                if (script)
                    script.SendMessage("OnJLTimerTick", this, SendMessageOptions.DontRequireReceiver);
                else
                {
                    var go = Receiver as GameObject;
                    if (go)
                        go.SendMessage("OnJLTimerTick", this, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}

#endif
