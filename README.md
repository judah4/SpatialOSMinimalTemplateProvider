# SpatialOS Custom Minimal Template Provider

Replacement for Basic Template Provider

Instead of writing to the assets folder, the template provider insteads processes the entity and creates the copy inside the scene hierarchy.


### Setup
Requires Experimental Minimal Build System  
Replace current template provider in scene with DragonTemplateProvider  
Pick a place for the new EntityPrefabs Scriptable Object. Remember to update this list by hitting the gear on the inspector and click `Grab From Entities Folder`
Repeat for the ServerWorker Scene or Client Scene.

Initial scene load should be faster in editor and there should be no behavior change for the built worker or client.
