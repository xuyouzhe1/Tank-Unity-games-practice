Terrian collider地形专用的碰撞器。

collider

![image-20210601080800820](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210601080800820.png)

此为刚体中的三个属性，分别为重力（加速度），摩擦力和滚动摩擦力。

![image-20210601080847431](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210601080847431.png)

用于冻结一定轴上的运动。





使用box collider(碰撞器）和rigidbody（刚体）做多样化操作：

1.启用box collider的is trigger选项，将碰撞器转变为触发器，不再和刚体发生collider，但是可以使用trigger系列的API进行触发检测

2.启用Gravity、kinematic进行重力编辑或禁用刚体

![image-20210601093045281](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210601093045281.png)

以上是运用触发器做Enter触发检测的一个实例，触发器（collider）的名称为other，other即会输出触发器的名称，other.name会输出所在游戏物体的名称，other.tag会输出所在物体标签的名称。

触发器可以同名，通常触发器可以命名为collider。

