### Day8 坚持不懈

昨天我们简单过了一遍C#语言基础，下面我们将学习Unity脚本的相关知识技能。



让我们先复习一下C#封装的知识。

# C# 封装

**封装** 被定义为"把一个或多个项目封闭在一个物理的或者逻辑的包中"。在面向对象程序设计方法论中，封装是为了防止对实现细节的访问。

抽象和封装是面向对象程序设计的相关特性。抽象允许相关信息可视化，封装则使开发者*实现所需级别的抽象*。

C# 封装根据具体的需要，设置使用者的访问权限，并通过 **访问修饰符** 来实现。

一个 **访问修饰符** 定义了一个类成员的范围和可见性。C# 支持的访问修饰符如下所示：

- public：所有对象都可以访问；
- private：对象本身在对象内部可以访问；
- protected：只有该类对象及其子类对象可以访问
- internal：同一个程序集的对象可以访问；
- protected internal：访问限于当前程序集或派生自包含类的类型。

## Public 访问修饰符

Public 访问修饰符允许一个类将其成员变量和成员函数暴露给其他的函数和对象。任何公有成员可以被外部的类访问。

下面的实例说明了这点：

## 实例

**using** System;

**namespace** RectangleApplication
{
  **class** Rectangle
  {
    *//成员变量*
    **public** **double** length;
    **public** **double** width;

​    **public** **double** GetArea()
​    {
​      **return** length * width;
​    }
​    **public** **void** Display()
​    {
​      Console.WriteLine("长度： {0}", length);
​      Console.WriteLine("宽度： {0}", width);
​      Console.WriteLine("面积： {0}", GetArea());
​    }
  }*// Rectangle 结束*

  **class** ExecuteRectangle
  {
    **static** **void** Main(**string**[] args)
    {
      Rectangle r = new Rectangle();
      r.length = 4.5;
      r.width = 3.5;
      r.Display();
      Console.ReadLine();
    }
  }
}

当上面的代码被编译和执行时，它会产生下列结果：

```
长度： 4.5
宽度： 3.5
面积： 15.75
```

在上面的实例中，成员变量 length 和 width 被声明为 **public**，所以它们可以被函数 Main() 使用 Rectangle 类的实例 **r** 访问。

成员函数 *Display()* 和 *GetArea()* 可以直接访问这些变量。

成员函数 *Display()* 也被声明为 **public**，所以它也能被 *Main()* 使用 Rectangle 类的实例 **r** 访问。

## Private 访问修饰符

Private 访问修饰符允许一个类将其成员变量和成员函数对其他的函数和对象进行隐藏。只有同一个类中的函数可以访问它的私有成员。即使是类的实例也不能访问它的私有成员。

下面的实例说明了这点：

## 实例

**using** System;

**namespace** RectangleApplication
{
  **class** Rectangle
  {
    *//成员变量*
    **private** **double** length;
    **private** **double** width;

​    **public** **void** Acceptdetails()
​    {
​      Console.WriteLine("请输入长度：");
​      length = Convert.ToDouble(Console.ReadLine());
​      Console.WriteLine("请输入宽度：");
​      width = Convert.ToDouble(Console.ReadLine());
​    }
​    **public** **double** GetArea()
​    {
​      **return** length * width;
​    }
​    **public** **void** Display()
​    {
​      Console.WriteLine("长度： {0}", length);
​      Console.WriteLine("宽度： {0}", width);
​      Console.WriteLine("面积： {0}", GetArea());
​    }
  }*//end class Rectangle*   
  **class** ExecuteRectangle
  {
​    **static** **void** Main(**string**[] args)
​    {
​      Rectangle r = new Rectangle();
​      r.Acceptdetails();
​      r.Display();
​      Console.ReadLine();
​    }
  }
}

当上面的代码被编译和执行时，它会产生下列结果：

```
请输入长度：
4.4
请输入宽度：
3.3
长度： 4.4
宽度： 3.3
面积： 14.52
```

