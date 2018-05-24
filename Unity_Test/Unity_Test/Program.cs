using UnityEngine;
using System.Collections;

public class AllFunction : MonoBehaviour
{
    /*
        API Version: 4.3
     *  Count:60
     */

    // Awake is called when the script instance is being loaded (Since v1.0)
    //当一个脚本实例被载入时Awake被调用。一般用于初始化整个实例使用。 在生命周期中只执行一次
    public void Awake()
    {

    }

    // Update is called every frame, if the MonoBehaviour is enabled (Since v1.0)
    /// <summary>
    /// 当MonoBehaviour启用时，其Update在每一帧被调用。
    ///Update是实现各种游戏行为最常用的函数。
    ///为了获取自最后一次调用Update所用的时间,可以用Time.deltaTime。这个函数只有在Behaviour启用时被调用。实现组件功能时重载这个函数。
    /// </summary>
    public void Update()
    {

    }

    // Start is called just before any of the Update methods is called the first time (Since v1.0)
    /// <summary>
    /// Start仅在Update函数第一次被调用前调用。
    ///Start在behaviour的生命周期中只被调用一次。它和Awake的不同是Start只在脚本实例被启用时调用。
    ///你可以按需调整延迟初始化代码。Awake总是在Start之前执行。这允许你协调初始化顺序。
    ///在所有脚本实例中，Start函数总是在Awake函数之后调用。
    /// </summary>
    public void Start()
    {

    }

    // Reset to default values (Since v1.0)
    /// <summary>
    /// 重置为默认值。
    ///Reset是在用户点击检视面板的Reset按钮或者首次添加该组件时被调用。
    ///此函数只在编辑模式下被调用。Reset最常用于在检视面板中给定一个最常用的默认值。
    /// </summary>
    public void Reset()
    {

    }

    // OnWillRenderObject is called once for each camera if the object is visible (Since v2.0)
    /// <summary>
    /// 如果对象可见每个相机都会调用它。
    ///如果MonoBehaviour被禁用，此函数将不被调用。
    ///此函数在消隐过程中被调用，在渲染所有被消隐的物体之前被调用。
    ///你可以用它来创建具有依赖性的纹理并且只有在被渲染的物体可见时才更新这个纹理。举例来讲，它已用于水组件中。
    ///Camera.current将被设置为要渲染这个物体的相机。
    /// </summary>
    public void OnWillRenderObject()
    {

    }

    // This function is called when the script is loaded or a value is changed in the inspector (Called in the editor only). (Since v4.2)
    public void OnValidate()
    {

    }

    // OnTriggerStay2D is called once per frame for every Collider2D other that is touching the trigger (2D physics only). (Since v4.3)
    public void OnTriggerStay2D(Collider2D other)
    {

    }

    // OnTriggerStay is called once per frame for every Collider other that is touching the trigger (Since v1.0)
    /// <summary>
    /// 当碰撞体接触触发器时，OnTriggerStay将在每一帧被调用。
    ///这个消息被发送到触发器和接触到这个触发器的碰撞体。注意如果碰撞体附加了一个刚体，也只发送触发器事件。
    ///OnTriggerStay可以被用作协同程序，在函数中调用yield语句。
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerStay(Collider other)
    {

    }

    // OnTriggerExit2D is called when the Collider2D other has stopped touching the trigger (2D physics only). (Since v4.3)
    public void OnTriggerExit2D(Collider2D other)
    {

    }

    // OnTriggerExit is called when the Collider other has stopped touching the trigger (Since v1.0)
    /// <summary>
    /// 当Collider(碰撞体)停止触发trigger(触发器)时调用OnTriggerExit。
    ///这个消息被发送到触发器和接触到这个触发器的碰撞体。注意如果碰撞体附加了一个刚体，也只发送触发器事件。
    ///OnTriggerExit可以被用作协同程序，在函数中调用yield语句。
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerExit(Collider other)
    {

    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only). (Since v4.3)
    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    // OnTriggerEnter is called when the Collider other enters the trigger (Since v1.0)
    /// <summary>
    /// 当Collider(碰撞体)进入trigger(触发器)时调用OnTriggerEnter。
    ///这个消息被发送到触发器碰撞体和刚体(或者碰撞体假设没有刚体)。注意如果碰撞体附加了一个刚体，也只发送触发器事件。
    ///OnTriggerEnter可以被用作协同程序，在函数中调用yield语句。
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {

    }

