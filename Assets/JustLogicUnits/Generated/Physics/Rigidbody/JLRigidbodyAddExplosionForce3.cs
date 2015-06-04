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
  
using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Add Explosion Force (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Add Explosion Force")]
public class JLRigidbodyAddExplosionForce3 : JLAction
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression ExplosionForce;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression ExplosionPosition;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression ExplosionRadius;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression UpwardsModifier;

    [Parameter(ExpressionType = typeof(ForceMode))]
    public JLExpression Mode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        opValue.AddExplosionForce(ExplosionForce.GetResult<System.Single>(context), ExplosionPosition.GetResult<Vector3>(context), ExplosionRadius.GetResult<System.Single>(context), UpwardsModifier.GetResult<System.Single>(context), Mode.GetResult<ForceMode>(context));
        return null;
    }
}