在上面的实例中，成员变量 length 和 width 被声明为 **private**，所以它们不能被函数 Main() 访问。

成员函数 *AcceptDetails()* 和 *Display()* 可以访问这些变量。

由于成员函数 *AcceptDetails()* 和 *Display()* 被声明为 **public**，所以它们可以被 *Main()* 使用 Rectangle 类的实例 **r** 访问。

## Protected 访问修饰符

Protected 访问修饰符允许子类访问它的基类的成员变量和成员函数。这样有助于实现继承。我们将在继承的章节详细讨论这个。更详细地讨论这个。

## Internal 访问修饰符

Internal 访问说明符允许一个类将其成员变量和成员函数暴露给当前程序中的其他函数和对象。换句话说，带有 internal 访问修饰符的任何成员可以被定义在该成员所定义的应用程序内的任何类或方法访问。

下面的实例说明了这点：

## 实例

**using** System;

**namespace** RectangleApplication
{
  **class** Rectangle
  {
    *//成员变量*
    **internal** **double** length;
    **internal** **double** width;
    
    **double** GetArea()
    {
      **return** length * width;
    }
    **public** **void** Display()
    {
      Console.WriteLine("长度： {0}", length);
      Console.WriteLine("宽度： {0}", width);
      Console.WriteLine("面积： {0}", GetArea());
    }
  }*//end class Rectangle*   
  **class** ExecuteRectangle
  {
    **static** **void** Main(**string**[] args)
    {
      Rectangle r = new Rectangle();
      r.length = 4.5;
      r.width = 3.5;
      r.Display();
      Console.ReadLine();
    }
  }
}

当上面的代码被编译和执行时，它会产生下列结果：

```
长度： 4.5
宽度： 3.5
面积： 15.75
```

在上面的实例中，请注意成员函数 *GetArea()* 声明的时候不带有任何访问修饰符。如果没有指定访问修饰符，则使用类成员的默认访问修饰符，即为 **private**。

## Protected Internal 访问修饰符

Protected Internal 访问修饰符允许在本类,派生类或者包含该类的程序集中访问。这也被用于实现继承。



# 脚本介绍

一般来说，你可以将API理解为常用类。

Unity5支持C#和js两种语言。开发常用的语言是C#。Unity4之前还支持Boo script。

#### 语法结构

**using** 命名空间;

引入命名空间后使用其中的类和方法就不必前缀命名空间名。

（回顾：命名空间的意义？

避免类和方法重名）

public class 类名：MonoBehaviour

{

​	void 方法名()

​	{

​		Debug.Log("调试显示信息");

​		print("本质是Debug.Log方法");

​	}

}

注意！：

文件名与类名必须一致

写好的脚本要附加到物体上才能执行

附加到游戏物体的脚本类必须从MonoBehaviour类继承

![image-20210408092417176](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210408092417176.png)

script文件更改名称不会变动脚本的类名，需要保证类名和文件名一致。

脚本挂载到物体上会创建一个游戏对象（功能）。

游戏物体管理其上的游戏对象/功能的引用。

![image-20210408092831805](C:\Users\xuyouzhe1\AppData\Roaming\Typora\typora-user-images\image-20210408092831805.png)

这是unity脚本默认的两个方法，上面用作初始化，下面用作循环调用（大约0.2秒调动一次）

如果不调用update方法建议直接将之删除，防止占用内存。



### MonoDevelop

Unity自带的脚本编辑器。

### VS

微软公司的开发工具包，世界上公认最好的编辑器。



## C# 中的构造函数

类的 **构造函数** 是类的一个特殊的成员函数，当创建类的新对象时执行。

构造函数的名称与类的名称完全相同，它没有任何返回类型。



### ⭐脚本生命周期⭐

脚本从开始到结束，从唤醒到销毁，我们可以在哪些时机去干预脚本？可以使用什么方法去干预？

脚本生命周期中的方法自动调用，又称作“必然事件”/消息——当满足某种条件Unity引擎自动调用的函数。