    // Called on the server whenever a Network.InitializeServer was invoked and has completed (Since v2.0)
    /// <summary>
    /// 当Network.InitializeServer被调用并完成时，在服务器上调用这个函数。
    /// </summary>
    public void OnServerInitialized()
    {

    }

    // Used to customize synchronization of variables in a script watched by a network view (Since v2.0)
    /// <summary>
    /// 在一个网络视图脚本中，用于自定义变量同步。
    ///它自动决定被序列化的变量是否应该发送或接收，查看下面的例子获取更好的描述。
    ///这个依赖于谁拥有这个物体，例如，所有者发送，其他物体接收。
    /// </summary>
    /// <param name="info"></param>
    /// <param name="stream"></param>
    public void OnSerializeNetworkView(NetworkMessageInfo info, BitStream stream)
    {

    }

    // OnRenderObject is called after camera has rendered the scene (Since v3.0)
    /// <summary>
    /// 在相机场景渲染完成后被调用。
    ///该函数可以用来渲染你自己的物体，用Graphics.DrawMesh或者其他函数。这个函数类似于OnPostRender，
    ///除非OnRenderObject被其他物体用脚本函数调用，否则它是否附于相机都没有关系。
    /// </summary>
    public void OnRenderObject()
    {

    }

    // OnRenderImage is called after all rendering is complete to render image (Since v1.0)
    /// <summary>
    /// 当完成所有渲染图片后被调用，用来渲染图片后期效果。
    ///后期效果处理(仅Unity Pro)。
    ///它允许你使用基于着色器的过滤器来处理最终的图像。进入的图片是source渲染纹理。结果是destination渲染纹理。
    ///当有多个图片过滤器附加在相机上时，它们序列化地处理图片，将第一个过滤器的目标作为下一个过滤器的源。
    ///这个消息被发送到所有附加在相机上的脚本。
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="source"></param>
    public void OnRenderImage(RenderTexture destination, RenderTexture source)
    {

    }

    // OnPreRender is called before a camera starts rendering the scene (Since v1.0)
    /// <summary>
    /// 在相机渲染场景之前被调用。
    ///只有脚本被附加到相机并被启用时才会调用这个函数。
    ///注意:如果你改变了相机的参数(如:fieldOfView),它将只作用于下一帧.应该用OnPreCull代替.OnPreRender可以是一个协同程序,在函数中调用yield语句即可.
    /// </summary>
    public void OnPreRender()
    {

    }

    // OnPreCull is called before a camera culls the scene (Since v1.0)
    /// <summary>
    /// 在相机消隐场景之前被调用。
    ///消隐决定哪个物体对于相机来说是可见的.OnPreCull仅是在这个过程被调用。
    ///只有脚本被附加到相机上时才会调用这个函数。
    ///如果你想改变相机的参数(比如:fieldOfView或者transform)，可以在这里做这些。场景物体的可见性将根据相机的参数在OnPreCull之后确定。
    /// </summary>
    public void OnPreCull()
    {

    }

    // OnPostRender is called after a camera finished rendering the scene (Since v1.0)
    /// <summary>
    /// 在相机完成场景渲染之后被调用。
    ///只有该脚本附于相机并启用时才会调用这个函数。OnPostRender可以是一个协同程序，在函数中调用yield语句即。
    ///OnPostRender在相机渲染完所有物体之后被调用。如果你想在相机和GUI渲染完成后做些什么，就用WaitForEndOfFrame协同程序。
    /// </summary>
    public void OnPostRender()
    {

    }

    // Called on the server whenever a player disconnected from the server. (Since v2.0)
    /// <summary>
    /// 当一个玩家从服务器上断开时在服务器端调用。
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerDisconnected(NetworkPlayer player)
    {
        Debug.Log("Clean up after player " + player);
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }

