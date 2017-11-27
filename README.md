# TinyHands

ARkit app that lets you spawn cute, little Trump hands in the real world with some of his infamous tweets floating above them.

## Side Info

This project was created as a demonstration on how to use ARkit + Unity

## Lesson Notes

### Unity Overview:
- Announced in 2005 initially targeting OS X platform
- Has expanded to 27 platforms
- 34% of top 1000 free mobile games are Made with Unity
- 5 Billion downloads of games made w/ Unity
- Big Players using Unity
    - Coca-Cola, Disney, Electronic Arts, LEGO, Microsoft, NASA, Nexon, Nickelodeon, Square Enix, Ubisoft, Obsidian, Insomniac and Warner Bros.
- Some Games Made with Unity:
    - Kerbal Space program
    - Battlestar Galactica Online
    - Hearthstone
    - Rust
    - Temple Run
    - Tiger Woods PGA Tour 12: The Masters
    - Lara Craft Go
    - Pokemon GO

### Unity Engine Capabilities
- 2D, 3D, VR/AR games
- Uses C#6
- Mono/.Net 4.6
- AI Pathfinding tools
    - Using Navigation Meshes
    - Dynamic Obstacles
- UI
- Physics
    - Box2D Physics & NVIDIA PhysX 
- Custom Tools 
    - Can be extended to allow new things
- For the Arts:
    - Cinematic content
    - Post Processing FX
    - Animation integration with Maya and other 3rd party tools
    - Level design with quick prototyping and easily import from Maya
    - Lighting: Progressive Light Mapping for light baking and light probes
- Graphics
    - Uses the low level Graphics platform of individual APIs
- Profiling tools
- Unity Asset Store
- Multiplayer
    - Matchmaking Servers for connecting players
    - Network prototyping with component model
    - Access to their framework for further optimizations
- Analytics
- Monetization
- Unity Ads
- Component based
- Monobehaviour
    - Base class from which every unity script is derived from
        - Main Functions available:
			Awake()
			Start()
			Update()
			FixedUpdate()
			LateUpdate()
			OnGUI()
			OnDisable()
			OnEnable()
- Update cycle
### ARkit
- Available on Apple products with the A9 processors and up
- Six DOF
- Features
    - w/ iPhoneX
        - TrueDepth Camera

    - Visual intertial Odometry (VIO)
        - Includes Feature Detection such as SIFT or Harris corner Detection
        - Inertial Measurement Unity (IMU)
    - Scene Understanding (Planes)
    - Light estimation
- ARSession object
    - Coordinates everything, camera, sensors, image processing, movement, etc
    - Uses an ARConfiguration Subclass to determine what kind of AR tracking it needs, including plate detection
- ARSCNView
    - Allows the placement and tracking of virtual 3D objects
    - hitTest
- ARSKView
    - Allows the placement and tacking of virtual 2D objects
- ARAnchor
    - A real-world position and orientation that is sued to play objects in the scene
- ARPlane
    - Info about real world flat, horizontal, surfaces in the real world
    - Includes orientation, plane normal, extents

### Unity/ARkit plugin
- Enables all the ARkit sdk functionality within unity
- Includes AR world tracking, plane detection, hit testing, point cloud extraction
- Must use Unity v5.6.2 +
- ARSessionNative.mm
    - Objective-C++ code
    - Interfaces with the ARKit SDK
- UnityARSessionNativeInterface.cs
    - Façade and glue between unity and native code
    - Contains the following api calls
        - RunWithConfigAndOptions
        - RunWithConfig
        - HitTest
        - GetARVideoTextureHandles
    - Contains these delegates
        - ARFrameUpdate
            - Passed Back UnityARCamera
        - ARAnchorAdded
            - Returns anchor data
        - ARAnchorUpdate
            - Returns anchor data
        - ARAnchorRemoved
            - Returns anchor data
        - ARSessionFailed
            - passes a string with error msg

### Sources
- https://unity3d.com/public-relations
- https://developer.apple.com/documentation/arkit/about_augmented_reality_and_arkit
- https://bitbucket.org/Unity-Technologies/unity-arkit-plugin
