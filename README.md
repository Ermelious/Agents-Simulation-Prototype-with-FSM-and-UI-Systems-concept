# Agents Simulation Prototype with Finite State Machine and UI Systems concept

This is a short prototype to design a custom Finite State Machine and a general UI System.
The goal is to keep things modular.

The 3 main base Classes are the following:
1. AbstractUIAsset.cs - All UI Classes inherits from this
2. AbstractFiniteStateMachine - All A.I Classes inherits from this
3. AbstractFiniteState - All A.I States/Behaviours inherits from this. It is accessed by AbstractFiniteStateMachine.