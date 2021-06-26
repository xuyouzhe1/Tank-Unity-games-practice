### Day3 坚持不懈

今日学习内容：

​	Unity3D介绍

​	工具/面板介绍

​	基础概念



复习前日内容：

![image-20210329091408118](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210329091408118.png)

component是组件，组件就是“功能”，gameobject是游戏对象，包含组件且被场景包容。



P.S.直接拷贝assets文件夹就可以编辑。



合并模型（成组）：拖拽合并，可以形成父-子物体，俗称打组。

组合操作中，操作父物体可以一并操作子物体，操作子物体不会使父物体变动。所以为了父和子物体的相对独立性考虑，我们一般创建一个空物体作为父物体。



reset：重置。固定当前大小，将当前位置、方向、大小设置为原点（0，0，0；0，0，0；1，1，1）

做父子物体请一定要reset。

快捷键：ctrl+Z 撤销

编辑器的position等数据是***相对***的，子物体即相对于父物体，父物体即相对于世界系。



材质material（了解）：

![image-20210329093356275](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210329093356275.png)

材质属于游戏资源，所以在project面板创建。



附加材质：拖动

材质赋予的是mesh renderer组件（渲染组件），一切具有mesh renderer的物体都可以被赋予材质，典型地，子弹模型中的组件都可以赋予材质，但是作为父物体地空物体不可以被赋予材质。

![image-20210329094013080](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210329094013080.png)

你也可以在物体属性面板直接更改材质。



![image-20210329094701695](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210329094701695.png)

Albedo设置材质中的：纹理与颜色。在设置材质时，如果使用的不是已有的材质，unity会自动创建一个与图片同名的材质。



renderer mode：渲染模式

opaque 默认，不透明的

cutout 剪裁（去除透明通道【即透明覆部】）

fade 渐隐，淡入淡出

trans 透明（需要改变color中的A参数（透明度））

下面的内容仅了解：

![image-20210329095945019](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210329095945019.png)