    // Called on the server whenever a new player has successfully connected (Since v2.0)
    /// <summary>
    /// 当一个新玩家成功连接时在服务器上被调用。
    /// </summary>
    /// <param name="player"></param>
    public void OnPlayerConnected(NetworkPlayer player)
    {
        int playerCount = 0;
        // 用玩家的信息构建一个数据结构
        Debug.Log("Player " + playerCount + " connected from " + player.ipAddress + ":" + player.port);
    }

    // OnParticleCollision is called when a particle hits a collider (Since v1.0)
    /// <summary>
    /// 当粒子碰到collider时被调用。
    ///这个可以用于游戏对象被粒子击中时应用伤害到它上面。
    ///这个消息被发送到所有附加到theWorldParticleCollider 的脚本上和被击中的碰撞体上。这个消息只有当你在theWorldParticleCollider 
    ///检视面板中启用了sendCollisionMessage 才会被发送。
    ///OnParticleCollision 可以被用作协同程序，在函数中调用yield语句。
    /// </summary>
    /// <param name="other"></param>
    public void OnParticleCollision(GameObject other)
    {

    }

    // Called on objects which have been network instantiated with Network.Instantiate (Since v2.0)
    /// <summary>
    /// 当一个物体使用Network.Instantiate进行网络初始化时调用。
    ///这对于禁用或启用一个已经初始化的物体组件来说是非常有用的，它们的行为取决于它们是在本地还是在远端。
    ///注意: 在NetworkMessageInfo里的networkView属性不能在OnNetworkInstantiate里使用。
    /// </summary>
    /// <param name="info"></param>
    public void OnNetworkInstantiate(NetworkMessageInfo info)
    {

    }

    // OnMouseUpAsButton is only called when the mouse is released over the same GUIElement or Collider as it was pressed (Since v3.4)
    public void OnMouseUpAsButton()
    {

    }

    // OnMouseUp is called when the user has released the mouse button (Since v1.0)
    /// <summary>
    /// 用户释放鼠标按钮时调用OnMouseUp。
    ///OnMouseUp只调用在按下的同一物体上。
    /// </summary>
    public void OnMouseUp()
    {

    }

    // OnMouseOver is called every frame while the mouse is over the GUIElement or Collider (Since v1.0)
    /// <summary>
    /// 当鼠标悬浮在GUIElement(GUI元素)或Collider(碰撞体)上时调用 OnMouseOver 。
    /// </summary>
    public void OnMouseOver()
    {

    }

    // OnMouseExit is called when the mouse is not any longer over the GUIElement or Collider (Since v1.0)
    /// <summary>
    /// 当鼠标移出GUIElement(GUI元素)或Collider(碰撞体)上时调用OnMouseExit。
    ///OnMouseExit与OnMouseEnter相反。
    /// </summary>
    public void OnMouseExit()
    {

    }

    // OnMouseEnter is called when the mouse entered the GUIElement or Collider (Since v1.0)
    /// <summary>
    /// 当鼠标进入到GUIElement(GUI元素)或Collider(碰撞体)中时调用OnMouseEnter。
    /// 这个函数不会在属于Ignore Raycast的层上调用.
    ///它可以被作为协同程序,在函数体内使用yield语句.这个事件将发送到所有附在Collider或GUIElement的脚本上.
    ///注意:这个函数在iPhone上无效.
    /// </summary>
    public void OnMouseEnter()
    {
        // 附加这个脚本到网格
        // 当鼠标经过网格时网格变红色
        renderer.material.color = Color.red;
    }

    // OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse (Since v1.0)
    /// <summary>
    /// 当用户鼠标拖拽GUIElement(GUI元素)或Collider(碰撞体)时调用 OnMouseDrag 。
    ///OnMouseDrag在鼠标按下的每一帧被调用。
    ///这个函数不会在属于Ignore Raycast的层上调用。
    ///它可以被作为协同程序，在函数体内使用yield语句，这个事件将发送到所有附在Collider或GUIElement的脚本上。
    ///注意:此函数在iPhone上无效。
    /// </summary>
    public void OnMouseDrag()
    {

    }

    // OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider (Since v1.0)
    /// <summary>
    /// 当鼠标在GUIElement(GUI元素)或Collider(碰撞体)上点击时调用OnMouseDown。
    /// 这个事件将发送给 Collider 或 GUIElement 上的所有脚本。
    /// 这个函数不会在属于Ignore Raycast的层上调用.
    ///它可以被作为协同程序，在函数体内使用yield语句，这个事件将发送到所有附在Collider或GUIElement的脚本上。
    ///注意:此函数在iPhone上无效。
    /// </summary>
    public void OnMouseDown()
    {
        // 点击物体后载入"SomeLevel"关卡.
        Application.LoadLevel("SomeLevel");
    }

    // Called on clients or servers when reporting events from the MasterServer (Since v2.0)
    /// <summary>
    /// 当报告事件来自主服务器时在客户端或服务器端调用。
    /// 例如：当一个客户列表接收完成或客户注册成功后被调用。
    /// </summary>
    /// <param name="msEvent"></param>
    public void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if (msEvent == MasterServerEvent.RegistrationSucceeded)
            Debug.Log("Server registered");

        /*
            void Start() {
                Network.InitializeServer(32, 25000);
            }
            void OnServerInitialized() {
                MasterServer.RegisterHost("MyGameVer1.0.0_42", "My Game Instance", "This is a comment and place to store data");
            }
            void OnMasterServerEvent(MasterServerEvent msEvent) {
                if (msEvent == MasterServerEvent.RegistrationSucceeded)
                    Debug.Log("Server registered");

            }

         */
    }

    // This function is called after a new level was loaded (Since v1.0)
    /// <summary>
    /// 当一个新关卡被载入时此函数被调用。
    /// "level" 是被加载的关卡的索引。使用菜单项File->Build Settings... 来查看索引引用的是哪个场景。
    /// OnLevelWasLoaded可以被用作协同程序,在函数中调用yield语句.
    /// </summary>
    /// <param name="level">关卡的索引</param>
    public void OnLevelWasLoaded(int level)
    {
        // 当关卡13被加载时打印"Woohoo"
        if (level == 13)
            print("Woohoo");
    }

    // Called when a joint attached to the same game object broke (Since v2.0)
    /// <summary>
    /// 当附在同一对象上的关节被断开时调用。
    ///当一个力大于这个关节的承受力时，关节将被断开。此时OnJointBreak将被调用，应用到关节的力将被传入。之后这个关节将自动从游戏对象中移除并删除。
    /// </summary>
    /// <param name="breakForce"></param>
    public void OnJointBreak(float breakForce)
    {
        Debug.Log("Joint Broke!, force: " + breakForce);
    }

    // OnGUI is called for rendering and handling GUI events (Since v2.0)
    /// <summary>
    /// 渲染和处理GUI事件时调用。
    ///这意味着你的OnGUI程序将会在每一帧被调用。要得到更多的GUI事件的信息查阅Event手册。如果Monobehaviour的enabled属性设为false，OnGUI()将不会被调用。
    /// </summary>
    public void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
            print("You clicked the button!");

    }

    // Called on clients or servers when there is a problem connecting to the MasterServer (Since v2.0)
    /// <summary>
    /// 当连接主服务器出现问题时在客户端或服务器端调用.
    ///失败原因将作为 NetworkConnectionError 枚举传入.
    /// </summary>
    /// <param name="info"></param>
    public void OnFailedToConnectToMasterServer(NetworkConnectionError info)
    {
        Debug.Log("Could not connect to master server: " + info);
    }

    // Called on the client when a connection attempt fails for some reason (Since v2.0)
    /// <summary>
    /// 当一个连接因为某些原因失败时在客户端调用。
    ///失败原因将作为 NetworkConnectionError 枚举传入。
    /// </summary>
    /// <param name="error"></param>
    public void OnFailedToConnect(NetworkConnectionError error)
    {
        Debug.Log("Could not connect to server: " + error);
    }

    // This function is called when the object becomes enabled and active (Since v1.0)
    /// <summary>
    /// 当对象变为可用或激活状态时此函数被调用。
    /// </summary>
    public void OnEnable()
    {

    }

    // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn (Since v1.0)
    /// <summary>
    /// 如果你想在物体被选中时绘制gizmos，执行这个函数。
    ///Gizmos只在物体被选择的时候绘制。Gizmos不能被点选，这可以使设置更容易。例如:一个爆炸脚本可以绘制一个球来显示爆炸半径
    /// </summary>
    public void OnDrawGizmosSelected()
    {
        float explosionRadius = 5.0F;
        // 被选中时显示爆炸半径.
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, explosionRadius);

    }

    // Implement this OnDrawGizmosSelected if you want to draw gizmos only if the object is selected (Since v1.0)
    /// <summary>
    /// 如果你想绘制可被点选的gizmos，执行这个函数。
    ///这允许你在场景中快速选择重要的物体。
    ///注意: OnDrawGizmos使用相对鼠标坐标。
    /// </summary>
    public void OnDrawGizmos()
    {
        //在物体的位置绘制一个灯泡图标
        Gizmos.DrawIcon(transform.position, "Light Gizmo.tiff");
    }

    // Called on the client when the connection was lost or you disconnected from the server (Since v2.0)
    /// <summary>
    /// 当失去连接或从服务器端断开时在客户端调用。
    /// </summary>
    /// <param name="info">网络中断</param>
    public void OnDisconnectedFromServer(NetworkDisconnection info)
    {
        Debug.Log("Disconnected from server: " + info);
    }

    // This function is called when the behaviour becomes disabled or inactive (Since v1.0)
    /// <summary>
    /// 当可编写脚本对象超出范围时调用这个函数。
    ///当物体被销毁也将被调用并且可以使用任何清除代码。当编译完成以后重新加载脚本时，OnDisable将被调用，随后脚本已经加载之后，OnEnable被调用。
    ///OnDisable不能作为一个协同程序。
    /// </summary>
    public void OnDisable()
    {

    }

    // This function is called when the MonoBehaviour will be destroyed (Since v3.2)
    /// <summary>
    /// 当MonoBehaviour将被销毁时，这个函数被调用。
    ///OnDestroy只会在预先已经被激活的游戏物体上被调用。
    ///OnDestroy不能用于协同程序。
    /// </summary>
    public void OnDestroy()
    {

    }

    // OnControllerColliderHit is called when the controller hits a collider while performing a Move (Since v2.0)
    /// <summary>
    /// 在移动的时，当controller碰撞到collider时OnControllerColliderHit被调用。
    /// 它可以用来在角色碰到物体时推开物体。
    /// </summary>
    /// <param name="hit">控制碰撞器碰撞</param>
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        // 没有刚体
        if (body == null || body.isKinematic)
            return;
        // 不推开我们身后的物体
        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        // 如果知道角色移动的速度,你可以用它乘以推动速度(pushPower)
        float pushPower = 2.0F;
        body.velocity = pushDir * pushPower;

    }

    // Called on the client when you have successfully connected to a server (Since v2.0)
    /// <summary>
    /// 当你成功连接到服务器时，在客户端调用。
    /// </summary>
    public void OnConnectedToServer()
    {
        Debug.Log("Connected to server");
    }

    // OnCollisionStay2D is called once per frame for every collider2D/rigidbody2D that is touching rigidbody2D/collider2D (2D physics only). (Since v4.3)
    public void OnCollisionStay2D(Collision2D coll)
    {

    }

    // OnCollisionStay is called once per frame for every collider/rigidbody that is touching rigidbody/collider (Since v1.0)
    /// <summary>
    /// 当此collider/rigidbody触发另一个rigidbody/collider时，OnCollisionStay将会在每一帧被调用。
    /// 相对于OnTriggerExit，OnCollisionExit传递的是Collision类而不是Collider。
    /// Collision包含接触点,碰撞速度等细节。如果在函数中不使用碰撞信息，省略collisionInfo参数以避免不必要的运算.注意如果碰撞体附加了一个非动力学刚体，只发送碰撞事件。
    /// OnCollisionStay 可以被用作协同程序，在函数中调用yield语句。
    /// </summary>
    /// <param name="collisionInfo"></param>
    public void OnCollisionStay(Collision collisionInfo)
    {
        //eg:
        // 绘制所有接触点和法线
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

    }

    // OnCollisionExit2D is called when this collider2D/rigidbody2D has stopped touching another rigidbody2D/collider2D (2D physics only). (Since v4.3)
    //碰撞停止时候开始触发 仅用于2D物体
    public void OnCollisionExit2D(Collision2D coll)
    {

    }

    // OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider (Since v1.0)
    /// <summary>
    /// 此collider/rigidbody停止触发另一个rigidbody/collider时，OnCollisionExit将被调用。(即：碰撞停止)
    /// 相对于OnTriggerExit，OnCollisionExit传递的是Collision类而不是Collider。
    /// Collision包含接触点,碰撞速度等细节。如果在函数中不使用碰撞信息，省略collisionInfo参数以避免不必要的运算.注意如果碰撞体附加了一个非动力学刚体，只发送碰撞事件。
    /// OnCollisionExit 可以被用作协同程序，在函数中调用yield语句。
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionExit(Collision collision)
    {

    }

    // OnCollisionEnter2D is called when this collider2D/rigidbody2D has begun touching another rigidbody2D/collider2D (2D physics only). (Since v4.3)
    //当两个物体开始碰撞到另一个物体时候触发 仅用于2D物体
    public void OnCollisionEnter2D(Collision2D coll)
    {

    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider (Since v1.0)
    /// <summary>
    /// 当此collider/rigidbody触发另一个rigidbody/collider时，OnCollisionEnter将被调用。(即：碰撞开始)
    /// 相对于OnTriggerEnter，OnCollisionEnter传递的是Collision类而不是Collider。
    /// Collision包含接触点，碰撞速度等细节。如果在函数中不使用碰撞信息，省略collisionInfo参数以避免不必要的运算。注意如果碰撞体附加了一个非动力学刚体，只发送碰撞事件。
    /// OnCollisionEnter可以被用作协同程序，在函数中调用yield语句。
    /// </summary>
    /// <param name="collision">碰撞的碰撞器</param>
    public void OnCollisionEnter(Collision collision)
    {
        // 如果碰撞体有较大冲击则。。。。。
        //relativeVelocity:两个碰撞物体的相对线性速度（只读）。  magnitude：大小值
        if (collision.relativeVelocity.magnitude > 2)
        {
            //Dosomeing
        }
    }

    // OnBecameInvisible is called when the renderer is no longer visible by any camera (Since v1.0)
    /// <summary>
    /// 当renderer(渲染器)在任何相机上都不可见时调用OnBecameInvisible。
    /// 这个消息发送到所有附在渲染器的脚本上。 OnBecameVisible 和 OnBecameInvisible可以用于只需要在物体可见时才进行的计算。
    /// OnBecameVisible可以被用作协同程序，在函数中调用yield语句。当在编辑器中运行时，场景面板相机也会导致这个函数被调用。
    /// </summary>
    public void OnBecameInvisible()
    {

    }

    // OnBecameVisible is called when the renderer became visible by any camera (Since v1.0)
    /// <summary>
    /// 当renderer(渲染器)在任何相机上可见时调用OnBecameVisible。
    /// 这个消息发送到所有附在渲染器的脚本上。 OnBecameVisible 和 OnBecameInvisible可以用于只需要在物体可见时才进行的计算。
    /// OnBecameVisible可以被用作协同程序，在函数中调用yield语句。当在编辑器中运行时，场景面板相机也会导致这个函数被调用。
    /// </summary>
    public void OnBecameVisible()
    {

    }



    // If OnAudioFilterRead is implemented, Unity will insert a custom filter into the audio DSP chain (Since v3.5)
    public void OnAudioFilterRead(int channels, float[] data)
    {

    }

    // Sent to all game objects before the application is quit (Since v1.0)
    /// <summary>
    /// 在应用退出之前发送给所有的游戏物体。
    /// 当用户停止运行模式时在编辑器中调用。当web被关闭时在网页播放器中被调用。
    /// </summary>
    public void OnApplicationQuit()
    {

    }

    // Sent to all game objects when the player pauses (Since v1.0)
    /// <summary>
    /// 当玩家暂停时发送到所有的游戏物体。
    ///OnApplicationPause 可以作为协同程序，在函数中使用yield语句即可。
    /// </summary>
    /// <param name="pause"></param>
    public void OnApplicationPause(bool pause)
    {

    }

    // Sent to all game objects when the player gets or looses focus (Since v3.0)
    /// <summary>
    /// 当玩家获得或失去焦点时发送给所有游戏物体。
    ///OnApplicationFocus 可以作为协同程序，在函数中使用yield语句即可。
    /// </summary>
    /// <param name="focus"></param>
    public void OnApplicationFocus(bool focus)
    {

    }

    // This callback will be invoked at each frame after the state machines and the animations have been evaluated, but before OnAnimatorIK (Since v4.0)
    public void OnAnimatorMove()
    {

    }

    // Callback for setting up animation IK (inverse kinematics) (Since v4.0)
    public void OnAnimatorIK(int layerIndex)
    {

    }

    // LateUpdate is called every frame, if the Behaviour is enabled (Since v1.0)
    /// <summary>
    /// 当Behaviour启用时，其LateUpdate在每一帧被调用。
    /// LateUpdate是在所有Update函数调用后被调用。这可用于调整脚本执行顺序。例如:当物体在Update里移动时，跟随物体的相机可以在LateUpdate里实现。
    /// </summary>
    public void LateUpdate()
    {

    }


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled (Since v1.0)
    /// 当MonoBehaviour启用时，其 FixedUpdate 在每一帧被调用。
    /// 每固定帧绘制时执行一次，和update不同的是FixedUpdate是渲染帧执行，
    /// 如果你的渲染效率低下的时候FixedUpdate调用次数就会跟着下降。FixedUpdate比较适用于物理引擎的计算，因为是跟每帧渲染有关。Update就比较适合做控制。
    /// 处理Rigidbody时，需要用FixedUpdate代替Update。例如:给刚体加一个作用力时，你必须应用作用力在FixedUpdate里的固定帧，而不是Update中的帧。(两者帧长不同)
    /// </summary>
    public void FixedUpdate()
    {

    }


    /***********************
     * 
     * 以下为MonoBehaviour下的方法
     */


    /// <summary>
    /// 取消这个MonoBehaviour上的所有调用。
    /// </summary>
    public void CancelInvokes()
    {

    }

    /// <summary>
    /// 在time秒调用methodName方法；简单说，根据时间调用指定方法名的方法
    /// 从第一次调用开始,每隔repeatRate时间调用一次.
    /// </summary>
    /// <param name="methodName">方法名(不用带括号)</param>
    /// <param name="time">第一次调用方法(methodName)的时间</param>
    /// <param name="repeatRate">每次循环调用方法(methodName)间隔时间</param>
    public void InvokeRepeating(string methodName, float time, float repeatRate)
    {

    }
    /// <summary>
    /// 在time秒调用methodName方法；简单说，根据时间调用指定方法名的方法.
    /// </summary>
    /// <param name="methodName">方法名(不用带括号)</param>
    /// <param name="time">第一次调用方法(methodName)的时间</param>
    public void Invoke(string methodName, float time)
    {

    }
    /// <summary>
    /// 某指定函数是否在等候调用。
    /// </summary>
    /// <param name="methodName">函数名</param>
    public void IsInvoking(string methodName)
    {
    }
    /// <summary>
    /// 停止这个动作中名为methodName的所有协同程序。
    ///请注意只有StartCoroutine使用一个字符串方法名时才能用StopCoroutine停用之.
    /// </summary>
    /// <param name="methodName">方法名</param>
    public void StopCoroutine(string methodName)
    {
    }
    /// <summary>
    /// 停止所有动作的协同程序。
    /// </summary>
    public void StopCoroutine()
    {

    }
    /// <summary>
    /// 开始协同程序。
    /// 一个协同程序在执行过程中,可以在任意位置使用yield语句。yield的返回值控制何时恢复协同程序向下执行。
    /// 协同程序在对象自有帧执行过程中堪称优秀。协同程序在性能上没有更多的开销。StartCoroutine函数是立刻返回的,但是yield可以延迟结果。直到协同程序执行完毕。
    ///用javascript不需要添加StartCoroutine，编译器将会替你完成.但是在C#下，你必须调用StartCoroutine。
    /// </summary>
    /// <param name="routine"></param>
    public void StartCoroutine(IEnumerator routine)
    {

    }
}