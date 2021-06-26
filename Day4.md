### Day4 提高效率

https://www.bilibili.com/video/BV1PW41197Su?p=3（【siki学院】Unity3D - Unity基础案例-教你如何做一个你儿时肯定玩过的坦克大战游戏【已完结】）

摄像机的size参数表示了摄像机距离场景的距离，size只能是正值。

![image-20210330090548228](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210330090548228.png)

此处代表了场景分辨率。



图片素材的处理：

1.texture type

2.sprite mode

3.将图集切割成单图（sprite editor）

![image-20210330091204560](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210330091204560.png)

![image-20210330091300671](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210330091300671.png)



预制体



![image-20210331103822098](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210331103822098.png)

我们也可以在sprite渲染器的位置直接（点击右侧圆圈）更换图片内容而不改变预制体的参数，在本游戏的制作中可以极大的节省时间和精力。

PS.CTRL+D是复制



除了图片以外，简单的动画也是一种预制体，动画需要动画和动画控制器。

自动创建动画



C#

为.NET推出的高级语言。



C#基础语法

`Console.WriteLine("Hello World！")；`

`Console.ReadLine（）；`

//注释

代码内容储存在.cs文件里，生成后才会生成debug文件夹中的.exe文件。

ReadLine的作用即为等待命令（暂停程序）



Console是“类”，类是一种工具（箱），工具箱中包含许多功能，C#中默认导入console类。

![image-20210331114441821](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210331114441821.png)

对比Title和WriteLine，可以发现Title没有“()”，这意味这Title没有自身参数，本身是一个属性，而WriteLine是一个功能。

![image-20210331114741822](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210331114741822.png)

如图，在VS编译器的联想功能中也有区分。

`类.方法();` 即调用语句——使用某个类中的方法。

![image-20210331115059735](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210331115059735.png)

