# UnityPoolingManager
Simple Pooling Manager for Unity3D

What is it?
  -----------

  A simple pooling manager for Unity3D projects.


  Getting started
  ------------------
  
  PoolingManager.cs- Script to attach to an empty GameObject to enable pooling and instantiating by name.
  
  ObjectsToPool.cs - Attach to gameobject that you wish to pool. Object is pooled when it gets disabled.

  Resources Folder - PoolingManager will load specified subfolders in this directory for objects to instantiate.

  Dependencies
  ------------------
  
  -Unity3D Game Engine

  How To Use
  ------------------
  
  -Attach "PoolingManager" script to a gameobject (an empty one is ideal).
  
  -Set up your Resources folder with subfolders such as "Resources/Enemies".

  -Select the gameobject with the PoolingManager script attached, set the "Resource Name" array in the inspector
		with the Resource subfolders you wish you load for instantiating.

  -Attach the "ObjectToPool" script to any object you wish to pool after being disabled.

  -To instantiate you will need to use the "PoolingManager.Instance.Instantiate" method.
	Example: "PoolingManager.Instance.Instantiate("Orc", Vector3.zero, Quaternion.identity)" will 
		  create an orc at position (0,0,0).
  -Have fun!