

### Day7 坚持不懈



先做一个总结，对于C#中的参数传递而言，有以下三种传递方法。

值参数是默认的传递方法，这个方法中主程序（或者说引用端）的实际参数不会发生改变，方法只对形参做修改，能够输出的只有return后的变量。

引用参数在要引用的参数前加ref，这种方式会同时改变形参和实参的值。如果想要交换两个变量的值，使用值参数是无法交换的，这个时候必须使用ref。

最后一种是out输出参数，可以用于编写无return的方法，或一次返回多个值，返回值即为out后的参数，这种参数最后被赋予out后的变量名而非方法名。



## 参数传递

当调用带有参数的方法时，您需要向方法传递参数。在 C# 中，有三种向方法传递参数的方式：

| 方式     | 描述                                                         |
| :------- | :----------------------------------------------------------- |
| 值参数   | 这种方式复制参数的实际值给函数的形式参数，实参和形参使用的是两个不同内存中的值。在这种情况下，当形参的值发生改变时，不会影响实参的值，从而保证了实参数据的安全。 |
| 引用参数 | 这种方式复制参数的内存位置的引用给形式参数。这意味着，当形参的值发生改变时，同时也改变实参的值。 |
| 输出参数 | 这种方式可以返回多个值。                                     |

## 按值传递参数

这是参数传递的默认方式。在这种方式下，当调用一个方法时，会为每个值参数创建一个新的存储位置。

实际参数的值会复制给形参，实参和形参使用的是两个不同内存中的值。所以，当形参的值发生改变时，不会影响实参的值，从而保证了实参数据的安全。下面的实例演示了这个概念：

## 实例

