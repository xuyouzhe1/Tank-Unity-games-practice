### DayN1



坦克大战中如何使得坦克向不同方向移动时，朝向和移动方向一致？

1.更换图片

2.图片旋转

（二者效果没有不同，只适用于熟悉基本命令和参数）



### 碰撞器

1.发生碰撞的双方身上都应当有碰撞器

2.其中一方要为刚体，最好是运动的一方



刚体移动（力的交互）最好放在固定物理帧更新中，以防止抖动



解释：：

FixedUpdate () 和 Update ()   

同：当MonoBehaviour启用时，其在每一帧被调用。都是用来更新的

异：Update()每一帧的时间不固定，即第一帧与第二帧的时间t1和第三帧与第四帧的时间t2不一定相同。FixedUpdate()每帧与每帧之间相差的时间是固定的.

Update受当前渲染的物体影响，这与当前场景中正在被渲染的物体有关（比如人物的面数，个数等），有时快有时慢，帧率会变化，Update被调用的时间间隔就会发生变化。但是FixedUpdate则不受帧率的变化影响，它是以固定的时间间隔来被调用。

**所以一些物理属性的更新操作应该放在FxiedUpdate中操作，比如Force，Collider，Rigidbody等。外设的操作也是，比如说键盘或者鼠标的输入输出Input，因为这样GameObject的物理表现的更平滑，更接近现实。**



渲染层
