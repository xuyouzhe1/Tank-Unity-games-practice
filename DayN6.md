Unity中的四种光源：

1.直射光：相当于一个平行光源，**所处位置不影响光影效果**，只有平行光线的方向影响光影效果。观察天空盒子可以看到平行光源遥远的正后方有一个太阳的贴图。

2.point light：点光源。

3.spot light：手电筒式的散射光/聚光灯

4.area light(baked only)：区域光源

区域光，和直射光、点光源、聚光灯都不一样，它需要被照射的物体勾选static
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200814102014653.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjkzNTM5OA==,size_16,color_FFFFFF,t_70#pic_center)



今天用到的API：

# Camera.ScreenPointToRay  

# 屏幕位置转射线

`JavaScript` => ScreenPointToRay(position: Vector3): Ray;  
`C#` => Ray ScreenPointToRay(Vector3 position); 

#### Description 描述

Returns a ray going from camera through a screen point. 

返回一条射线从摄像机通过一个屏幕点。 

Resulting ray is in world space, starting on the near plane of the camera and  going through position's (x,y) pixel coordinates on the screen (position.z is  ignored). 

产生的射线是在世界空间中，从相机的近裁剪面开始并穿过屏幕position(x,y)像素坐标（position.z被忽略）。 

Screenspace is defined in pixels. The bottom-left of the screen is (0,0); the  right-top is (pixelWidth,pixelHeight). 

屏幕空间以像素定义。屏幕的左下为(0,0)；右上是(pixelWidth,pixelHeight)。 

JavaScript: 

```
	// Draws a line in the scene view going through a point 200 pixels

	// from the lower-left corner of the screen

	function Update () {

		var ray : Ray = camera.ScreenPointToRay (Vector3(200,200,0));

		Debug.DrawRay (ray.origin, ray.direction * 10, Color.yellow);

	}
```

C#: 

```
using UnityEngine;

using System.Collections;

 

public class ExampleClass : MonoBehaviour {

    void Update() {

        Ray ray = camera.ScreenPointToRay(new Vector3(200, 200, 0));

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

    }

}
```

[Camera](../camera/camera.html) 