**using** System;
**namespace** CalculatorApplication
{
  **class** NumberManipulator
  {
   **public** **void** swap(**int** x, **int** y)
   {
     **int** temp;
     
     temp = x; */\* 保存 x 的值 \*/*
     x = y;   */\* 把 y 赋值给 x \*/*
     y = temp; */\* 把 temp 赋值给 y \*/*
   }
   
   **static** **void** Main(**string**[] args)
   {
     NumberManipulator n = new NumberManipulator();
     */\* 局部变量定义 \*/*
     **int** a = 100;
     **int** b = 200;
     
     Console.WriteLine("在交换之前，a 的值： {0}", a);
     Console.WriteLine("在交换之前，b 的值： {0}", b);
     
     */\* 调用函数来交换值 \*/*
     n.swap(a, b);
     
     Console.WriteLine("在交换之后，a 的值： {0}", a);
     Console.WriteLine("在交换之后，b 的值： {0}", b);
     
     Console.ReadLine();
   }
  }
}

当上面的代码被编译和执行时，它会产生下列结果：

```
在交换之前，a 的值：100
在交换之前，b 的值：200
在交换之后，a 的值：100
在交换之后，b 的值：200
```

结果表明，即使在函数内改变了值，值也没有发生任何的变化。

## 按引用传递参数

引用参数是一个对变量的**内存位置的引用**。当按引用传递参数时，与值参数不同的是，它不会为这些参数创建一个新的存储位置。引用参数表示与提供给方法的实际参数具有相同的内存位置。

在 C# 中，使用 **ref** 关键字声明引用参数。下面的实例演示了这点：

## 实例

**using** System;
**namespace** CalculatorApplication
{
  **class** NumberManipulator
  {
   **public** **void** swap(**ref** **int** x, **ref** **int** y)
   {
     **int** temp;

​     temp = x; */\* 保存 x 的值 \*/*
​     x = y;   */\* 把 y 赋值给 x \*/*
​     y = temp; */\* 把 temp 赋值给 y \*/*
​    }
  
   **static** **void** Main(**string**[] args)
   {
​     NumberManipulator n = new NumberManipulator();
​     */\* 局部变量定义 \*/*
​     **int** a = 100;
​     **int** b = 200;

​     Console.WriteLine("在交换之前，a 的值： {0}", a);
​     Console.WriteLine("在交换之前，b 的值： {0}", b);

​     */\* 调用函数来交换值 \*/*
​     n.swap(**ref** a, **ref** b);

​     Console.WriteLine("在交换之后，a 的值： {0}", a);
​     Console.WriteLine("在交换之后，b 的值： {0}", b);
 
​     Console.ReadLine();

   }
  }
}

当上面的代码被编译和执行时，它会产生下列结果：

```
在交换之前，a 的值：100
在交换之前，b 的值：200
在交换之后，a 的值：200
在交换之后，b 的值：100
```

结果表明，*swap* 函数内的值改变了，且这个改变可以在 *Main* 函数中反映出来。

## 按输出传递参数

return 语句可用于只从函数中返回一个值。但是，可以使用 **输出参数** 来从函数中返回两个值。输出参数会把方法输出的数据赋给自己，其他方面与引用参数相似。

下面的实例演示了这点：

## 实例

**using** System;

**namespace** CalculatorApplication
{
  **class** NumberManipulator
  {
   **public** **void** getValue(**out** **int** x )
   {
     **int** temp = 5;
     x = temp;
   }
  
   **static** **void** Main(**string**[] args)
   {
     NumberManipulator n = new NumberManipulator();
     */\* 局部变量定义 \*/*
     **int** a = 100;
     
     Console.WriteLine("在方法调用之前，a 的值： {0}", a);
     
     */\* 调用函数来获取值 \*/*
     n.getValue(**out** a);

​     Console.WriteLine("在方法调用之后，a 的值： {0}", a);
​     Console.ReadLine();

   }
  }
}

当上面的代码被编译和执行时，它会产生下列结果：

```
在方法调用之前，a 的值： 100
在方法调用之后，a 的值： 5
```

提供给输出参数的变量不需要赋值。当需要从一个参数没有指定初始值的方法中返回值时，输出参数特别有用。请看下面的实例，来理解这一点：

## 实例

**using** System;

**namespace** CalculatorApplication
{
  **class** NumberManipulator
  {
   **public** **void** getValues(**out** **int** x, **out** **int** y )
   {
     Console.WriteLine("请输入第一个值： ");
     x = Convert.ToInt32(Console.ReadLine());
     Console.WriteLine("请输入第二个值： ");
     y = Convert.ToInt32(Console.ReadLine());
   }
  
   **static** **void** Main(**string**[] args)
   {
     NumberManipulator n = new NumberManipulator();
     */\* 局部变量定义 \*/*
     **int** a , b;
     
     */\* 调用函数来获取值 \*/*
     n.getValues(**out** a, **out** b);

​     Console.WriteLine("在方法调用之后，a 的值： {0}", a);
​     Console.WriteLine("在方法调用之后，b 的值： {0}", b);
​     Console.ReadLine();
   }
  }
}

当上面的代码被编译和执行时，它会产生下列结果（取决于用户输入）：

```
请输入第一个值：
7
请输入第二个值：
8
在方法调用之后，a 的值： 7
在方法调用之后，b 的值： 8
```













## 声明数组

在 C# 中声明一个数组，您可以使用下面的语法：

```
datatype[] arrayName;
```

其中，

- *datatype* 用于指定被存储在数组中的元素的类型。
- *[ ]* 指定数组的秩（维度）。秩指定数组的大小。
- *arrayName* 指定数组的名称。

例如：

```c#
double[] balance;
```

## 初始化数组

声明一个数组不会在内存中初始化数组。当初始化数组变量时，您可以赋值给数组。

数组是一个引用类型，所以您需要使用 **new** 关键字来创建数组的实例。

例如：

```
double[] balance = new double[10];
```

## 赋值给数组

您可以通过使用索引号赋值给一个单独的数组元素，比如：

```
double[] balance = new double[10];
balance[0] = 4500.0;
```

您可以在声明数组的同时给数组赋值，比如：

```
double[] balance = { 2340.0, 4523.69, 3421.0};
```

您也可以创建并初始化一个数组，比如：

```
int [] marks = new int[5]  { 99,  98, 92, 97, 95};
```

在上述情况下，你也可以省略数组的大小，比如：

```
int [] marks = new int[]  { 99,  98, 92, 97, 95};
```

您也可以赋值一个数组变量到另一个目标数组变量中。在这种情况下，目标和源会指向相同的内存位置：

```
int [] marks = new int[]  { 99,  98, 92, 97, 95};
int[] score = marks;
```

当您创建一个数组时，C# 编译器会根据数组类型隐式初始化每个数组元素为一个默认值。例如，int 数组的所有元素都会被初始化为 0。

## 访问数组元素

元素是通过带索引的数组名称来访问的。这是通过把元素的索引放置在数组名称后的方括号中来实现的。例如：

```
double salary = balance[9];
```

下面是一个实例，使用上面提到的三个概念，即声明、赋值、访问数组：

## 实例

**using** System;
**namespace** ArrayApplication
{
  **class** MyArray
  {
   **static** **void** Main(**string**[] args)
   {
     **int** [] n = new **int**[10]; */\* n 是一个带有 10 个整数的数组 \*/*
     **int** i,j;


     */\* 初始化数组 n 中的元素 \*/*     
     **for** ( i = 0; i < 10; i++ )
     {
      n[ i ] = i + 100;
     }

​     */\* 输出每个数组元素的值 \*/*
​     **for** (j = 0; j < 10; j++ )
​     {
​      Console.WriteLine("Element[{0}] = {1}", j, n[j]);
​     }
​     Console.ReadKey();
   }
  }
}

当上面的代码被编译和执行时，它会产生下列结果：

```
Element[0] = 100
Element[1] = 101
Element[2] = 102
Element[3] = 103
Element[4] = 104
Element[5] = 105
Element[6] = 106
Element[7] = 107
Element[8] = 108
Element[9] = 109
```

## 使用 *foreach* 循环

在前面的实例中，我们使用一个 for 循环来访问每个数组元素。您也可以使用一个 **foreach** 语句来遍历数组。

## 实例

**using** System;

**namespace** ArrayApplication
{
  **class** MyArray
  {
   **static** **void** Main(**string**[] args)
   {
     **int** [] n = new **int**[10]; */\* n 是一个带有 10 个整数的数组 \*/*


     */\* 初始化数组 n 中的元素 \*/*     
     **for** ( **int** i = 0; i < 10; i++ )
     {
      n[i] = i + 100;
     }

​     */\* 输出每个数组元素的值 \*/*
​     **foreach** (**int** j **in** n )
​     {
​      **int** i = j-100;
​      Console.WriteLine("Element[{0}] = {1}", i, j);
​     }
​     Console.ReadKey();
   }
  }
}

当上面的代码被编译和执行时，它会产生下列结果：

```
Element[0] = 100
Element[1] = 101
Element[2] = 102
Element[3] = 103
Element[4] = 104
Element[5] = 105
Element[6] = 106
Element[7] = 107
Element[8] = 108
Element[9] = 109
```

## C# 数组细节

在 C# 中，数组是非常重要的，且需要了解更多的细节。下面列出了 C# 程序员必须清楚的一些与数组相关的重要概念：

| 概念                                                         | 描述                                                         |
| :----------------------------------------------------------- | :----------------------------------------------------------- |
| [多维数组](https://www.runoob.com/csharp/csharp-multi-dimensional-arrays.html) | C# 支持多维数组。多维数组最简单的形式是二维数组。            |
| [交错数组](https://www.runoob.com/csharp/csharp-jagged-arrays.html) | C# 支持交错数组，即数组的数组。                              |
| [传递数组给函数](https://www.runoob.com/csharp/csharp-passing-arrays-to-functions.html) | 您可以通过指定不带索引的数组名称来给函数传递一个指向数组的指针。 |
| [参数数组](https://www.runoob.com/csharp/csharp-param-arrays.html) | 这通常用于传递未知数量的参数给函数。                         |
| [Array 类](https://www.runoob.com/csharp/csharp-array-class.html) | 在 System 命名空间中定义，是所有数组的基类，并提供了各种用于数组的属性和方法。 |