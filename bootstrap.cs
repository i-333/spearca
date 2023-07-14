using System;

namespace HelloWorld {
  class A {
    public virtual string Foo(string name) {
      return name;
    }
    public void Foo2() { }
  }
  class B : A {
    public override string Foo(string name) {
      return "B" + "_" + name;
    }
  }
  // 三重继承
  class C : B {
    public new string Foo(string name) {
      return "C" + "_" + name;
    }
  }
  class AA : A {
    public sealed override string Foo(string name) {
      return name;
    }
  }
  class BB : AA {
    // seal 方法不能再 override 了
    // public sealed string Foo(string name)
    // {

    // }
  }
  abstract class Sharp {
    public abstract int Area(int num);
  }
  class Circle : Sharp {
    public override int Area(int num) {
      return num;
    }
  }
  public delegate void FooDelegate(int n);
  public record Person(string FirstName, string LastName, string[] PhoneNumbers);
  interface IFoo {
    public void Foo(string name);
  }
  class Program {
    private class D {
      public void Foo() { }
    }
    D DD { get; set; } = new D();
    static void Foo(int n) {

    }
    static void Main(string[] args) {
      FooDelegate del1, del2;
      B BFoo2 = new B();

      var BFoo2Del = BFoo2.Foo2;

      del1 = (int n) => { };
      del2 = (int n) => { };

      del1 = del2;

      del1 = del1 + del2;

      var foo = Foo;

      A c1 = new C();
      Console.WriteLine("Hello " + c1.Foo("foo"));
      B c2 = new C();
      Console.WriteLine("Hello " + c2.Foo("foo"));

      int[] source = { 0, 1, 2, 3, 4, 5 };
      var limit = 3;
      var query = from item in source
                  where item <= limit
                  select item;

      var phoneNumbers = new string[2];
      Person person1 = new("Nancy", "Davolio", phoneNumbers);
      Person person2 = new("Nancy", "Davolio", phoneNumbers);
      // Console.WriteLine(person1 == person2); // output: True

      person1.PhoneNumbers[0] = "555-1234"; // 引用类型
      // Console.WriteLine(person1 == person2); // output: True

      // Console.WriteLine(ReferenceEquals(person1, person2)); // output: False

      var v1 = new { Title = "Hello", Age = 24 };
      var v2 = new { Title = "Hello", Age = 24 };

      // Console.WriteLine(v1.Equals(v2)); // output: True

      var bb = new BB();
      // Console.WriteLine($"bb.Foo, {bb.Foo("bb")}");

      Sharp s = new Circle();

      var area = s.Area(1);
      // Console.WriteLine($"Area: {area}");

      string str = "中国汉字";

      // Console.WriteLine($"str.length: {str.Length}");
      var noOutdenting = """ 
        A line of text.
      Trying to outdent the second line.
      """;

      Console.WriteLine(noOutdenting);
    }
  }
}
