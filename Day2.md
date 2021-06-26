# Day2 持之以恒



Asset文件夹：项目的核心(unity官方的的素材商店中，素材热度排名就叫做“TOP ASSET”)

（asset n. 有价值的人(或事物)， 有用的人(或事物)，资产， 财产）

asset文件夹包含素材文件resource文件夹。

对Asset文件夹内部文件操作就是对project内容做操作，反之亦然。



models模型文件

unity package files类似于压缩文件，包含一系列资源，可以整体化（或有选择的）导入资源

如何导出unity package：右击project面板，点击export并选择要导出的部分。合理的使用package可以提高工作效率。

这里可以从unity官方商店下载免费素材。



hierarchy是游戏对象栏，只有进入游戏对象的素材才能被显示出来，而素材只是“备用”。

scene可以直观的对游戏对象进行操作。

game面板是预览用户看到的界面。



快捷键位熟悉：

右键旋转视角，中键平移视角。

选中物体后按下F或者在hierarchy面板双击可以让物体居中（game界面居中）。

选中物体后按住Alt键，左键变为围绕旋转，右键变为围绕缩放。

按住右键的同时按下W/S/A/D/Q/E可以实现场景漫游。



Inspector检视面板

显示当前选定的游戏对象之附加组件和其属性信息

为重要游戏物品选择图标。



组件：组件是功能的模块。



unity世界的三维空间由position下的三个参数决定空间位置。

![image-20210325111155711](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325111155711.png)

前后（z），上下（y），左右（x），单位是m

世界坐标系是右手系。

坐标的值可以接受简单四则运算。



# Day2 晚上加一节课 坚持不懈

面与轴：同色的面与轴是垂直关系（这与CAD/SU等三维建模软件一致），可以拖动面使物品平行与面移动，拖动轴可以使物品平行于轴运动（注意这两者平行的区别）。

Rotation一栏也有xyz三个值，分别对应红、绿、蓝轴的轴角度值，也就是说，我们通过输入这三个值使得模型旋转。

Scale参数可以缩放、在单一维度上缩放模型大小。



将两个物体贴合与一起：顶点吸附

选中目标物体后，按住V，便可以自动寻找物体的多边形顶点，拖动移动时也会自动选择待贴合物体的顶点。



**练习：搭建车库**

一个简单的车库由四个平面，三个交通圆锥体和1辆悍马车组成。



制作对象plane，plane是一个单面的有限范围平面，如果想制作双面平面，可以使用顶点吸附。但是要注意的是，我们并非总是希望使用双面平面，因为在不影响观感的情况下使用单面，可以减少渲染量。



主场景的初始化：所有世界坐标和旋转坐标均为0，scale值均选择1.

270度和-90度等同。

善用顶点吸附（V）。

![image-20210325215506489](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325215506489.png)

![image-20210325215518700](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325215518700.png)

左边是切换轴心点，轴心点会影响scale缩放和旋转，缩放是沿着轴心点延伸的方向缩放，旋转是围绕轴心点旋转。轴心点由center（中心）和pivot（模型自定义）两种。轴心点不影响物体的质量分布和互动，只和scene场景中的互动有关。

local是使用自身坐标移动，轴会随物体移动（旋转）。global是使用世界坐标移动，任何移动不改变轴的位置。

动作：是指模型随着时间轴发生变化。unity一般0.02秒渲染一次。

![image-20210325224500877](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325224500877.png)

根据使用需求，scene面板可以切换为2D模式。



**概念解析**

坐标：X红色、Y绿色、Z蓝色

世界坐标：整个场景的坐标，固定，不随移动旋转而改变

本地坐标：物体自身自带的坐标系（这一点也和SU一致）



场景：场景是一组相关联的游戏对象的集合。通常一个关卡就是一个场景，用于展现当前关卡中的所有物体。

![image-20210325224746923](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325224746923.png)

在现版本，保存场景已不存在，统一到了save和save as中。



游戏对象：

游戏对象可以认为是一种容器，用于挂载组件。



组件：

组件是游戏对象的功能模块。

![image-20210325225325296](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325225325296.png)

组件都是类的实例，这意味着组件是具体的，有实际意义的。



![image-20210325225626884](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325225626884.png)

模型的本质是由多边形构成的，多边形是由三角形组成的。

“网格”指的就是模型中多边形的形状。以下是简单的构建模型的方法：

![image-20210325225758788](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325225758788.png)

创建一个空物体，空物体没有任何形状。下面我们要对空物体进行编辑：

![image-20210325225858996](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325225858996.png)

首先添加 mesh filter，这一步*决定*了物体的形状。

![image-20210325225959025](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325225959025.png)

形成形体后，用户是看不见这一组件的，因为我们还没有进行“渲染”这一步骤。

![image-20210325230108802](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325230108802.png)

以上是添加mesh renderer（默认）后的cube，用户已经可以看见这一组件。注意：显卡的作用就在于渲染，没有添加renderer的图形就不会增加显卡负担。



**练习：创建模型子弹**

![image-20210325230415051](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210325230415051.png)